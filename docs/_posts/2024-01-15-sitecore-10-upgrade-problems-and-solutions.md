---
title:  "Sitecore 10 Upgrade Problems And Solutions"
date:   2024-01-08 12:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Sitecore 10.3
- SQL
- Sitecore Powershell Extensions
- Docker
author: tcanyalcin
---
![alt text](../files/2024/01/15/sitecore-10.png "Sitecore 10")
  

After upgrading from Sitecore 9.1 to Sitecore 10.3 like many people, we faced bugs and some features stopped working for us. In this post, I will try to list some of them and explain how we fixed them.

## Problem: Sitecore forms list fields stopped showing values of list items in local languages

We use local languages and they have a fallback to the main languages. Such as; en-gb to en, de-de to de.

We realized after the upgrade, that any field that is based on list fields started showing item names on these local languages instead of translated ones for them. So we opened a ticket to Sitecore Support and asked for a solution. Sitecore Support registered this behavior as a bug in their bug-tracking system and gave us a reference number 602361 for tracking.

## Solution
As a workaround, they suggested either not using a fallback mechanism on form fields and creating versions on local languages or using ListDataSourceProvider from Sitecore 9.

We went with the second option as we had many forms in many languages. So we patched Sitecore 9 ListDataSourceProvider over Sitecore 10:

{% highlight csharp %}
public class ListDataSourceProvider : IListDataSourceProvider
    {
        private readonly IFormBuilderContext _formBuilderContext;
        private readonly IListItemParser _listItemParser;

        public ListDataSourceProvider(
            IFormBuilderContext formBuilderContext,
            IListItemParser listItemParser)
        {
            Assert.ArgumentNotNull((object)formBuilderContext, nameof(formBuilderContext));
            Assert.ArgumentNotNull((object)listItemParser, nameof(listItemParser));
            this._formBuilderContext = formBuilderContext;
            this._listItemParser = listItemParser;
        }

        public virtual IEnumerable<ListFieldItem> GetListItems(
            string dataSource,
            string displayFieldName,
            string valueFieldName,
            string defaultSelection)
        {
            List<ListFieldItem> listItems = new List<ListFieldItem>();
            IEnumerable<Item> dataItems = this.GetDataItems(dataSource);
            string[] strArray;
            if (defaultSelection == null)
                strArray = (string[])null;
            else
                strArray = defaultSelection.Split('|');
            string[] source = strArray;
            foreach (Item obj in dataItems)
            {
                ListFieldItem listFieldItem = this._listItemParser.Parse(obj, displayFieldName, valueFieldName);
                if (!string.IsNullOrEmpty(listFieldItem.Value))
                {
                    listFieldItem.Selected = source != null && ((IEnumerable<string>)source).Contains<string>(listFieldItem.ItemId);
                    listItems.Add(listFieldItem);
                }
            }
            return (IEnumerable<ListFieldItem>)listItems;
        }

        public virtual IEnumerable<Item> GetDataItems(string dataSource)
        {
            Item obj = !string.IsNullOrEmpty(dataSource) ? this._formBuilderContext.Database.GetItem(dataSource, this._formBuilderContext.Language) : (Item)null;
            return (IEnumerable<Item>)((obj != null ? obj.Children.ToList<Item>() : (List<Item>)null) ?? new List<Item>());
        }
    }
{% endhighlight %}

{% highlight xml %}

<?xml version="1.0" encoding="utf-8"?>
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/" xmlns:role="http://www.sitecore.net/xmlconfig/role/">
 <sitecore role:require="Standalone or ContentManagement or ContentDelivery">
  <services>
   <register patch:instead="*[@serviceType='Sitecore.ExperienceForms.Mvc.DataSource.IListDataSourceProvider, Sitecore.ExperienceForms.Mvc']" serviceType="Sitecore.ExperienceForms.Mvc.DataSource.IListDataSourceProvider, Sitecore.ExperienceForms.Mvc" implementationType="ProjectName.Foundation.Forms.ExperienceForms.Mvc.DataSource.ListDataSourceProvider, ProjectName.Foundation.Forms" lifetime="Transient" />
  </services>
 </sitecore>
</configuration>

{% endhighlight %}

## Similar Problem: Form submissions are not working in local languages
On our website, we use custom submit actions to make API requests. These API requests rely on data source items selected on Sitecore. After testing, we realized that some fields on these data source items have empty values sent to API even though they were filled on the main languages on Sitecore. So Sitecore could not fill these values that are supposed to come from fallback language.

## Solution

After opening another Sitecore support ticket, we realized that Enable item language fallback and Enable field language fallback checkboxes were not checked on site items. In the Sitecore 9 version, there was no checkbox and we were using the Other Properties field. That’s why the problem occurred. You can check the following documentation from Sitecore here
[link](https://doc.sitecore.com/xp/en/developers/sxa/103/sitecore-experience-accelerator/enable-language-fallback-for-sxa-sites.html)


For these 2 problems thank you for your support, Arun Tiwari...

## Problem: Form field classes are not rendered

After the upgrade, all of our forms were not showing CSS classes. Since they are added to the project for custom implementations, they were not changed by upgrade automatically.

## Solution

In Sitecore 9, *Model.CssClass* for fields and *Model.LabelCssClass* for labels was used. These properties become obsolete in Sitecore, so we needed to use *Model.CssClassSettings.CssClass* and *Model.LabelCssClassSettings.CssClass* respectively. After these changes, forms were rendering CSS classes again.

## Similar Problem: Forms Editor is not showing the Styling section on custom form fields

In Sitecore 10, there was another change for each form field on the core database. Sitecore started using new CssClass and LabelCssClass items on Styling item:

![alt text](../files/2024/01/15/sitecore-10-styling-item-image.png "Sitecore 10 styling item")

## Solution

Even though item names are the same, there are different items selected in Sitecore 10. You can put the following IDs on the ControlDefinitions field on Sitecore for each of these custom fields, then we will be able to see CSS classes on Sitecore Forms Editor:

{% highlight ruby %}
{98FB361E-3A7F-49F9–8789–8C169FB95B61}|{121B9875–2F7D-4D62-BD0F-35A7B909ECE8}
{% endhighlight %}


## Problem: Missing field values after Glass Mapper upgrade

After the upgrade, we realized there were many field values not showing on the website. All of these fields had one thing in common. Their properties did not have setters on class entities. But all of them were working fine before the upgrade.

## Solution

We searched on Glass Mapper release documentation and found this one:
[Glass Mapper](http://www.glass.lu/Mapper/Releases.html) on version 5.3.17 which mentions:

>ISSUE 370 The lazy object inceptor will now ignore class properties that don't have a setter or have the SitecoreIgnore attribute.

So, after upgrading the Glass Mapper, checking if every property mapped with the Glass Mapper has a setter is crucial. Especially, if you use them for API calls or search functionality.

## Problem: Custom Powershell scripts on the Toolbar are not working

In our project, we used Powershell scripts to bulk edit workflow state, copy item version, reset field value, and many more. We created these scripts and added them to the Toolbar so our customers can use them too. But after upgrading to Sitecore 10, we saw that all of them were not clickable, showing just script names and blank icons.

## Solution 

After some investigation, we rebuilt all Powershell ISE scripts. This rebuild created some changes on items. But mainly on items that represent each script on the core database had a different type now:

>Spe.Client.Controls.ContentEditorRibbonPanel,Spe

*Before* they had the following value on the type field:

>Cognifide.PowerShell.Client.Controls.ContentEditorRibbonPanel,Cognifide.PowerShell

So after we start using the updated type, scripts become clickable and icons are showing again.

## Problem: Fast Queries are not supported

Fast queries are deprecated in Sitecore 10. It's suggested to use a search index. In our case, we used a fast query to reach a setting item.

## Solution

We developed a custom SettingProvider and started using it instead of queries or search indexes.

## Problem: System.OutOfMemory Exception

After we switched to Sitecore 10 with Docker and imported the databases from the production system, several developers in the team experienced this exception. 

Either cm was unhealthy, or after some time it was becoming unhealthy. When we check logs on the docker or inspect the container, we would always see this error popping up. Also, the Sitecore system needed to be faster to work on.

## Solution

We first checked how much each container consumes when docker is started with the following command:

>docker stats

Thanks to this command, we could see that the SQL server is using way more than usual. We have seen values like 10–20 GB. We tried changing the mem-limit for each container to find the combination that works but that was barely enough. Sitecore was again too slow. We also tried deleting the whole data on the preview database, since it was not needed on our locals, but that was also not enough.

Then we realized something golden. EventQueue and PublishQueue tables in the master, web db had over 405k entries on them. So we started a cleanup using the following SQL:

{% highlight sql %}
USE [Sitecore.Core]
DELETE FROM dbo.EventQueue
DELETE FROM dbo.PublishQueue
USE [Sitecore.Master]
DELETE FROM dbo.EventQueue
DELETE FROM dbo.PublishQueue
USE [Sitecore.Web]
DELETE FROM dbo.EventQueue
DELETE FROM dbo.PublishQueue
{% endhighlight %}

After this cleanup docker became fast, and we got rid of the exception.

Thanks to Fabian Geiger and Ramazan Yilmaz for their support...
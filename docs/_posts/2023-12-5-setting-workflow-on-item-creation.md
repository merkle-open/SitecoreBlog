# **SETTING WORKFLOW ON ITEM CREATION IN SITECORE** 

## **The Problem** 

Our client had a multi-site implementation and all of the sites shared the same base templates.  We were leveraging Sitecore Headless Services to reskin each site which allowed us to re-use these templates across each site.   We also had a requirement to maintain separate workflow streams for each of the sites.  This however presents a problem as workflow is set on the standard values of an item traditionally and you can only set 1 workflow per template.  That conflicts with shared multi-site approach we have currently implemented.  So we needed to come up with a solution.

## OUR IDEAS 

- For each site, duplicate the page and component templates and set site-specific workflows on their respective standard values. 
- Programmatically set the workflow based on the site under which the item will live when a new item is created. 

The first option from an upkeep and maintenance perspective is not ideal because if a change is needed, we would need to propagate that change across each site-specific template.  We did consider leveraging base templates and inheritance to to try and cut down on amount of templates that would need to be touched.  However this still means we are creating a nye-identical template for each site and that would lead to project bloat which we are trying to avoid. Instead, we chose to utilize the Sitecore Create Item Event.  By intercepting this event and doing a bit of our own behind the scenes manipulation we are able to set the workflow on an item based on where the item is being created which we found to be the ideal solution.  This meant that we just needed to add 2 settings to our site's "site settings" instead of creating a site-specific template for each site.

## HOW TO IMPLEMENT 

Tying into the Sitecore Create Item Event allows us to catch items as they are being created and set the appropriate workflow based on the site it is created under.  For example, if we were making a hero component under site ‘x’ then we want to use the workflow that is specific to site ‘x’.  First, you need to designate a spot in your Sitecore instance where you can set what workflow values you want to use for templates created for that site. We chose to use the site nodes themselves and added two dropdown values that we sourced to the workflow section in the content tree of Sitecore “/sitecore/system/Workflows.” You can use whatever location in the content tree that makes the most sense for you to house these settings however.

![workflow settings example](..\files\2023\11\29\workflow settings.PNG)

This allowed us to set a different workflow for each site on a per-site basis. 

 

## THE CODE 

------
```
using Sitecore.Data.Events; 
using Sitecore.Data.Items; 
using Sitecore.SecurityModel; 
using System; 
using System.Linq; 
using Event = Sitecore.Events.Event; 
 
namespace Project.Common.Events 
{ 
  public class SetItemWorkflow 
  { 
     // The common workflow values function as back ups should the content authors forget to set the site workflow in the settings 
     const string COMMONWORKFLOWID = "Your Workflow ID"; 
     const string COMMONWORKFLOWSTARTSTATE = "Your Starting Workflow State"; 
     const string JSSSITEGUID = "Parent Item of the site"; 
     public void OnItemCreated(object sender, EventArgs args) 
     { 
       using (new SecurityDisabler()) 
       { 
         var arg = Event.ExtractParameter(args, 0) as ItemCreatedEventArgs; 
         if (arg == null || Sitecore.Context.Site != null && Sitecore.Context.Site.Name != "shell") return; 
         try 
         { 
           var createdItem = arg.Item; 
           if (createdItem == null) return; 
           // get the site node 
           var site = createdItem.Axes.GetAncestors().FirstOrDefault(x => x.TemplateID.ToString().Equals(JSSSITEGUID)); 
           if (site == null) return; 
           var currentSiteNodeDefaultWorkflow = site.Fields["DefaultSiteWorkflow"]; 
           var workflowState = site.Fields["DefaultWorkflowStartState"]; 
           using (new EditContext(arg.Item, SecurityCheck.Disable)) 
           { 
             arg.Item.Editing.BeginEdit(); 
             // if either required workflow setting is not set then we use the common workflow 
             if (string.IsNullOrWhiteSpace(currentSiteNodeDefaultWorkflow.ToString()) || string.IsNullOrWhiteSpace(workflowState.ToString())) 
             { 
               arg.Item["__Workflow"] = COMMONWORKFLOWID; 
               arg.Item["__Default workflow"] = COMMONWORKFLOWID; 
               arg.Item["__Workflow state"] = COMMONWORKFLOWSTARTSTATE; 
             } 
             else 
             { 
               arg.Item["__Workflow"] = currentSiteNodeDefaultWorkflow.ToString(); 
               arg.Item["__Default workflow"] = currentSiteNodeDefaultWorkflow.ToString(); 
               arg.Item["__Workflow state"] = workflowState.ToString(); 
             } 
             arg.Item.Editing.EndEdit(); 
           } 
         } 
         catch (Exception ex) 
         {           
         } 
       } 
     } 
  } 
} 
```
------

![screenshot of code file](..\files\2023\11\29\code.PNG)

```
<configuration xmls:patch="http://www.sitecore.net/xmlconfig/">
	<sitecore>
		<events>
			<event name="item:created">
				<handler type="YOUR NAME SPACE HERE.SetItemWorkflow" method="OnItemCreated" />
			</event>
        </events>
    </sitecore>
</configuration>
```



![screenshot of config settings](..\files\2023\11\29\config.PNG)

Using the sample code and configuration above, you can now set workflow, and any other site-specific fields, when it’s created while avoiding template duplication and project bloat. 

## Conclusion

To wrap things up, you can now programmatically set the workflow of all newly created items under a specific section of the content tree without needing to actually set the workflow on the standard values of an item.  

Interested in diving deeper into this or any other Sitecore topic? We'd love to share more about Merkle and our expertise with Sitecore! Don't hesitate to check out our latest projects and get in contact with us [here](https://www.merkle.com/en/home.html)! We're eager to connect and share our insights with you.
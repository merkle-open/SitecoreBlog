---
title: "11 steps to extend general link"
date: 2024-04-16 16:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Sitecore 10.3
- Sitecore XP
author: hlueneburg
---
![alt text](../files/2024/04/16/bryson-hammer-JZ8AHFr2aEg-unsplash.jpg "two connected links")

Foto [Bryson Hammer](https://unsplash.com/de/@trhammerhead?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash) on [Unsplash](https://unsplash.com/de/fotos/selektives-fokusfoto-von-grauen-metallketten-JZ8AHFr2aEg?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash)

Have you ever tried to extend the general link in Sitecore to serve additional needs? Lucky you ;)

If you need to, this quick-step-tutorial may help you to get this done. It might be helpful to extend other fieldtypes as well ([see also](/cheatsheetfieldtypes/)).

This tutorial will be based on the external link of the general link and could be easily mapped to the internal link.

## Setup

This tutorial is build in a project with Sitecore XP 10.3, TDS and Glass-Mapper. \
It might be possible that you have to change some of the steps to you local setup (I know that TDS is not very common).

## Short form (without further explanation and screenshots)

1. Change Message in Core-DB
2. Create Massagehandler
3. Register Messagehandler
4. Create new Model (Serializable)
5. Create new FieldType
6. Create FormDialog (XML)
7. Create Code-Behind Class
8. Change OR-Mapper/Code-Generator
9. Create DataMapper for Glass
10. Register DataMapper
11. Override GlassHtml

## Detailed version

The mechanics to fulfill the job are way more difficult that I thought in the beginning. And yes it took me a bit more time to get the story done.

Provided sourcecode is mostly sonarqube-validated. So it may differ from decompiled or original sources.

### Change Message in Core-DB

Log into Sitecore, get to the Desktop, switch to the core-DB and open the Content Editor. Then navigate to this item: \
*/sitecore/system/Field types/Link Types/General Link/Menu/External link*

Change the field-content of Message from `contentlink:externallink(id=$Target)` to something like `contentlink:externallinkwithtracking(id=$Target)`.

After the change sync this item into you project. Yo want to keep it in source control right?

### Create Massagehandler

The next step is to create a messagehandler, who can handle the new messagetype. This could be done like this:

```c#
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Text;

namespace Place.your.own.Namespace
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1812", Justification = "Instantiation via config by Sitecore")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1501", Justification = "Baseclasses are from Sitecore")]
    internal class SitecoreMessageHandler : Link
    {
        // Handles the message.
        public override void HandleMessage(Sitecore.Web.UI.Sheer.Message message)
        {
            Assert.ArgumentNotNull(message, nameof(message));
            base.HandleMessage(message); //base handles other message requests

            if (message["id"] != ID)
                return;

            if (string.Equals(message.Name, "contentlink:externallinkwithtracking", System.StringComparison.OrdinalIgnoreCase))
            {
                var url = new UrlString(UIUtil.GetUri("control:ExternalLinkWithTracking"));
                Insert(url.ToString());
            }
        }
    }
}
```

### Register Messagehandler

Create a .config file with a similar content:

```XML
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
    <sitecore>
        <controlSources>
            <source mode="on" namespace="Place.your.own.Namespace.SitecoreMessageHandler" assembly="Place.your.own.Assemby" prefix="content" />
        </controlSources>
    </sitecore>
</configuration>
```

Now can Sitecore handle the new message-type but doesn't know what kind of control *ExternalLinkWithTracking* might be.

### Create new Model (Serializable)

Before we create the new control we need a model, which can store our additional information.

```c#
using System;

using Glass.Mapper.Sc.Fields;

namespace Place.your.own.Namespace.Models
{
    [Serializable]
    public class LinkWithTracking : Link
    {
        public string EventCategory { get; set; }

        public string EventAction { get; set; }

        public string EventLabel { get; set; }
    }
}
```

You may now get what we intended to extend at the link.

**Important**: the model has to be serializable.

### Create new FieldType

The model is used by glass or your used OR-mapper. But it can't be used by Sitecore to store the additional data. For this we create a new FieldType:

```c#
using Sitecore.Data.Fields;

namespace Place.your.own.Namespace.FieldTypes
{
    public class LinkWithTrackingField : LinkField
    {
        public LinkWithTrackingField(Field innerField)
            : base(innerField)
        {
        }

        public LinkWithTrackingField(Field innerField, string runtimeValue)
            : base(innerField, runtimeValue)
        {
        }

        public string EventCategory
        {
            get
            {
                return GetAttribute("EventCategory");
            }
            set
            {
                SetAttribute("EventCategory", value);
            }
        }

        public string EventAction
        {
            get
            {
                return GetAttribute("EventAction");
            }
            set
            {
                SetAttribute("EventAction", value);
            }
        }

        public string EventLabel
        {
            get
            {
                return GetAttribute("EventLabel");
            }
            set
            {
                SetAttribute("EventLabel", value);
            }
        }
    }
}
```

### Create FormDialog (XML)

Now it is getting weird. Telerik. Nothing to do with items. Doesn't Sitecore tell us everything is an item? \
Anyway.

As source look into your Sitecore instance at this path: \
*\sitecore\shell\Applications\Dialogs\ExternalLink*

Create a copy of `ExternalLink.xml` and name it like `ExternalLinkWithTracking.xml`. Now change some namespaces and add the additional information like:

```XML
<?xml version="1.0" encoding="utf-8" ?>
<control xmlns:def="Definition" xmlns="http://schemas.sitecore.net/Visual-Studio-Intellisense">
  <ExternalLinkWithTracking>
    <FormDialog Header="Insert External Link" Text="Enter the URL for the external website that you want to insert a link to and specify any additional properties for the link." OKButton="Insert">

      <CodeBeside Type="Place.your.own.Namespace.ExternalLinkWithTrackingForm,Place.your.own.Assembly"/>

      <GridPanel Class="scFormTable" CellPadding="2" Columns="2" Width="100%">
        <Label For="Text" GridPanel.NoWrap="true"><Literal Text="Link description:"/></Label>
        <Edit ID="Text" Width="100%" GridPanel.Width="100%"/>
        
        <Label For="Url" GridPanel.NoWrap="true"><Literal Text="URL:"/></Label>
        <Border>
          <GridPanel Columns="2" Width="100%">
            <Edit ID="Url" Width="100%" GridPanel.Width="100%" />
            <Button id="Test" Header="Test" Style="margin-left: 10px;" Click="OnTest"/>
          </GridPanel>
        </Border>

        <Label for="Target" GridPanel.NoWrap="true"><Literal Text="Target window:"/></Label>
        <Combobox ID="Target" GridPanel.Width="100%" Width="100%" Change="OnListboxChanged">
          <ListItem Value="Self" Header="Active browser"/>
          <ListItem Value="Custom" Header="Custom"/>
          <ListItem Value="New" Header="New browser"/>
        </Combobox>
        
        <Panel ID="CustomLabel" Disabled="true" Background="transparent" Border="none" GridPanel.NoWrap="true"><Label For="CustomTarget"><Literal Text="Custom:" /></Label></Panel>
        <Edit ID="CustomTarget" Width="100%" Disabled="true"/>

        <Label For="Class" GridPanel.NoWrap="true"><Literal Text="Style class:" /></Label>
        <Edit ID="Class" Width="100%" />
        
        <Label for="Title" GridPanel.NoWrap="true"><Literal Text="Alternate text:"/></Label>
        <Edit ID="Title" Width="100%" />

        <Literal Text="Tracking Information:" GridPanel.Colspan="2"/>

        <Label for="EventCategory"><Literal Text="Event Category:"/></Label>
        <Edit ID="EventCategory" Width="100%" />

        <Label for="EventAction"><Literal Text="Event Action:"/></Label>
        <Edit ID="EventAction" Width="100%" />

        <Label for="EventLabel"><Literal Text="Event Label:"/></Label>
        <Edit ID="EventLabel" Width="100%" />
      </GridPanel>
      
    </FormDialog>
  </ExternalLinkWithTracking>
</control>
```

### Create Code-Behind Class

And the part of the CodeBeside-part:

```c#
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.Dialogs;
using Sitecore.Shell.Applications.Dialogs.ExternalLink;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using Sitecore.Xml;

using System;
using System.Collections.Specialized;
using System.Xml;

namespace Place.your.own.Namespace
{
    public class ExternalLinkWithTrackingForm : ExternalLinkForm
    {
        private const string EventCategoryAttributeName = "EventCategory";
        protected Edit EventCategory { get; set; }

        private const string EventActionAttributeName = "EventAction";
        protected Edit EventAction { get; set; }

        private const string EventLabelAttributeName = "EventLabel";
        protected Edit EventLabel { get; set; }

        private NameValueCollection customLinkAttributes;
        protected NameValueCollection CustomLinkAttributes
        {
            get
            {
                if (customLinkAttributes == null)
                {
                    customLinkAttributes = new NameValueCollection();
                    ParseLinkAttributes(GetLink());
                }

                return customLinkAttributes;
            }
        }

        protected override void ParseLink(string link)
        {
            base.ParseLink(link);
            ParseLinkAttributes(link);
        }

        protected virtual void ParseLinkAttributes(string link)
        {
            Assert.ArgumentNotNull(link, "link");
            XmlDocument xmlDocument = XmlUtil.LoadXml(link);
            if (xmlDocument == null)
            {
                return;
            }

            XmlNode node = xmlDocument.SelectSingleNode("/link");
            if (node == null)
            {
                return;
            }

            CustomLinkAttributes[EventCategoryAttributeName] = XmlUtil.GetAttribute(EventCategoryAttributeName, node);
            CustomLinkAttributes[EventActionAttributeName] = XmlUtil.GetAttribute(EventActionAttributeName, node);
            CustomLinkAttributes[EventLabelAttributeName] = XmlUtil.GetAttribute(EventLabelAttributeName, node);
        }

        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnLoad(e);
            if (Context.ClientPage.IsEvent)
            {
                return;
            }
            EventCategory.Value = CustomLinkAttributes[EventCategoryAttributeName];
            EventAction.Value = CustomLinkAttributes[EventActionAttributeName];
            EventLabel.Value = CustomLinkAttributes[EventLabelAttributeName];
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull(args, "args");
            string path = GetPath();
            string attributeFromValue = GetLinkTargetAttributeFromValue(Target.Value, CustomTarget.Value);
            Packet packet = new Packet("link", new string[0]);
            SetAttribute(packet, "text", Text);
            SetAttribute(packet, "linktype", "external");
            SetAttribute(packet, "url", path);
            SetAttribute(packet, "anchor", string.Empty);
            SetAttribute(packet, "title", Title);
            SetAttribute(packet, "class", Class);
            SetAttribute(packet, "target", attributeFromValue);

            SetAttribute(packet, EventCategoryAttributeName, EventCategory);
            SetAttribute(packet, EventActionAttributeName, EventAction);
            SetAttribute(packet, EventLabelAttributeName, EventLabel);

            SheerResponse.SetDialogValue(packet.OuterXml);
            SheerResponse.CloseWindow();
        }
        private string GetPath()
        {
            string url = this.Url.Value;
            if (url.Length > 0 && url.IndexOf("://", StringComparison.InvariantCulture) < 0 && !url.StartsWith("/", StringComparison.InvariantCulture))
            {
                url = string.Concat("http://", url);
            }

            return url;
        }
    }
}
```

**Important**: keep the name `link` for the XML-nodes to ensure compatibility to existing links.

Compile, publish and you are able to change every link in your instance with additional tracking information. \
You can edit any kind of general link and have a raw-value like this: \
`<link text="Homepage with Tracking" linktype="internal" querystring="" target="_blank" EventCategory="Category" EventAction="Action" EventLabel="Label" id="{819BFAC1-A563-49DA-9C2C-E88D0B397619}" />`

But it can't be used yet.

### Change OR-Mapper/Code-Generator

Within TDS there are usually T4-templates. Within the *glassv3item.tt* edit the Method `GetGlassFieldType`:

```T4
case "general link":
    return "LinkWithTracking";
```

Generate your models. And depending on your use of the Link-feature the will be a change of every Link-property to a LinkWithTracking-property.

### Create DataMapper for Glass

Now we have to tell Glass what it has to do with the model. This is done by a custom datamapper. \
In our case we need something like this:

```c#
using System;
using System.Collections.Concurrent;
using System.Web;

using Place.your.own.Namespace.FieldTypes;

using Glass.Mapper;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.DataMappers;
using Glass.Mapper.Sc.Fields;

using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace Place.your.own.Namespace.DataMapper
{
    /// <summary>
    /// Class LinkWithTrackingMapper
    /// Source: https://github.com/mikeedwards83/Glass.Mapper/blob/master/Source/Glass.Mapper.Sc/DataMappers/SitecoreFieldLinkMapper.cs
    /// Edited to fit the additional tracking information and the code-quality standards of the project.
    /// </summary>
    public class LinkWithTrackingMapper : AbstractSitecoreFieldMapper
    {
        private readonly IUrlOptionsResolver _urlOptionsResolver;

        private static readonly ConcurrentDictionary<Guid, bool> IsInternalLinkFieldDictionary = new ConcurrentDictionary<Guid, bool>();

        public const string InternalLinkKey = "internal link";

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkWithTrackingMapper"/> class.
        /// </summary>
        public LinkWithTrackingMapper() : this(new UrlOptionsResolver())
        {
        }

        public LinkWithTrackingMapper(IUrlOptionsResolver urlOptionsResolver)
            : this(urlOptionsResolver, typeof(LinkWithTracking))
        {
        }

        public LinkWithTrackingMapper(IUrlOptionsResolver urlOptionsResolver, Type type)
            : base(type)
        {
            _urlOptionsResolver = urlOptionsResolver;
        }

        /// <summary>
        /// Sets the field value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="config">The config.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string SetFieldValue(object value, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the field value.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="config">The config.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override object GetFieldValue(string fieldValue, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            throw new NotImplementedException();
        }

        protected void MapToLinkModel(Link link, InternalLinkField field, SitecoreFieldConfiguration config, GetOptionsSc getOptions)
        {
            if (link == null || field == null || config == null)
            {
                return;
            }

            var urlOptions = _urlOptionsResolver.CreateUrlOptions(config.UrlOptions, getOptions);

            link.Url = field.TargetItem == null ? string.Empty : SitecoreVersionAbstractions.GetItemUrl(field.TargetItem, urlOptions);
            link.Type = LinkType.Internal;
            link.TargetId = field.TargetItem == null ? Guid.Empty : field.TargetItem.ID.Guid;
            link.Text = field.TargetItem == null ? string.Empty : field.TargetItem.DisplayName;
        }

        protected void MapToLinkModel(LinkWithTracking link, LinkWithTrackingField linkField, SitecoreFieldConfiguration config, GetOptionsSc getOptions)
        {
            if (link == null || linkField == null || config == null)
            {
                return;
            }

            link.Anchor = linkField.Anchor;
            link.Class = linkField.Class;
            link.Style = linkField.GetAttribute("style");
            link.Text = linkField.Text;
            link.Title = linkField.Title;
            link.Target = linkField.Target;
            link.Query = HttpUtility.UrlDecode(linkField.QueryString);

            link.EventCategory = linkField.EventCategory;
            link.EventAction = linkField.EventAction;
            link.EventLabel = linkField.EventLabel;

            switch (linkField.LinkType)
            {
                case "anchor":
                    link.Url = linkField.Anchor;
                    link.Type = LinkType.Anchor;
                    break;

                case "external":
                    link.Url = linkField.Url;
                    link.Type = LinkType.External;
                    break;

                case "mailto":
                    link.Url = linkField.Url;
                    link.Type = LinkType.MailTo;
                    break;

                case "javascript":
                    link.Url = linkField.Url;
                    link.Type = LinkType.JavaScript;
                    break;

                case "media":
                    if (linkField.TargetItem == null)
                        link.Url = string.Empty;
                    else
                    {
                        MediaItem media = new MediaItem(linkField.TargetItem);
                        link.Url = SitecoreVersionAbstractions.GetMediaUrl(media);
                    }
                    link.Type = LinkType.Media;
                    link.TargetId = linkField.TargetID.Guid;
                    break;

                case "internal":
                    var urlOptions = _urlOptionsResolver.CreateUrlOptions(config.UrlOptions, getOptions);
                    link.Url = linkField.TargetItem == null ? string.Empty : SitecoreVersionAbstractions.GetItemUrl(linkField.TargetItem, urlOptions);
                    link.Type = LinkType.Internal;
                    link.TargetId = linkField.TargetID.Guid;
                    link.Text = linkField.Text.IsNullOrEmpty() ? (linkField.TargetItem?.DisplayName ?? string.Empty) : linkField.Text;
                    break;

                default:
#pragma warning disable S1854 // Unused assignments should be removed
                    link = null;
#pragma warning restore S1854 // Unused assignments should be removed
                    break;
            }
        }

        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="config">The config.</param>
        /// <param name="context">The context.</param>
        /// <returns>System.Object.</returns>
        public override object GetField(Field field, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            if (field == null || field.Value.Trim().IsNullOrEmpty() || context == null)
            {
                return null;
            }

            Guid fieldGuid = field.ID.Guid;

            // shortest route - we know whether or not its rich text
            var isInternalLink =
                IsInternalLinkFieldDictionary.GetOrAdd(fieldGuid, (id) => field.TypeKey == InternalLinkKey);

            LinkWithTracking link = new LinkWithTracking();
            if (isInternalLink)
            {
                InternalLinkField internalLinkField = new InternalLinkField(field);
                MapToLinkModel(link, internalLinkField, config, context.Options as GetOptionsSc);
            }
            else
            {
                LinkWithTrackingField linkField = new LinkWithTrackingField(field);

                MapToLinkModel(link, linkField, config, context.Options as GetOptionsSc);
            }

            return link;
        }

        protected static void MapToLinkField(LinkWithTracking link, LinkWithTrackingField linkField)
        {
            if (link == null || linkField == null)
            {
                return;
            }

            var item = linkField.InnerField.Item;

            switch (link.Type)
            {
                case LinkType.Internal:
                    linkField.LinkType = "internal";
                    if (linkField.TargetID.Guid != link.TargetId)
                    {
                        if (link.TargetId == Guid.Empty)
                        {
                            ItemLink iLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, linkField.TargetItem.Database.Name, linkField.TargetID, linkField.TargetItem.Paths.FullPath);
                            linkField.RemoveLink(iLink);
                        }
                        else
                        {
                            ID newId = new ID(link.TargetId);
                            Item target = item.Database.GetItem(newId);
                            if (target != null)
                            {
                                linkField.TargetID = newId;
                                ItemLink nLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, target.Database.Name, target.ID, target.Paths.FullPath);
                                linkField.UpdateLink(nLink);
                                linkField.Url = SitecoreVersionAbstractions.GetItemUrl(target);
                            }
                            else
                            {
                                throw new MapperException($"No item with ID {newId}. Can not update Link {nameof(linkField)}");
                            }
                        }
                    }
                    break;

                case LinkType.Media:
                    linkField.LinkType = "media";
                    if (linkField.TargetID.Guid != link.TargetId)
                    {
                        if (link.TargetId == Guid.Empty)
                        {
                            ItemLink iLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, linkField.TargetItem.Database.Name, linkField.TargetID, linkField.TargetItem.Paths.FullPath);
                            linkField.RemoveLink(iLink);
                        }
                        else
                        {
                            ID newId = new ID(link.TargetId);
                            Item target = item.Database.GetItem(newId);

                            if (target != null)
                            {
                                global::Sitecore.Data.Items.MediaItem media = new global::Sitecore.Data.Items.MediaItem(target);

                                linkField.TargetID = newId;
                                ItemLink nLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, target.Database.Name, target.ID, target.Paths.FullPath);
                                linkField.UpdateLink(nLink);
                                var mediaUrl = SitecoreVersionAbstractions.GetMediaUrl(media);
                                linkField.Url = mediaUrl;
                            }
                            else
                            {
                                throw new MapperException($"No item with ID {newId}. Can not update Link {nameof(linkField)}");
                            }
                        }
                    }
                    break;

                case LinkType.External:
                    linkField.LinkType = "external";
                    linkField.Url = link.Url;
                    break;

                case LinkType.Anchor:
                    linkField.LinkType = "anchor";
                    linkField.Url = link.Anchor;
                    break;

                case LinkType.MailTo:
                    linkField.LinkType = "mailto";
                    linkField.Url = link.Url;
                    break;

                case LinkType.JavaScript:
                    linkField.LinkType = "javascript";
                    linkField.Url = link.Url;
                    break;
            }

            if (!link.Anchor.IsNullOrEmpty())
                linkField.Anchor = link.Anchor;
            if (!link.Class.IsNullOrEmpty())
                linkField.Class = link.Class;
            if (!link.Text.IsNullOrEmpty())
                linkField.Text = link.Text;
            if (!link.Title.IsNullOrEmpty())
                linkField.Title = link.Title;
            if (!link.Query.IsNullOrEmpty())
                linkField.QueryString = HttpUtility.UrlEncode(link.Query);
            if (!link.Target.IsNullOrEmpty())
                linkField.Target = link.Target;
            if (!link.EventCategory.IsNullOrEmpty())
                linkField.EventCategory = link.EventCategory;
            if (!link.EventAction.IsNullOrEmpty())
                linkField.EventAction = link.EventAction;
            if (!link.EventLabel.IsNullOrEmpty())
                linkField.EventLabel = link.EventLabel;
        }

        protected static void MapToLinkField(Link link, InternalLinkField linkField, SitecoreFieldConfiguration config)
        {
            if (link == null || linkField == null)
            {
                return;
            }

            var item = linkField.InnerField.Item;

            if (link.TargetId == Guid.Empty)
            {
                ItemLink iLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, linkField.TargetItem.Database.Name, linkField.TargetID, linkField.TargetItem.Paths.FullPath);
                linkField.RemoveLink(iLink);
            }
            else
            {
                ID newId = new ID(link.TargetId);
                Item target = item.Database.GetItem(newId);

                if (target != null)
                {
                    ItemLink nLink = new ItemLink(item.Database.Name, item.ID, linkField.InnerField.ID, target.Database.Name, target.ID, target.Paths.FullPath);
                    linkField.UpdateLink(nLink);
                }
                else
                {
                    throw new MapperException($"No item with ID {newId}. Can not update Link {nameof(linkField)}");
                }
            }
        }

        /// <summary>
        /// Sets the field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="config">The config.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="Glass.Mapper.MapperException">
        /// No item with ID {0}. Can not update Link linkField.Formatted(newId)
        /// or
        /// No item with ID {0}. Can not update Link linkField.Formatted(newId)
        /// </exception>
        public override void SetField(Field field, object value, SitecoreFieldConfiguration config, SitecoreDataMappingContext context)
        {
            LinkWithTracking link = value as LinkWithTracking;

            if (field == null)
            {
                return;
            }

            Guid fieldGuid = field.ID.Guid;

            // shortest route - we know whether or not its rich text
            var isInternalLink =
                IsInternalLinkFieldDictionary.GetOrAdd(fieldGuid, (id) => field.TypeKey == InternalLinkKey);

            if (isInternalLink)
            {
                InternalLinkField internalLinkField = new InternalLinkField(field);
                MapToLinkField(link, internalLinkField, config);
            }
            else
            {
                LinkWithTrackingField linkField = new LinkWithTrackingField(field);
                if (link == null || link.Type == LinkType.NotSet)
                {
                    linkField.Clear();
                    return;
                }

                MapToLinkField(link, linkField);
            }
        }
    }
}
```

Most of the code is copied from the glass-github-project to make sure it has nearly the same functionality. And afterward SonarQube gets into contact and made me change some of the codestyle.

### Register DataMapper

Now we need to tell Glass, that there is a new mapper available. This is made within `App_Start/GlassMapperScCustom.cs`. In the method `CreateResolver()` call something like this:

```c#
dependencyResolver.DataMapperFactory.Insert(6, () => new LinkWithTrackingMapper());
```

Now we are good to go.

### Override GlassHtml

Lets do the final part: get the data into the source-code. \
This could be done bei overriding `GlassHtml` like this:

{% highlight csharp %}
public class GlassHtmlOverride : GlassHtml
{
    public GlassHtmlOverride(ISitecoreService sitecoreService) : base(sitecoreService)
    {
    }

    public override RenderingResult BeginRenderLink<T>(T model, Expression<Func<T, object>> field, TextWriter writer, object parameters = null, bool isEditable = false, bool alwaysRender = false, string aElementTemplate = "<a href={3}{0}{3} {1}>{2}")
    {
        var nameValues = EnhanceLinkRenderer(model, field, parameters);

        return base.BeginRenderLink(model, field, writer, nameValues, isEditable, alwaysRender, aElementTemplate);
    }

    public override string RenderLink<T>(T model, Expression<Func<T, object>> field, object attributes = null, bool isEditable = false, string contents = null, bool alwaysRender = false, string aElementTemplate = "<a href={3}{0}{3} {1}>{2}")
    {
        var nameValues = EnhanceLinkRenderer(model, field, attributes);

        return base.RenderLink(model, field, nameValues, isEditable, contents, alwaysRender, aElementTemplate);
    }

    private object EnhanceLinkRenderer<T>(T model, Expression<Func<T, object>> field, object parameters)
    {
        NameValueCollection nameValueCollection = !(parameters is NameValueCollection)
            ? Utilities.GetPropertiesCollection(parameters, lowerCaseName: true)
            : parameters as NameValueCollection;

        var linkWithTracking = GetCompiled(field).Invoke(model) as LinkWithTracking;
        if (linkWithTracking != null
            && !string.IsNullOrWhiteSpace(linkWithTracking.EventCategory)
            && !string.IsNullOrWhiteSpace(linkWithTracking.EventAction)
            && !string.IsNullOrWhiteSpace(linkWithTracking.EventLabel))
        {
            if (nameValueCollection == null)
            {
                nameValueCollection = new NameValueCollection();
            }
            nameValueCollection.Add("data-clickevent", $"`{`{'eventCategory': '{linkWithTracking.EventCategory}', 'eventAction': '{linkWithTracking.EventAction}', 'eventLabel': '{linkWithTracking.EventLabel}'`}`}");
        }
        return parameters;
    }
}
{% endhighlight %}

Here you can see, what we are doing with the additional information: we add an attribute with json data. This can be handled by the tracking components in the frontend. \
And how can we use it in the Views: you can use any kind of `RenderLink` or `BeginRenderLink` for any kind of LinkWithTracking-field to render.

## the end?

And then the customer complains about Experience Editor ... As usual we forget about this. Right?

Now it is getting nearly as complex as before. We haven#t done it yet, but you may follow the last link in the [Linkcollection](#linkcollection) to get it done.

## Conclusion

Many steps on an unusual way to customize Sitecore XP but it is getting the job done in the end. \
An my customer is fine with the link-tracking configuration in the Content Editor. :D

## Linkcollection

This links helped me to get the job done.

- [How to #1 to customize the general link](https://sitecorejunkie.com/2015/10/10/add-a-custom-attribute-to-the-general-link-field-in-sitecore/)
- [How to #2 to customize the general link](https://assurex.co/sitecore/extending-general-link-field-in-sitecore/)
- [How to create a glass-mapper and the rendering](https://sitecore.stackexchange.com/questions/7663/how-do-i-render-custom-attributes-on-a-general-link-using-the-latest-version-of)
- [Original LinkMapper from Glass](https://github.com/mikeedwards83/Glass.Mapper/blob/master/Source/Glass.Mapper.Sc/DataMappers/SitecoreFieldLinkMapper.cs)
- [Extending general link for Experience Editor](https://blogs.perficient.com/2024/02/07/extending-general-link-for-experience-editor-mode/)

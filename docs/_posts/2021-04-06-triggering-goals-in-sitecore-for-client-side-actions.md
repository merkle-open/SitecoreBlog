---
title:  "Triggering goals in Sitecore for client-side actions"
date:   2021-04-06 19:00 +0100
categories:
- CMS
tags:
- Experience Analytics
- Goals
author: shauck
---
## Challenge

Within Sitecore server-side tracking is already well documented. Without any adaptations we can easily add goals to [certain pages](https://doc.sitecore.com/users/93/sitecore-experience-platform/en/associate-a-goal-with-an-item.html) or [Sitecore Forms submit actions](https://doc.sitecore.com/users/93/sitecore-experience-platform/en/working-with-submit-actions.html).

We can also [trigger goals in code](https://doc.sitecore.com/developers/93/sitecore-experience-platform/en/triggering-built-in-events.html) and thus enable tracking for specific components as well. It is a bit more time consuming but also well documented. 

However recently our customer requested a feature that made us think for a while. The request appeared to be straight forward. When the visitor opens the chat window on the page or clicks on a phone contact link, a goal is triggered to signal the user contacting our client. The chat is an external application and initialized via JavaScript, so no backend involved so far.

So, we needed a way to trigger this goal from our client side and came across the **sc_trk** parameter.

## But what is sc_trk doing?

It is a parameter, that can be added to any trackable GET Request to your page. You can pass either the ID or item name of your goal or page event item within this parameter.

In showconfig we can find this entry:
```xml
<!--   ANALYTICS EVENT QUERY STRING KEY
            Specifies the key for triggering events on the query string.
            Default: sc_trk
       -->
<setting name="Analytics.EventQueryStringKey" value="sc_trk" patch:source="sitecore.analytics.tracking.config"/>
```
The parameter is processed in the `Sitecore.Analytics.Pipelines.StartTracking.ProcessQueryStringPageEvent` processor and belongs into the `startTracking` pipeline. The processor will try to find and trigger a goal for the provided identifier. If no goal is found, the same is done for a page event item. If no fitting event or goal can be found, a simple error is logged *"Failed to trigger event from query string: "* along with the provided **sc_trk** value.

This applies at least to the two versions I checked 9.3 and 10.0.0 

## How can we use this for our problem?

Now we only needed a way to send a GET request to our Sitecore instance. We did not really want to create a new page, since it would need special handling in the sitemap. It would have needed additional documentation for authors, so it is not deleted by accident and so we came up with a new idea.

For our problem, we came to the following solution. We would create a tracking pixel in our media library that we can request on certain events from our frontend. 
We upload an image with 1x1 px to `-/media/goals/trigger`.

On frontend side, we can request this pixel, whenever certain events are triggered and pass the event identifier via the **sc_trk** parameter.

For our chat module the frontend code looked like this:
```javascript
$("body").append("<img src='-/media/goals/trigger?sc_trk=Chat_requested style='display: none;'></img>")
```
I hope this helps someone else, since I did not find this parameter anywhere in the official documentation so far.

**Happy tracking!**


---
title:  "EXM campaign dispatch stopped because CM instance crashed"
date:   2024-08-29 08:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
author: dgashi
---

![Email Marketing](../files/2024/09/02/email.jpg "Email Marketing")


## Introduction


In the world of digital marketing, email campaigns are a crucial tool for engaging with our audience, driving conversions, and building brand loyalty. 
However, even the most meticulously planned campaigns can face unexpected challenges. Recently, we encountered a significant disruption when our system crashed mid-dispatch, causing our email campaigns to get stuck. Here’s a look at what happened, how we responded, and the lessons we learned from the experience.

#### The Incident: When Things Went Off Track

The campaigns were designed to reach thousands of subscribers with personalized content that would resonate with their interests.

But then, the unexpected happened. Just as the second campaign of three was rolling out, our CM server crashed due to another issue. 

The result? Hundreds of emails were stuck in limbo, neither reaching the inboxes nor bouncing back as undeliverable.


#### Recovery: Getting Back on Track

Once the system was back online, we had to decide how to proceed with the campaign. 

Our options included resending the emails that were stuck or pausing the campaign altogether to avoid overwhelming our subscribers. After careful consideration, we chose to stagger the dispatch of the remaining emails. This allowed us to complete the campaign without bombarding recipients or risking further technical issues. We also took this opportunity to recheck the content and timing, ensuring that the messages were still relevant and effective.

#### Solution

Since the campaign with the status "Sending" stopped with a progress of 40%, we wanted to be sure and reach out to the Sitecore Support team to find the best technical solution. 

![EXM Master](../files/2024/09/02/exm-campaign-status.png "Database snippet")


In this case, we need to manually change the states. Pausing and resuming the campaign was not possible in our case. Clicking the Button in the Delivery tab of the campaign did not change anything.

So manually modifying the related message status in the EXM.Master DB helps.

Here is the SQL script we used:

{% highlight sql %}
USE [Sitecore.Exm.master]
GO

UPDATE [dbo].[Campaigns]
SET [Status] = 'Paused'
WHERE MessageID = 'Your campaign id'
GO
{% endhighlight %}

By setting the status to <b>Paused</b> we were able to resume the campaing by clicking <b>Resume</b> in the Delivery tab of the campaign. 

You need also to find the campaign in the Content Editor by searching with the campaign ID, unprotect the item, and set the status again there to <b>Draft</b> to be able to send the Mail through the UI. That worked out.

After the successful send-out of this campaign, the last one with the Status <b>Queuing</b> remains in that state. Sitecore does not get the information to continue with the next campaign. That needs to be considered.

So we decided here to set the state to <b>Draft</b> by utilizing the SQL statement from above. 
Again, you need also to find the campaign in the content editor by searching with the campaign ID, unprotect the item, and set the status there to <b>Draft</b> to be able to send the Mail through the UI. 


<br>
Image from <a href="https://pixabay.com/de/users/mohamed_hassan-5229782/?utm_source=link-attribution&utm_medium=referral&utm_campaign=image&utm_content=3543958">Mohamed Hassan</a> on <a href="https://pixabay.com/de//?utm_source=link-attribution&utm_medium=referral&utm_campaign=image&utm_content=3543958">Pixabay</a>
---
title:  "Managed Redirects"
date:   2022-01-10 12:00:00 +0100
categories:
- CMS
- Sitecore
tags:
- performance
author: aklein
---
![alt text](../files/2022/01/ian-taylor-h7b1SUEMPIs-unsplash.jpg "Managed Redirects of merkleinc.com")

Redirects are part of daily life in web development. In the CMS environment, the question often arises as to what extent a CMS user can influence his own redirect wishes and what the CMS may automatically take off of him. That fact that this question can not be answered easily is shown by the numerous modules and implementations in projects. Often these approaches come with their own advantages and disadvantages. And in fact, one approach often does not fulfill all desired redirect requirements.

### Typical redirect scenarios

* Website Migration: A new website replaces the old one. The old urls must be redirected to the new target addresses.
* Moving content / content trees: The old pages should point to the new ones.
* Aliases and landing pages: short URLs in marketing emails should point to the right place
* Corrections of urls: http to https, lowercasing, wrong URLs in print media etc.

It is easy to underestimate the danger of editor configurable redirect rules.

### Dangers

* The amount of redirect rules leads to increasing response times
* Complex rules quickly lead to large execution times and memory overhead
* A lack of strategy in the management of rules leads to chaos
* Redirect loops
* In the worst case: one or more rules bring down the site completely.

### Challenges

* The impact of a single rule (especially in conjunction with existing ones) is not always directly visible
* Often too little testing is done
* The often unanswered question: Do I still need a redirect rule at all?

## How do I get rid of unnecessary redirect rules?

Here are some ways you can handle the situation

* Set an archiving date when creating the rule <br /> If you already know when a redirect is no longer needed, you should note this in some way.
* Establish a strategy <br />
If you maintain migration redirects you can set a time period how long you want to "support" them, e.g. 3 or 6 months.
* Measuring the number of executions <br />
You should count in the application how often a rule has been used over a certain period of time (per day, per week, per month, per quarter, etc.). And then define at which values a rule can be taken out of operation.
* Analysis outside application <br />
Instead of counting the executions directly, you can determine them from the IIS logs, for example. Search the redirect request urls (status code 30x) and determine the applicable rule via a script or an application.
* Is the redirect still healthy <br />
If the redirect destination of a redirect is no longer available, there is a good chance that the redirect will no longer be used. Here it is recommended to store an example when creating a rule, which can be tested. With simple scripts and tools a sample list can then be tested to see if destinations are still available.

## How efficient is a rule

If you allow a lot of flexibility with regular expressions (regex), you should be aware that real performance guzzlers can hide behind them. You should always test a new rule for its performance beforehand. You should also consider that the input length (URL) can have a strong effect on the regex expression.

For example, go ahead and test an expression like ```"(.*).domain.com/segment1/segment2/(.*)"``` with different urls lengths (100 chars, 300 chars, 500 chars, 1000 chars, 4000 chars)...

Even a small adjustment can improve performance significantly: <br />```"(www|subdomain1).domain.com/segment1/segment2/(.*)"```

Also keep in mind: it's all in the crowd. Test on 5, 100, 1000, 1000+ rules, a few milliseconds already make up a large part of a response time.

However, it is more important to validate when the redirect rules should be applied. For example, it often makes no sense to check for redirects when Sitecore has already resolved a page target, i.e. found a page. (Attention redirect items or 404 pages excluded). On the other hand, you might also want to be able to override existing targets in the Solution (i.e. before or independently of Item Resolving). This leads to a situation where the verification often takes place at different places in the request (the request pipeline).

## Impact of Managed Redirecting

When redirects are managed by the CMS user, you must be aware that a large part of power and responsibility lies with them.

It makes sense to think about this and to include the necessary processes, tests or functions, if necessary, in order to counteract any problems that may creep in at an early stage.

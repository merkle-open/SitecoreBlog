---
title:  "Sitecore JSS Update"
date:   2022-11-15 12:00:00 +0100
categories:
- CMS
- Sitecore
- JSS
tags:
- performance
author: aklein
---

![Project Decision Table](../files/2022/11/decision-tables.jpg  "Project Decision Table of merkleinc.com")
# Sitecore - Navigate your project into the right direction with a decision table

One of the things I have learned over the last twelve years in software development of web projects: Don't underestimate the effort and work around the actual implementation process.

In theory, it seems quite simple:
- You define what you do. (What?)
- You define why you do it. (Why?)
- You define when you do it. (When?)
- You define who does it. (Who?)
- You define how you do it. (How?)
- You do it. (Execution?)

In a one-man project, these things all happen quite intuitively. In large projects, these already pose significant challenges.

The sequence of activities described here is then often done in the popular agile methodologies in several iterations and done also in parallel.

In short, decisions tend to be postponed to a later point in time than in the classic waterfall model, where decisions are decided and specified early in the process. In addition, it also happens quite quickly that the process for decision-making is unclear. In Scrum, it is practically "the team" that decides internal things (for example, the exact implementation). But what exactly is discussed and decided internally or on another level is also quickly unclear. 

Especially in the setup phase of a project, this leads to problems, delays, quick provisional decisions that may later be regretted - and worse - questioned.

Projects are often in a constant state of flux. Things change. Management, team and stakeholder changes are unfortunate events that occur. 

One tool that has proven itself in my opinion is the "Project Decision Table".

## Project Decision Table

The remedy is as simple as it sounds. It is a relatively primitive spreadsheet. The goal of the table: to log all relevant decisions and put pending decisions on the radar.

Some columns of the table should be:
- Title of the decision
- Date of creation of the entry: provides information about when the topic is on the table
- Creator: provides information about who started the topic
- Description: brief description of what the topic is about.
- Recommendation: this may already be a recommendation from the team or entry creator
- Decider: Can be a concrete person, a team, a department. My recommendation that a concrete person is mentioned anyway!
- Decision date
- Decision description
- Status: Raised, Missing Decision Material, Decided, etc.

Some optional columns could be:
- Options
- Decision number
- Due date
- Stakeholders
- Dependencies: Are there any decisions that need/should be made beforehand.
...

These few characteristics already help to get a clear picture of the decisions of the project. Perspective: historical, current and future.

The properties provide information about the "What?" (Title, Description), "Why? (Description, Decision Description), "Who?" (Initiator, Decision Maker), "When" (Creation Date, Decision Date, Due Date). The decision entry usually does not contain a column for the question "How?". Usually the result of the decision is a first part of a concrete answer.

The table provides a transparent and brief overview of all decisions made in the project. 

Everyone involved in the project should be aware of the existence of this table. The cooperation of all team members and stakeholders is essential. The responsibility for the topicality, status and advancement of the topics and the associated decisions then usually lies with a smaller group, for example the architect, technical lead and product owner.

The question is: Which decisions should be added to the decision table?

## Decision Table on a Sitecore Project

A decision table starting small and growing quickly. However on a Sitecore project some of the decisions you will find are:
Please note this is only an example, there is no requirement for being accurate or complete. 

| Date | Name | Initiator | Description | Recommendation | Status | Decided By | Decision Date| Reason |
|---|---|---|---|---|---|---|---|---|
| 2022/01/01 | Licensing | PO | <ul><li>Do we use XM / XP / XC licenses?</li><li>Do we use SXA, JSS, ...?</li><li>Do we need additional license for framework/tools? TDS, Razl, Docker, ...</li></ul> | Using XM in a Headless setup with JSS. For local setup we need Docker licenses for every developer. | `RAISED` | EA | ? ||
| 2022/01/01	| Hosting | ITS |<ul><li>Do we host the solution on IaaS, PaaS, PaaS (Containerized), SaaS?</li><li>Which hosting provider we choose? Azure, AWS, ... </li></ul>|The recommendation from the team is going with PaaS because the team is already familiar with this kind of solutions. But they are also open to try out using a containerized approach. Because the company is already hosting non-project related services on MS Azure. It makes sense to go with Azure.|`RAISED`|ITS|---|---|
|2022/01/01|Environments|TEAM|<ul><li>What kind of environments we will have?</li></ul>|As architect sugguests suggest to have a DEV and TEST environment. In addition there should be a UAT setup similar to the PROD env.|`RAISED`|EA|?|---|
| 2022/01/01 |Environment Scaling|TEAM|<ul><li>What are the vertical and horizontal scaling numbers of the service instances?</li></ul>|DEV and TEST environments will be setuped as small as possible with single service instances no failover or redundancy. UAT should have same scaling of PROD with critical services with redundancy. The production scaling should start with a small setup which will be extended where needed.<ul><li>DEV/TEST: 1 Rendring, 1 CM, 1 CD, 1 ID, 1 Redis, 1 Solr</li><li>UAT/PROD: 2 Rendering, 1 CM, 2 CD, 1 ID, 1 Redis, 1 Solr</li></ul>|`IN PROGRESS`|EA|---|---|
|2022/01/01|Headless|SA|<ul><li>Are we following a Headless or Traditional approach?</li></ul>|Because the client is planning to feed several websites, mobile apps and other channels with the content of the Sitecore CMS we recommend the headless approach. |`DECIDED`|EA|---|---|
|2022/01/01|Headless Tech Stack|SA|Sitecore allows different headless approaches on rendering instances: Next.js / Vue.js / React.js / .NET Core / Custom|---|---|EA|---|---|
|2022/01/01|Next.js vs React|EA|Why should we use Next.js instead of React? Are there benefits?|We are already using Vue and React frameworks in other projects so far. |`OPEN`|EA|---|After explaining of SA about the benefits of Next.js and its special advantages for our projects. EA decided to use Next.js. Especially the benefits of using SSG rendering was one essential argument for using it.|
|2022/01/01|Git Repository|SA|Which git repository do we use?|The team could use the Azure DevOps Git repository.|`DECIDED`|EA|---|The EA decided to use the enterprise used git repository hosted on BitBucket instead. So that all source code is stored on the same system.|
|2022/01/01|Documentation|PO|How and where do we document?|Coding documentation is done in code and markdown files (md). The editors get a user manual about configuration in a Word document shared on onedrive. The developer documentation in top is added to the Azure DevOps wiki.|`DECIDED`|PO|---|The PO decided to do it like described in the recommendation.|
|2022/01/01|Testing|PO|<ul><li>What testing strategies we apply to the project?</li><li>Testing frameworks used?</li></ul>|Using dedicated test engineers which execute manual and automated testings. The automated tests are based on Selenium framework. Unit tests are created by developers itself, when they see a need for it. We do not force a test coverage!|---|---|---|---|
|2022/01/01|WYSISYG Editors|SA|Sitecore XM/XP comes with two editors. Which of the ones editor will use? `Horizon / Experience Editor`|Because horizon is using a dedicated service/server instance and the featureset of horizon is still behind the EE the recommendation is to use EE. The usage of Horizon could potentially be decided at any time.|`REVIEW`|PO|---|The application is expected to run in EE.|
|2022/01/01|Object Mapping|BE|Sitecore can use Object Mapping Frameworks for dealing with Items in custom solution code.<ul><li>Do we wanna use a Object Mapper?</li><li>Which framework we wanna use? Synthesis, GlassMapper, ...</li></ul>|The each project team member is familiar with a different tools. So we believe we can not benefit from a specific framework because of experience. We would not plan to start with a OM tool because of missing setup time for it.|`OPEN`|TEAM|---|We are using no OM framework. See recommendation.|
|2022/01/01|Item Serialization|TEAM|Some Sitecore item data should be part of the deployment and be under source versioning control. There are several tools available for that: `Unicorn / SCS / TDS`|Because SCS is the new OOtB framework for doing this the team want to give it a try even if it is not holing the same feature set of the other tools. The team is also seeing a benefit in no need deploying the data to destination instances anymore, instead using remote push process.|`OPEN`|EA|---|The EA decided to follow the recommendation and using SCS.|
|2022/01/01|Dependency Injection Framework|TEAM|In .NET multiple option of DI frameworks can be used.|Microsoft Dependency Injection frames is recommended, because its already used by Sitecore itself and in the nearest product on the tech stack without introducing new vendors.|`DECIDED`|SA|---|With the agreement of EA and the Team the decision to use MS framework is done.|
|2022/01/01|Local Development Setup Docker|TEAM|Does the team use a local installation or local docker setup?|Sitecore is recommending in new solution to take docker setup even if the solution is not hosted in containers.|`DECIDED`|SA|---|Decided to go with Local Docker Setup because of Sitecore Best Practices!|
|2022/01/01|Component Model consumption|BE|Sitecore Headless Services allowes to get component data by:<ul><li>GraphQL</li><li>ContentResolvers</li></ul>Is there a generall approach to choose?|OpenGraph is the new and prefered way to consume requested data. However some PoC investigations showed that we had stability issues, and enhanced efforts by creating and using GraphQL. To provide a fast and easy way we would suggest using ContentResolver approach.|`DECIDED`|SA|---|Because of the outcome of the PoC, SA decided to go with ContentResolver approach.|
|2022/01/01|Storybook|FE|Storybook is a UI component explorer. Make it possible to develop and inspect frontend components before they are implemented and connected to the CMS. FE believe this would improve our development process to use it.|he development team wants to use the framework because of improvement of demo review meetings.|`DECIDED`|SA|---|The project is using Storybook to have a preview of all implemented components without CMS connectivity.|
|2022/01/01|Theming|PO|Does the sites of needs be be themable.|There are no requirements yet to invest efforts into this topic.|`DECIDED`|PO|---|PO agree that there are no plans for the current or further site to have theming capabilities. Means use same design or having a dedicated one.|
|2022/01/01|Multisite Strategy|SA|<ul><li>Do we will have multiple sites consuming and sharing something?</li><li>Do we need separated content trees for different websites?</li></ul>|The recommendation is to plan, concept and implement everting multisite functional. For this reason we will introduce from skretch a second site.|`IN PROGRESS`|PO|---|The PO decided on statements from the management that we should be prepared for raising multisites but concentrate on delivering the current site. If there are missing stuff, the stakeholders are aware on additional efforts.|
|2022/01/01|CDN|PO|Do we use/need CDN?|	CDN is always a good option but also comes with costs and complexity. Because we are not expecting to deliver I high amount of static assets we suggest to not start with CDN implementation before having a solution testable for its needs.|`DECIDED`|EA|---|EA. The discussion is closed for the moment. Till we invest in performance improvements.|
|2022/01/01|GDPR|CISO|What kind of data is stored, where how|Create documentation about the data storage and the processes needed to fulfill the GDPR. This can be reviewed from Security Department.|`IN PROGRESS`|---|---|---|
|2022/01/01|Publishing Strategy|SA|<ul><li>Should manual publishing be used</li><li>Do we use some Auto Publishing with Workflows</li></ul>|Use manual publish and setup an auto publish if critical time critical publication have to be made. A periodical publish can be configured.|`DECIDED`|---|---|We use workflows on page with an auto publishing triggered on hourly bases.|
|2022/01/01|Editor Workflows|SA|Do editors need to follow some workflows.|There are no workflows applied by default. Default workflow could look like: Draft, Review, Approved|`DECIDED`|---|---|Using the default workflow process for pages only.|
|2022/01/01|Accessibility|SA|What doings are made for accessibility?|An accessibility concept with the outcoming doings should be created.|`IN REVIEW`|---|---|---|
|2022/01/01|CI/CD|DOE|How the CI/CD configuration should look like for the envs?|We recommend to trigger a nightly build on the main "develop" branch and deploy this to a dev environment. Feature branches should trigger a build. TEST, UAT and PROD deployments should only be triggered manually.|`DECIDED`|TEAM|---|Agreement with the recommendation. |
|2022/01/01|Releasing Strategy|DOE|Are there special needs for numbering and release processes?|---|---|---|---|---|
|2022/01/01|Session Management|SA|Do we need Session and where are Sessions stored.|The default is using a Redis instance. But there are options for in proc and SQL based session management.|`DECIDED`|---|---|Using the default redis session handling.|
|2022/01/01|Forms|PO|How can we support form capabilities?|There is a form generator usable by Editors. But Testing and Adaptations are expected. The concrete requirements must be defined and implementation need to take place. Complex and non-changing forms can also handled by custom form implementation.|`IN REVIEW`|---|---|---|
|2022/01/01|Alerting|PO|What kind of alerting we should configure?|We can use Application Insights and configure alertings rules for different scenarios.|`IN PROGRESS`|---|---|---|
|2022/01/01|Logging|SA|We need centralized logging, how can we archieve?|Configure all services to log into Application Insights.Define a logging message pattern.|---|---|---|---|
|2022/01/01|Content Migration Strategy|DOE|How do we migrate data from one env to another? For example testing purposes?|Content related data can be individually taken from PROD to other environements (as long there is no customer and/or sensitive data) by Sitecore Package Manager and Install Wizard. There could also DB backups prepared with correction scripts related to environment.|OPEN|---|---|---|
|---|---|---|---|---|---|---|---|---|


There is usually enough space below the table for further comments and details of a specific topic! Or links to related detail pages can be added in addition.

In general all kind of question that could raise up now or later from outside the team should find some place in the table. Internal decision made in the team could be placed somewhere else.

Such a table can give new onboarding collegues a very quick introduction into the project. It will prevent unnecessary questions to you and protect the project from resurgent meanings and question about topics and decisions already done. This does not mean a decision can not be reverted. But everyone should be clear that this is a change and not a mistake by any person. It's also a very good entry point at demo and sprint reviews to include the stakeholders in the overall questions and problems you are solving next to to direct implementation of the solution.

I hope this article gave you some insights and idea about how a decision table can help you maybe in future projects.
---
title:  "Sitecore Usergroup Germany - Virtual Meeting February 2022"
date:   2022-02-14 12:00:00 +0100
categories:
- CMS
- Sitecore
tags:
- Sitecore-CDP
- OrderCloud
author: cmeiselbach
---
![alt text](../files/2022/02/sugde-virtualmeeting-0222.jpg "SUGDE Virtual Meeting February 2022")

In 2022, Sitecore events started for me on February 10th with the 3rd virtual meeting of the [Sitecore Usergroup Germany (SUGDE)](https://www.sitecore-usergroup.de/). This time with a smaller number of topics, but the ones that were presented were really in-depth and complex.

## Topics

* Sitecore OrderCloud - An Introduction by Friederike Heinze from comspace GmbH & Co. KG
* A first look into Sitecore CDP by Katharina Luger from Merkle Germany GmbH

## Sitecore OrderCloud - An Introduction
Friederike ([Blog](https://blog.comspace.de/author/friederike/), [Twitter](https://twitter.com/ilovesitecore)) presented us with one of the newest additions to the Sitecore world: [OrderCloud](https://ordercloud.io/). The product comes from the Minneapolis company Four51 and was bought by Sitecore in March 2021. It is used by large and highly distributed businesses and brands like 3M, AT&T, Ford, Starbucks, and Subway. Overall, currently mainly for US-customers and their specific market needs.

### Platform overview

OrderCloud is a next-generation E-commerce platform, mainly made for B2B but also for B2C and "B2X" (Business to Exchange, where target groups are flexible).

Designed as a "MACH" architecture, which stands for:

* Microservices
* API-first
* Cloud-native (SaaS)
* Headless

OrderCloud, built on the [MACH architecture](https://www.sitecore.com/blog/headless/what-is-mach-architecture), is highly customizable and balanced for a high number of product configurations and target groups. "API-first" was named here, but as Friederike suggested, it feels more like "API-only".

![alt text](../files/2022/02/ordercloud-platform-overview.png "Sitecore OrderCloud Platform Overview (Screenshot taken from ordercloud.com)")

### API-first, Connectors

Since OrderCloud is API-first, there is an Open API specification for the use of one of the SDKs or straight by your own preferred development stack. It's also coming with an JavaScript SDK which can be integrated in your Angular-, Node-, React- or Vue-based application.

Connecting 3rd-party services such as CRM, Image Hubs, or ERP is something that needs to be done on your own. Currently, there are no installation-ready connectors available, which might be the case in the future.

### Features

These core features are the most important ones:

* Order Management where you can manage multiple sites, stores, brands with automated workflows for every order-step.
* E-commerce platform which is powerful for merchandising, pricing, order administration, search, cart and checkout-process, customer profiles and personalized promotions.
* B2B Marketplace connects buyers to goods and services from any variety of suppliers or vendors.

In a typical B2C context, you have a seller, a few calogues and customers. With OrderCloud, this is extended to have multiple suppliers, sellers and catalogues.

![alt text](../files/2022/02/ordercloud-platform-overview2.png "Sitecore OrderCloud Supply Chain (Screenshot taken from ordercloud.com)")

There are a bunch of features to be used. For example:

* Buyer and User Group Setups with your business segmentation needs
* Custom Properties for targeting different Personas
* Complex Rule and Workflow Engines for Approvals, Supplier Management, etc.
* Multi-Supplier catalogues
* Product variants that are highly customizable to meet the needs of the customer
* Quotes
* Visibility of Products and Catalogues for Buyer Groups
* Pricing policies & rules, such as price breaks based on quantity ordered
* Fulfillment Automation with Supplier Order Management, Payment methods, Email notification and others.
* Omni-Channel integration where OrderCloud works as a backbone commerce application.
* Extentable via webhooks or events triggered

OrderCloud can be accessed via API clients for both your own and third-party solutions.

![alt text](../files/2022/02/ordercloud-omnichannel-integration.png "Sitecore OrderCloud Omni-Channel-Integration (Screenshot taken from ordercloud.com)")

### Conclusion

Overall, OrderCloud is not a system that you're going to implement for mid-size shops and the typical need, where nearly everything is prepared. It's more of a framework for creating large integrations with multiple services around it. For example, the Portal Dashboard doesn't come with an editor-friendly UI for managing product data, etc. Systems like OrderCloud are mainly used as middleware, product configurations are done in other systems.


## A first look into Sitecore CDP

Also added to Sitecore in March 2021 was [Sitecore CDP](https://www.sitecore.com/knowledge-center/digital-marketing-resources/what-is-a-cdp), coming from the Irish company "Boxever". Katharina presented us with the new Customer Data Platform, which is an extension of our existing marketing tools.

### Customer Data Platform

A CDP is basically a database including behavior and transaction details from customers activities  on different channels, including Web- and E-Commerce-sites. A CDP typically combines data from multiple systems, for example CRM or specific online marketing tools.

It provides customer data insights in real-time and is used for A/B Testing and User Feedback ("Micro Surveys"). It also comes with the capability of machine learning-based algorithms to provide a better targeting of marketing activities.

Sitecore promotes here the "Smart Hub", which stands for

* CDP, brings miscellaneous data silos together.
* Smart, which allows you to leverage your data to predict, test, and optimize every customer interaction across every channel.
* Hub, is to orchestrate the interactions across every digital channel.

![alt text](../files/2022/02/sitecore-cdp-smart-hub.jpg "Sitecore CDP Smart Hub (Screenshot taken from sitecore.com)")

With Sitecore CDP you will be able to deliver the right message at the right time in the right place and create a joined-up, omnichannel experience.

### Sandbox Testing

Sitecore provides a [Sandbox environment](https://app.boxever.com/) for partners where you can easily do some practice and gain knowledge about how it works. Katharina gives a good demonstration of this during her presentation.

Profile data example:

![alt text](../files/2022/02/sitecore-cdp-profile-example.png "Sitecore CDP Profile Example (Screenshot taken from sitecore.com)")

### Integration, API

Sitecore CDP comes with a JavaScript library to integrate into your own sites and channels. It could also be embedded  directly  into your markup, either by server-side scripting or with your Google Tag Manager-account. Tracking is done with first-party cookies like "bid_{your client key}" which persits the browser id between the users sessions.

CDP comes with a REST-API, which allows you to retrieve, update, create or delete data. It is ready to be integrated with several marketing or advertisment clouds, messaging and email solutions, etc.

Use the debug mode for your JS and API testing.

### CDP User Interface

The UI is used to  analyze the data flow and configure the activities.

![alt text](../files/2022/02/sitecore-cdp-ui.png "Sitecore CDP UI (Screenshot taken from https://neilkillen.com/2021/11/07/sitecore-cdp-tips-and-tricks/)")

* Customer data shows what is going on on your website, including guests and segmentation views.
* Experiences allows you to design and implement user interactions and the type of capturing the data.
* Experiments with A/B testing data and configuration
* Decisioning for modelling offers, based on a rule engine. An offer could be a e.g., a promotion code for recurring customers of your site.
* Library with misc templates for your Experiments, Audience / Decisioning-specific views, Flows or Offers.
* Connections to 3rd-party systems, like sending an e-mail

### What is different about Sitecore Analytics?

Analytics is deeply integrated into Sitecore for tracking, A/B testing, and personalization purposes. Since Sitecore CDP is loosely coupled, it can be integrated in all CM systems and not only for Sitecore instances. It is also more flexible with the integration of 3rd-party systems and data exchances. 

CDP extends Sitecore personalized marketing features, including machine learning capabilities.

### Conclusion

The Sitecore Customer Data Platform is truly one of the most interesting additions since it extends the traditional tracking tools. CDP solutions are available from different vendors, and Sitecore is now one of them. The formerly "Boxever" product has a good architecture and seems easy to integrate into your solutions.

Don't forget about digital experience platforms here. While DXP's offer organizations the ability to develop customer relationships on any channel, marketing automation and chatbots, the CDP's segmentation and decisioning capabilities refine the experience, allowing marketers to gain an overview and ensure campaigns are perfectly pitched for their target audience.

## After the show

After presentations were done, a nice quiz was coming up. Lots of questions were asked about past usergroup meetings where you could win a ticket for the upcoming SUGCON Europe conference.

Both presentations by Friederike and Katharina gave us very good insights to the newest additions to Sitecore. Thanks for that.

Big thanks also to the SUGDE organisators for having that good meeting again and see you next time!
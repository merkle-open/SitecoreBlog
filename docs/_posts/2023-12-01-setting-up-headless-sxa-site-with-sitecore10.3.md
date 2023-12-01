---
title:  "Setting up Headless SXA on Sitecore 10.3"
date:   2023-12-01 12:05:33 +0100
categories:
- Sitecore
tags:
- Sitecore
- Sitecore SXA
- Sitecore Headless SXA
author: gsingla
---
---
![alt text](../files/2023/12/01/header.jpg "Header")

Photo by panumas nikhomkhai: https://www.pexels.com/@cookiecutter/ 
  


## Introduction
With release of Sitecore 10.3, Sitecore also released headless version of existing SXA framework. This is based on existing Sitecore headless framework namely JSS. But the process of deployment a headless SXA site is different from normal JSS solution. In this article, we will deal with deployment of headless SXA site to Sitecore 10.3.


### Prerequisite
You should have. 
- Installed <b>Sitecore 10.3</b> with <b>Sitecore PowerShell Extensions</b> and <b>SXA</b> either using Sitecore Install Assistant (SIA) or PowerShell. You can download SIA from [here](https://sitecoredev.azureedge.net/~/media/8F77892C62CB4DC698CB7688E5B6E0D7.ashx?date=20221130T160548).
- Installed latest <b>NodeJS</b> version. My node version was 18.14.2
-	Installed <b>Sitecore Headless Rendering</b> 21.0.0 from [here](https://sitecoredev.azureedge.net/~/media/41619E7443374CA2B64A16FC53306B6C.ashx?date=20221102T124959).

### Setting up Headless Site
-	Open the Sitecore Content Editor and right click on the <b>Content Node</b>, you will see an insert option for a Headless Tenant. Please create a new <b>Headless Tenant</b>.

![alt text](../files/2023/12/01/01-Create-Headless-Tenant.png "Create Headless Tenant")

- After clicking insert new Headless Tenant, a new popup will appear. Please enter a name for the Tenant and select all the modules if unselected. After clicking <b>Ok</b>, it will take some time and create a new Headless Tenant. 

![alt text](../files/2023/12/01/02-Set-Headless-Tenant-Settings.png "Set Headless Tenant Settings")

- After creating a new Headless Tenant, we need to create a new Headless Site. For creating the new Headless Site, please right click on the recently created Headless Tenant and insert a new <b>Headless Site</b>.

![alt text](../files/2023/12/01/03-Create-Headless-Site.png "Create Headless Site")

- After clicking insert Headless Site, a popup will appear. In the <b>General Tab</b>, please enter the new Site Name and keep all the existing settings same. 

![alt text](../files/2023/12/01/04-Set-Headless-Site-General-Settings.png "Set Headless Site General Settings")

- After that, go to <b>Modules tab</b> and click on the Select All and click on the Ok. We don’t need to make any changes in the Site Settings tab.

![alt text](../files/2023/12/01/05-Set-Headless-Site-Modules-Settings.png "Set Headless Site Modules Settings")

- It will take some time to create the Site. It will show the below pop up after creation.

![alt text](../files/2023/12/01/06-Headless-Site-Creation-Successful.png "Headless Site Creation Successful")

- After your Site is created, you will see a new site node in the Tenant with all the created item structure like in non-headless SXA. 

![alt text](../files/2023/12/01/07-New-Headless-SXA-Site.png "New Headless SXA Site")

### Setup Rendering Host

This is the default rendering host setting for the Headless SXA. The location of rendering host lies in Site Template in Settings node of the Site. The Default rendering host can be found on below location.

{% highlight ruby %}
sitecore/system/Settings/Services/Rendering Hosts/Default 
{% endhighlight %}

![alt text](../files/2023/12/01/08-Headless-SXA-Rendering-Host.png "Headless SXA Rendering Host")

Please update the values of the fields for the Default Host as below:
-	Set Server-side rendering engine endpoint URL to - http://localhost:3000/api/editing/render
-	Set Server-side rendering engine application URL to -  http://localhost:3000
-	Set Application name same as your Next.JS app name - demo-app (this is my app name)

![alt text](../files/2023/12/01/09-Headless-SXA-Rendering-Host-Settings.png "Headless SXA Rendering Host Settings")

### Create JSS API Key

We need to create an API key for our headless application. Please navigate to the below location and right click the <b>API Keys folder</b> and insert a new <b>API Key</b>.

{% highlight ruby %}
/sitecore/system/Settings/Services/API Keys
{% endhighlight %}

![alt text](../files/2023/12/01/10-Create-JSS-API-Key.png "Create JSS API Key")

Set the Value of <b>CORS Origin</b> and <b>Allowed Controllers</b> to <b>*</b> We will use the ID of this item as API Key in our JSS application setup later. 

![alt text](../files/2023/12/01/11-Set-JSS-API-Key-Settings.png "Set JSS API Key Settings")

### Creating JSS Application

To create the JSS Application, first we need to install the Sitecore JSS package globally. Please use the below command to install the same.

{% highlight ruby %}
npm install -g @sitecore-jss/sitecore-jss-cli
{% endhighlight %}

After installing the above package, we need to create a new JSS Application with a pre-defined template. Sitecore provides 7 different base templates namely Next.js, react, angular, Vue, react-native, node-headless-ssr-experience-edge and node-headless-ssr-proxy. For this demo, I will use the Next.js template. 
You will need to install Jss and Next.js template before creating a Next.js application. Please run the below command for installing the Next.js template.

{% highlight ruby %}
npm install -g @sitecore-jss/sitecore-jss @sitecore-jss/sitecore-jss-nextjs
{% endhighlight %}

After installing the Next.js template, please use the below command to create an application based on the Next.js template.

{% highlight ruby %}
npx create-sitecore-jss --templates nextjs,nextjs-sxa --appName demo-app --hostName xp103.sc --fetchWith GraphQL
{% endhighlight %}
<b>Note:</b> In the above command, please change the appName and hostName as per your setup.

After running the above command, it will ask several questions, as written below:
###### Where would you like your new app created? 
It will show the default path on the right side as in screenshot below. You can simple press enter to install on the default path or can provide a new path for creating an app.

![alt text](../files/2023/12/01/12-Set-Path-For-New-NextJs-Application.png "Set Path For New NextJs Application")

###### How would you like to prerender your application?
In this question, it will ask to choose prerendering technique whether to choose Static Site Generation (SSG) or Server Side Rendering (SSR). Please choose as per your need.

![alt text](../files/2023/12/01/13-Set-Prerender-Settings-For-New-NextJs-Application.png "Set Prerender Settings For New NextJs Application")

After the above question, it will start installing the npm packages and your app will be created.

![alt text](../files/2023/12/01/14-New-NextJs-Application-Created-Successfully.png "New NextJs Application Created Successfully")

### Setting up JSS Application

After creating the JSS application, you need to make few configurations. Please go to the root folder of your JSS app and run below command.

{% highlight ruby %}
jss setup 
{% endhighlight %}

After running the above command, it will ask you several questions as below:
######  Is your Sitecore instance on this machine or accessible via network share?
In this question, it’s asking if Sitecore instance is installed on your machine or not. Please press y in this case.

![alt text](../files/2023/12/01/15-Is-Sitecore-Instance-Accessible.png "Is Sitecore Instance Accessible")

######  Path to the Sitecore folder (e.g. c:\inetpub\wwwroot\my.siteco.re):
In this question, please provide the path of web root of your Sitecore instance.

![alt text](../files/2023/12/01/16-Webroot-Of-Sitecore-Instance.png "Webroot Of Sitecore Instance")

Sitecore hostname (e.g. http://myapp.local.siteco.re; see /sitecore/config; ensure added to hosts):
In this question, please provide the hostname of your Sitecore instance.

![alt text](../files/2023/12/01/17-Set-Sitecore-Hostname.png "Set Sitecore Hostname")

######  Sitecore import service URL [https://sxa1030sc.dev.local/sitecore/api/jss/import]:
In this question, it will show you default url for import service based on the hostname you provided earlier. Please don’t make any changes and press enter.

![alt text](../files/2023/12/01/18-Set-Sitecore-Import-Service-Url.png "Set Sitecore Import Service Url")

######  Sitecore API Key (ID of API key item):
In this question, please enter the ID of the API Key we created earlier in Sitecore at below location.
/sitecore/system/Settings/Services/API Keys/API Key

![alt text](../files/2023/12/01/19-Set-Sitecore-API-Key.png "Set Sitecore API Key")

######  Please enter your deployment secret (32+ random chars; or press enter to generate one):
In this question, please enter the 32+ random characters deployment secret for your application or you can simply press enter and it will create one for you. I simply pressed enter. This was the last step of the setup process.

![alt text](../files/2023/12/01/20-Set-Deployment-Secret.png "Set Deployment Secret")

After the above steps, we need to do some manual configs. Please follow the same as below

#### Set JSS Config Files
We need to remove default site need from the config file located at the below location as we are managing sites from Sitecore.

{% highlight ruby %}
/demo-app/sitecore/config/demo-app.config
{% endhighlight %}

![alt text](../files/2023/12/01/21-Remove-Site-Node.png "Remove Site Node")

Scroll down the same file and verify the app registration urls.

![alt text](../files/2023/12/01/22-App-Config.png "App Config")

In the above config, update the sitecorePath with the path of your site in the headless tenant. For the above demo, the url is below and it will look like below screenshot.

![alt text](../files/2023/12/01/23-Set-Sitecore-Path-In-App-Config.png "Set Sitecore Path In App Config")

After updating the above path, please scroll down and find the config named <b> JavaScriptServices.ViewEngine.Http.JssEditingSecret </b> and uncomment the same. please go to the adjacent file (demo-app.deploysecret.config for the above demo) for deployment secret and copy the same and update in in the above config. It will look like this below.

![alt text](../files/2023/12/01/24-Set-Sitecore-JSS-Editing-Secret-In-App-Config.png "Set Sitecore JSS Editing Secret In App Config")

After updating the above file, please go to the adjacent file (demo-app.deploysecret.config for the above demo) for deployment secret and copy the same. Please go to .env file at the root of the project and paste the same to <b>JSS_EDITING_SECRET</b>. Copy the API key from Sitecore and paste it to <b>SITECORE_API_KEY</b>. After the above changes, your file will look like below.

![alt text](../files/2023/12/01/25-Set-Environment-Variables.png "Set Environment Variables")

#### Setting Dictionary

Please go to /src/lib/dictionary-service-factory.ts and create a new property named <b>rootItemId</b> at the below location mentioned in the screenshot. The value of rootItemId is the ID of the Home Page of your site in Sitecore. For this particular demo, the path of item is <b>/sitecore/content/DemoHeadlessTenant/DemoSite/Home</b> and it’s ID is <b>{FAF645CE-1A7F-4059-B6FD-1D5E67486D37}</b>

![alt text](../files/2023/12/01/26-Set-Dictionary-Settings.png "Set Dictionary Settings")

#### Deploy the config

After making all the above changes, we need to deploy our changes to the Sitecore instance. Please run the below command to deploy your config changes.

{% highlight ruby %}
 jss deploy config  
{% endhighlight %}

![alt text](../files/2023/12/01/27-Deploy-JSS-Settings.png "Deploy JSS Settings")

The changes will be deployed to below path at your Sitecore Instance.
<b>C:\inetpub\wwwroot\sxa1030sc.dev.local\App_Config\Include\zzz</b>

<b>Note:</b> Sometimes after deployment of config, changes are not reflected, please do an IIS Reset after the deployment and verify your changes in <b>/sitecore/admin/showconfig.aspx</b> and look for the setting named <b>JavaScriptServices.ViewEngine.Http.JssEditingSecret</b>.

![alt text](../files/2023/12/01/28-Verify-JSS-Settings-In-Sitecore-Instance.png "Verify JSS Settings In Sitecore Instance")

### Running the App for First Time

After the deployment of the config files, our app is ready to run for the first time. Please run the below command to run the app in connected mode.

{% highlight ruby %}
jss start:connected
{% endhighlight %}

![alt text](../files/2023/12/01/29-Running-JSS-App-First-Time.png "Running JSS App First Time")

After this, your app will run and you need to open <b>localhost:3000</b>(if this port is not already being used) . There you will see a blank page.

![alt text](../files/2023/12/01/30-Preview-Of-Running-JSS-App.png "Preview Of Running JSS App")

We will go to the content editor and open the Home Page in Experience Editor and will make some changes. I’ll show you my home page after changes.

![alt text](../files/2023/12/01/31-Preview-Of-Running-JSS-App-After-Changes.png "Preview Of Running JSS App After Changes")

### Common Errors

#### Could not resolve dependency next from @sitecore-jss/sitecore-jss-nextjs

While creating an app, this error sometimes stops npm package install. Please use the below command before doing npm install again.

{% highlight ruby %}
npm config set legacy-peer-deps true
{% endhighlight %}

#### TypeError:fetch failed:

![alt text](../files/2023/12/01/32-Error-Fetch-Failed.png "Error Fetch Failed")

To fix this error, please run the below command before running <b>jss start:connected</b>

```Powershell
$env:NODE_TLS_REJECT_UNAUTHORIZED=0
```

#### Unable to verify the first certificate

![alt text](../files/2023/12/01/33-Error-Unable-to-Verify-First-Certificate.png "Unable to Verify First Certificate")

Please follow the article with link [here](https://doc.sitecore.com/xp/en/developers/hd/21/sitecore-headless-development/walkthrough--configuring-sitecore-ca-certificates-for-node-js.html) for the above fixes.

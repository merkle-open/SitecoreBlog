---
title:  "Content security policy in Sitecore Forms"
date:   2023-03-20 12:00:00 +0100
categories:
- Sitecore
- Sitecore Forms
tags:
- Sitecore Forms
- Content security policy
- CSP
- CSP header
author: rjung
---
![alt text](../files/2023/03/fly-d-mT7lXZPjk7U-unsplash.jpg "Security")

Photo by <a href="https://unsplash.com/@flyd2069?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">FLY:D</a> on <a href="https://unsplash.com/photos/mT7lXZPjk7U?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText">Unsplash</a>
  

The content security policy (CSP) header is really easy to set in Sitecore. Everything works fine except one little thing in Sitecore Forms. The "Redirect to page" submit action is blocked by CSP-header if you do not allow inline scripts in your configuration. 

Then you will see the following error report in your console:

```
Refused to execute inline script because it violates the following Content Security Policy directive: "script-src 'self' 'unsafe-eval' ...". Either the 'unsafe-inline' keyword, a hash ('sha256-K7mFe7R5wGASfSl42vZtlDAx0iP7vw++bHuVWihIUIE='), or a nonce ('nonce-...') is required to enable inline execution.
```

Unfortunately, out of the box, there is no possibility to avoid the CSP report. It is also not possible to set a nonce value to the script, because the code which outputs the inline script snippet is packed in the assemblies of Sitecore.
  
To solve the problem, there are two ways worth a look:

## 1. Add 'unsafe-inline' to CSP header

First and easiest way to handle the problem will be to include 'unsafe-inline' in script-src directive for the whole page. But this is not the ideal solution, because just pages with Sitecore Forms components on it need to allow inline scripts to be executed. Every other page has no need to allow inline scripts to be executed. Next to that, it could be a potencial security risk to allow the execution of inline scripts on every page. 

But there will be another way to handle the problem, without adding the value 'unsafe-inline' on every page:

## 2. Add 'unsafe-inline' to CSP header just where it is needed

After some studies, we decided to set an identifier in the HttpContext, if a Sitecore Forms component is set on the page. With that, we now are able to identify pages with Sitecore Forms components and re-set the content security header, including 'unsafe-inline', on the Application_EndRequest, which can be found in global.asax file.

But now hands on the code snippets:

First we have to set an identifier in the HttpContext, that the Application_EndRequest can react to it and set the needed directive. This is done by adding an item to the current HttpContext in the main view of Sitecore Forms, the Form.cshtml.

### Form View (Form.cshtml)
```C#
var ctx = HttpContext.Current;
ctx.Items["Forms.Component.Active"] = "1";
```

Now we have our identifier "Forms.Component.Active" on which the Application_EndRequest can react on. In global.asax file, it is now really easy to set the needed directive just if a Sitecore Forms component is set on the page.
For example, we can now set our CSP-header with 'unsafe-inline' in script-src directive.

### Application_EndRequest (global.asax)
```C#
if ("1".Equals(HttpContext.Current?.Items["Forms.Component.Active"]))
{
	Response.Headers.Remove("Content-Security-Policy");
	Response.Headers.Add("Content-Security-Policy", [yourCspConfiguration]);			
}
```

With that we ensure to set 'unsafe-inline' only on pages which contain components (e.g. Sitecore Forms) that require execution of inline-scripts. In every other page without Sitecore Forms components, the content security policy header is not touched at all.


## Summary

In this post, we showed two different approaches how to handle content security policy header in Sitecore Forms. The first and easiest approach adds the value 'unsafe-inline' to script-src directive on every page, which could be a potential security risk. The second approach adds the value just to pages, where Sitecore Forms components are rendered.


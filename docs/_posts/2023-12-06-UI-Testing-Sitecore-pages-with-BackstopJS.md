---
title:  "UI Testing Sitecore pages with BackstopJS"
date:   2023-12-04 16:00:00 +0100
categories:
- Sitecore
- DevOps
- Testing
tags:
- Sitecore
- DevOps
author: ryilmaz
---
![alt text](../files/2023/12/04/header.jpg "Header")

Photo by <a href="https://www.pexels.com/@pixabay/">Pixabay</a> on <a href="https://www.pexels.com/photo/abstract-bright-close-up-color-268460">Pexels</a>

## Introduction
Since we occasionally had the case that some pages no longer looked quite as they should after deployment, we looked for a solution that would help us recognize such errors at an early stage. This is how we came across BackstopJS, which saves us a lot of time and effort.

## Usage of BackstopJS
BackstopJS runs through a predefined list of pages on a website, takes screenshots, and compares these screenshots to highlight any changes. It can be run locally and can be easily integrated into a pipeline.

## Installation
Open a command prompt and type the following command, to install BackstopJS globally:

{% highlight ruby %}
npm install -g backstopjs
{% endhighlight %}

After installing, you have to close your command prompt and reopen it, so you can use the ```backstop``` commands.

## Initialization
First, you have to initialize Backstop. This command will create all the files you need for the test run later.
{% highlight ruby %}
backstop init
{% endhighlight %}

## Adding pages
The pages are configured in the generated ```backstop.json``` file. You can add your pages as ```scenarios``` in that JSON file. It is also advisable to adjust the ```delay``` to give the tool some time before the screenshot is taken so that the page with images has loaded completely.

{% highlight json %}
"scenarios": [
    {
      "label": "Merkle DACH Homepage en",
      "cookiePath": "backstop_data/engine_scripts/cookies.json",
      "url": "https://www.merkle.com/dach/en",
      "referenceUrl": "",
      "readyEvent": "",
      "readySelector": "",
      "delay": 300,
      "hideSelectors": [],
      "removeSelectors": [],
      "hoverSelector": "",
      "clickSelector": "",
      "postInteractionWait": 0,
      "selectors": [],
      "selectorExpansion": true,
      "expect": 0,
      "misMatchThreshold" : 0.1,
      "requireSameDimensions": true
    },
    {
      "label": "Merkle DACH Homepage de",
      "cookiePath": "backstop_data/engine_scripts/cookies.json",
      "url": "https://www.merkle.com/dach/de",
      "referenceUrl": "",
      "readyEvent": "",
      "readySelector": "",
      "delay": 300,
      "hideSelectors": [],
      "removeSelectors": [],
      "hoverSelector": "",
      "clickSelector": "",
      "postInteractionWait": 0,
      "selectors": [],
      "selectorExpansion": true,
      "expect": 0,
      "misMatchThreshold" : 0.1,
      "requireSameDimensions": true
    }
{% endhighlight %}

## Cookies configuration
Most websites have a cookie-consent overlay that blocks large parts of the page. To prevent this from appearing on the screenshots, there is the ```cookies.json``` file, which was generated under the path ```.\backstop_data\engine_scripts``` by the Init command. Update the file with the cookie values of your test page.

{% highlight json %}
[
  {
    "domain": "www.merkle.com",
    "path": "/",
    "name": "OptanonAlertBoxClosed",
    "value": "2023-12-06T00:00:00.000Z",
    "expirationDate": 1798790400,
    "hostOnly": false,
    "httpOnly": false,
    "secure": false,
    "session": false,
    "sameSite": "Lax"
  }
]
{% endhighlight %}

## Adding a resolution
To test different resolutions and thus devices, you can create as many entries as you like in the ```backstop.json``` file under the ```viewports``` array.

{% highlight json %}
"viewports": [
    {
      "label": "phone",
      "width": 320,
      "height": 480
    },
    {
      "label": "tablet",
      "width": 1024,
      "height": 768
    },
    {
      "label": "desktop",
      "width": 1920,
      "height": 1080
    }
  ],
{% endhighlight %}

## Initial run
You need to make an initial run so that you have screenshots for later comparison.

{% highlight ruby %}
backstop test
{% endhighlight %}

This creates a folder with the screenshots under ```.\backstop_data\bitmaps_test```

## Approve
After the screenshots have been taken, the status must be approved and used as a reference for the subsequent screenshots.

{% highlight ruby %}
backstop approve
{% endhighlight %}

## Test run
With a new ```test``` command, the previously created screenshots are compared with new ones and an analysis is made.

{% highlight ruby %}
backstop test
{% endhighlight %}

## Interactive test report
After the test has been run, the ```index.html``` from ```.\backstop_data\html_report``` is opened and the results are visible. 

![alt text](../files/2023/12/06/01-test-results.png "Test Results")

1) 4 tests passed
2) 2 tests have failed
3) First defined entry "Merkle DACH Homepage en" with "phone" resolution
4) Green bar for passed tests
5) Red bar for failed tests
6) Diff with errors marked (click on it)

![alt text](../files/2023/12/06/02-diff.png "Diff")
The magenta colored areas show the difference between the screenshots. In this case, the dots were slightly shifted and can be ignored.

## Integration to Azure Pipelines
TODO

## Conclusion
In our experience, there are often false positives, so the tool should not be used as a 100% reliable test tool. Nevertheless, it saves a lot of testing effort if several dozen pages are checked automatically and only those from the error messages need to be checked manually.

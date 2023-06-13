---
title: "Batch-Modification of Sitecore Items"
date: 2023-06-14 16:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Sitecore XP
author: mklimmasch
---
![alt text](../files/2023/06/13/natalia-y-Oxl_KBNqxGA-unsplash.jpg "Gray assorted-letter jewelries in brown wooden organizer boxes")

Foto from [Natalia Y.](https://unsplash.com/photos/Oxl_KBNqxGA?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText) on [Unsplash](https://unsplash.com/photos/Oxl_KBNqxGA?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText)
  


## Batch-modification of Sitecore Items
The batch-modification feature of Sitecore items has been around for a while and is probably one of the most useful, least documented features in Sitecore. I have seen a lot of workarounds using code or the Sitecore powershell extensions, but for many uses cases this out-of-the-box-feature is enough.

## What can I do with this?
One of the drawbacks of the Sitecore content editor is that you cannot select multiple items at once, so tasks like moving multiple subitems can be cumbersome. The functionality that I am about to show is made exactly for cases like this. The feature set is a bit limited, but I think it covers a lot of ground.

### Most useful functionality
        
* Add tag
* Delete multiple items
* Move multiple items
* Publish multiple items
* Apply profile score to multiple items
* Search and replace text within items

## How do I use this?

The feature is well hidden behind the search functionality under the inconspicuous name _Search Operations_. To find it, mark an item and select the magnifying glass next to the Content tab.

![alt text](../files/2023/06/13/01%20Open%20Search.png "Screenshot: How to open the search")

In the _Search_ tab, use the filters to narrow down the search results to the items you want to modify. A good point to start is probably the item template type. Note how this field gives you quite some support in the form of autosuggestion. __Be aware that the search works recursively__, so you can easily modify all items in a given hierarchy.

![alt text](../files/2023/06/13/02%20Search%20Input.png "Screenshot: Define the search criteria")

Hit enter to see the results and verify you only selected the items you want. Note that there is paging, so make absolutely sure you have not selected more items than desired. 

![alt text](../files/2023/06/13/03%20Search%20completed.png "Screenshot: How a search result looks like")

Once you are sure we selected the right items, you can open the search operations using the small dropdown next to the search query. Look at the operations and take a minute to understand what they all do.

![alt text](../files/2023/06/13/04%20Find%20Search%20Operations.png "Screenshot: How to execute the Search Operations")

### Moving items

Let us start with moving all the items to another folder. A dialog opens where you can select a target. Choose a target item and click _Move_.

![alt text](../files/2023/06/13/05%20Move%20Items.png "Screenshot: Move items")

The items are moved to the new location.

![alt text](../files/2023/06/13/06%20Moved%20items.png "Screenshot: Moved items")

### Replacing text

Another great feature is the replacement of text in all fields of items recursively. Check out the _before state_ and note that there is text to be replaced.

![alt text](../files/2023/06/13/07%20Replace%20Text%20Original.png "Screenshot: Example of text to be replaced")

Apply the same steps to get to the Search Operations, then choose the option _Search and replace_. In the new window, replace the text before the _pipe_ (|) with the text you want to find and after the pipe with the text you want to replace it with. In my case that translates to

    that should be replaced|that has been replaced


![alt text](../files/2023/06/13/08%20Replacement%20dialog.png "Screenshot: Replacement dialog")

After the functionality ran, a success message is shown 

![alt text](../files/2023/06/13/09%20Replacement%20complete.png "Screenshot: Replacement success message")

and the text is replaced.

![alt text](../files/2023/06/13/10%20Replacement%20Result.png "Screenshot: Replacement result")

__Note: Make sure that you do not have one of the impacted items selected, otherwise the replacement stops without any feedback.__

## Where to go from here?
Equipped with this tool, there are a few tasks that get significantly easier. The use cases where I personally found this feature extremely useful are:
* Cleaning up the structure of the media library
* Deleting duplicate content
* Introducing gender-neutral pronouns
* Moving datasource items between pages
* Applying default profile scores to an area of a website, before customizing it further
* Applying campaign attributes to landing pages

### Some issues that I found

* Sitecore does not allow you to execute search actions when the search criteria are empty\
You can simply use a search for the asterisk to circumvent this limitation.
* Sitecore does not allow you to assign goals in the Search operations\
It allows you to set campaigns and page events though; I can only speculate that Sitecore does not think it is a good idea to assign business-relevant goals in a batch-process

### Customizing Search Operations

This functionality can also be easily extended. As a starting point, check out the commands starting with _bucket:_ in the configuration and the items under _/sitecore/system/Settings/Buckets/Settings/Search Operations_ in the Sitecore Core database.

![alt text](../files/2023/06/13/11%20Search%20Operations%20Configuration.png "Screenshot: Search operations configurations")

## Conclusion

The Sitecore Search operations feature is very helpful in a few otherwise tedious tasks. There are many of Sitecore users out there who do not know about it and waste precious time by manually moving items or even developing scripts to mimic this functionality.

All advantages aside, keep in mind that batch-modifying items can also mean batch-breaking them... always keep in mind: _With great power comes great responsibility_.
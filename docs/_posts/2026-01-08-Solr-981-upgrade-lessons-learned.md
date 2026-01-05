---
title: "Solr 9.8.1 Upgrade – Lessons Learned"
date: 2026-01-05 10:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Sitecore 10.3.3
- Sitecore 10.4.1
- Sitecore XP
- Solr
author: hlueneburg
---
![alt text](../files/2026/01/wesley-tingey-snNHKZ-mGfE-unsplash.jpg "four stacks of more or less sorted documents with sticky notes")

Foto [Wesley Tingey](https://unsplash.com/de/@wesleyphotography) on [Unsplash](https://unsplash.com/de/fotos/stapel-bucher-auf-dem-tisch-snNHKZ-mGfE?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText)

We recently upgraded our XP solution from **10.3.1** to **10.3.3** to support the **Solr 9.8.1** upgrade. \
Version 9.8.1 was released on **March 6, 2025**. The previous version has reached **EOL** and is no longer listed on _apache.org_.

## Our initial plan

We assumed the upgrade would be straightforward:

1. Download Solr
2. Convert the .tgz to a .zip (to install it with the SIF)
3. Install on a new port
4. Create cores
5. Update Solr connectionstring in Sitecore
6. Deploy schema
7. Recreate index
8. Done

## The issue

When deploying the schema for **master_index**, we encountered this error:

```html
<lst name="responseHeader">
  <int name="status">400</int>
  <int name="QTime">0</int>
</lst>
<lst name="error">
  <lst name="metadata">
    <str name="error-class">org.apache.solr.common.SolrException</str>
    <str name="root-error-class">org.apache.solr.common.SolrException</str>
  </lst>
  <str name="msg">Current core has 2048 fields, exceeding the max-fields limit of 2000.  </str>
  <int name="code">400</int>
</lst>
```

This was unexpected — the upgrade seemed simple at first.

## Backgroud

Starting with Solr **version 9**, they introduced a limit on the number of fields per core ([see documentation](https://solr.apache.org/docs/9_8_1/core/org/apache/solr/update/processor/NumFieldLimitingUpdateRequestProcessorFactory.html)).

This setting is defined in the `solrconfig.xml` of each core: `{SolrInstallPath}\server\solr\{prefix}_master_index\conf`

## Solution

Update the configuration to a suitable value, for example:

```xml
  <updateProcessor class="solr.NumFieldLimitingUpdateRequestProcessorFactory" name="max-fields">
    <int name="maxFields">3000</int>
    <bool name="warnOnly">true</bool>
  </updateProcessor>
```

- Restart Solr
- Deploy the schema again
- If the error persists, increase maxFields and repeat the steps

**Tip:** Start with a high value (e.g., 50,000) and adjust later based on actual requirements.

## How to determine the required value

Solr does not provide this information directly. Here’s how we found it:

1. Open the Solr admin UI
2. Navigate to the schema page for the core (`/solr/#/{prefix}_master_index/schema`)
3. Inspect the page source and search for `data-option-array-index`
4. Use the highest index value as a reference

If you know a better or simpler method, please share!

## SIF integration

To avoid manual changes, we extended the SIF configuration:

- Added a new variable: `"Solr.MaxFieldsValue.BigValue": 15000`
- Updated the logic in `UpdateMaxFieldsValue` for relevant indexes (master, web, and inherited ones)

## Helpful Links

- [Solr 9.8.1 Release](https://archive.apache.org/dist/solr/solr/9.8.1/)
- [Sitecore Experience Platform 10.3 Update-3](https://developers.sitecore.com/downloads/Sitecore_Experience_Platform/103/Sitecore_Experience_Platform_103_Update3)
- [Sitecore Experience Platform 10.4 Update-1](https://developers.sitecore.com/downloads/Sitecore_Experience_Platform/104/Sitecore_Experience_Platform_104_Update1)

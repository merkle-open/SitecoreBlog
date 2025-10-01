---
title: "Sitecore slow indexing"
date: 2025-10-01 08:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Solr
- Indexing
author: aklein
---

Sitecore Slow Indexing Speed
Recently, I needed to reinstall a Sitecore project solution I had worked on in the past. The custom setup and application were quite complex, involving many steps beyond simply checking out and building the solution.

Finally, I reached my Sitecore localhost test URL in the browser, expecting the site to appear. Unfortunately, it didn’t work.

I recalled that the site was heavily dependent on Solr indexes—particularly two custom indexes in addition to the sitecore_master_index and sitecore_web_index. So I began investigating the indexes by:

* Repopulating the schema to Solr (this worked well)
* Starting the index rebuilds (surprisingly slow)

I remembered that the solution’s indexing had been extended significantly with various customizations. I wasn’t sure if I was misremembering the indexing performance or if it had always been this slow.

I started disabling customizations such as computed fields and custom field type registrations. The result: no improvement. I also debugged and investigated further but didn’t uncover anything new.

Why were Solr indexes—configured identically and running on the same Solr instance—indexing at different speeds?

After mentally reviewing all the involved resources and categorizing them as:

* Exactly the same
* Theoretically the same with minor differences (e.g., different names)
* Truly different

I concluded that I needed to check the databases. This was especially relevant because the two problematic indexes were both tied to the web database.

As a Sitecore developer, you naturally consider the differences between the master and web databases from a content perspective. Typically, the web database contains only published data, making it smaller and faster to index.

So I checked something I rarely examine as a Sitecore engineer: the **SQL database table indexes**.

When I looked into the master database’s Items and Fields tables, the index sizes appeared normal. However, the corresponding tables in the web database were empty or nearly empty—clearly incorrect.

**I proceeded to rebuild the SQL table indexes: Right-click <your table> → Indexes → Right-click “Rebuild All”**

Seconds later, the index sizes looked promising.

A Sitecore index rebuild confirmed that the indexing process was now hundreds of times faster. Instead of the status counter increasing one by one every second, it resumed its natural behavior—jumping in steps of 100+.

Although I’m not sure how the database indexes were lost (perhaps due to a restore or other process), I’m glad I identified the issue in an area I usually don’t need to worry about as a Sitecore engineer.

**So, if you encounter similar behavior, be sure to check your SQL table indexes!**
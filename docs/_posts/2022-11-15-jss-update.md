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

# Sitecore - Update Sitecore Next.js JSS solution from 19.0.2 to 20.0.3

For the first time, nothing stands in the way of updating to a newer JSS version, in case that the version is supported by the Sitecore XM/XP version.
In the case of 19.0.2 to 20.0.3, this is the case. However, for the first time, a plan belongs to every Sitecore update.

## Expected plan:
- Check the changelog of Sitecore: https://github.com/Sitecore/jss/blob/dev/CHANGELOG.md
- Scaffolding of a new Next.js app on most recent version. For later comparision.
- Creating a folder with a feature update GIT branch. Here we make our first update attempts and can compare the differences directly with the current branch folder.
- Expected doings
  - Backend: Sitecore XM/XP solution
    - Local Docker setup: Change the JSS base docker images used by chaning the package in your .env config
     - Local Installation setup: Change/Install the Headless Packages downloaded from the Sitecore download page
- Frontend: Next.js app
  - Update the package.json relevant version numbers
  - Clear node_modules and run npm install
  - Compare with a tools the changes introduced by the new scaffolding setup
    - New files in new setup => usually take to your solution
    - Deleted files => delete them but check on customizations and migrate them to maybe renamed files at another location
    -Changed files => Determine which is cleverer: use new file and apply your customizations or take your file and adapt changes from new version
  - Do manual changes where needed
- DevOps:
  - Check Pipelines for usage of needed node.js / npm versions
  - Adaptations to pipelines to use the newer Headless Package Versions or Docker Base images
- Testing, Testing, Testing: If you can profit from existing test automation, do this!

## Execution:
Finding out that the scaffolding has changed
- `npm install -g @sitecore-jss/sitecore-jss-cli`
- `npm init sitecore-jss nextjs`

Create update branch in own folder

Changes to Sitecore XM/XP

In the .env file, set up the JSS docker images variables.
- Update COMPOSE_PROJECT_NAME => <current>-update (to create own images and not overwrite existing)
- Update NODEJS_VERSION= eg: 14.5.6 => 16.15.0
- Update JSS_VERSION= eg: 19.0.0.00508.330-10.0.19042.1288-20H2 => 20.0.1-20H2
- execute a new docker-compose build to get new images

Changes to Next.js frontend solution

Change package.json 

- Update Package numbers
  - Node (>=8.1 => >=12)
  - NPM (>=5.6.0 => >=6)
  - next (^11.0.1 => ^12.1.0)
  - sitecore-jss-cli (^19.0.2 => ^20.0.3)
  - sitecore-jss-dev-tools (^19.0.2 => ^20.0.3)
  - sitecore-jss-manifest (^19.0.2 => ^20.0.3)
  - sitecore-jss-nextjs (^19.0.2 => ^20.0.3)
- Update added plugin package
  - sitecore-jss-forms (^20.0.1 => ^20.0.3)
  - sitecore-jss-react-forms (^20.0.1 => ^20.0.3)
  - sitecore-jss-tracking (^19.0.2 => ^19.0.2)

Detect and fix changes to files by comparing them (list not 100% accurate)
-	`scripts/bootstrap.ts`
-	`scripts/disconnected-mode-proxy.ts`
-	`scripts/generate-plugins.ts`
-	`scripts/utils.ts`
-	`sitecore/definitions/component-content.sitecore.ts`
-	`sitecore/definitions/content.sitecore.ts`
-	`sitecore/definitions/dictionary.sitecore.ts`
-	`sitecore/definitions/component-content.sitecore.ts`
-	`sitecore/definitions/placeholders.sitecore.ts`
-	`sitecore/definitions/routes.sitecore.ts`
-	`components/AppRoot/Layout.tsx`
-	`lib/component-props/index.ts`
-	`lib/dictionary-service-factory.ts`
-	`lib/layout-service-factory.ts`
-	`lib/page-props.ts`
-	`lib/page-props-factory.ts`
-	`lib/page-props-factory/*`
-	`pages/[[...path]].tsx`

The main manual changes in my case were mainly related to Sitecore's refactoring of the PageProps and ComponentProps.

The SitecoreContext was slightly modified and the layout.tsx now consumes a "layoutData" instead of a "sitecoreContext". 

Eventually update packages dependencies: 

`npm audit fix (–force)`

Build all and start the solution.

Test the solution


---
title: "NuGet-Packages used by Sitecore 10.3 XP"
date: 2023-05-23 16:00:00 +0100
categories:
- Sitecore
- nuget
tags:
- Sitecore
- Sitecore 10.3
- Sitecore XP
author: hlueneburg
---
![alt text](../files/2023/05/23/mak-8wy9mGgmGoU-unsplash.jpg "Packages")

Foto von [Mak](https://unsplash.com/ja/@mak_jp?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText) auf [Unsplash](https://unsplash.com/de/fotos/8wy9mGgmGoU?utm_source=unsplash&utm_medium=referral&utm_content=creditCopyText)

Nearly everyone gets into the situation when you have to customize some functionality of Sitecore. Often you have to include assemblies, which are used by Sitecore to provide specific functionality. And usually Visual Studio is not very helpful in telling you which nuget-package is the right one to add. Sometimes it is difficult to find the corresponsing nuget-package for a specific assembly.

With one of our migration to Sitecore 10.3 we found some updates on some dependencies of Sitecore-assemblies. \
The following list will show you the assembly-version of the assemblies which come with Sitecore 10.3 and the version of the newest package available. If there is no information available, it is marked with ?. \
There are also listed some deprecated or unlisted packages.

## Advise

When you only use a part of the assemblies in your own code, stick to the version of Sitecore. Otherwise, you must upgrade all packages, which depends on them.

### Example

- If you update only _System.Web.Mvc_ to a newer version than __5.2.4__ Sitecore might works but will most likely have an unusable UI.
- _HtmlAgilityPack_ can be upgraded without problems.

## Assembly-list

The following list was created on 23.05.2023 for Sitecore 10.3 XP.

assembly | assembly version | source | current nuget version
--- | --- | --- | ---
Antlr3.Runtime | 3.4.1.9004 | <https://www.nuget.org/packages/Antlr> | 3.5.0.2
ChilkatDotNet48 | 9.5.0.89 | <https://www.chilkatsoft.com/downloads_DotNet.asp> | 9.5.0.94
CommonServiceLocator | 2.0.3.0 | <https://www.nuget.org/packages/CommonServiceLocator> | 2.0.7.0
CommonServiceLocator.SolrNet | 1.0.19.0 | <https://www.nuget.org/packages/SolrNet> | 1.1.1
ComponentArt.Web.UI | 2010.1.2637.35 | <https://marketplace.visualstudio.com/items?itemName=ComponentArt.ComponentArtUIFrameworkforNET> | down
DocumentFormat.OpenXml | 2.7.2.0 | <https://www.nuget.org/packages/DocumentFormat.OpenXml> | 2.20.0
EcmaScript.NET | 1.0.1.0 | <https://www.nuget.org/packages/EcmaScript.Net> | 2.0.0
FiftyOne.Caching | 4.4.1 | <https://www.nuget.org/packages/FiftyOne.Caching> | 4.4.4
FiftyOne.Common | 4.4.1 | <https://www.nuget.org/packages/FiftyOne.Common> | 4.4.3
FiftyOne.DeviceDetection.Cloud | 4.4.8 | <https://www.nuget.org/packages/FiftyOne.DeviceDetection.Cloud> | 4.4.23
FiftyOne.DeviceDetection | 4.4.8 | <https://www.nuget.org/packages/FiftyOne.DeviceDetection> | 4.4.23
FiftyOne.DeviceDetection.Hash.Engine.OnPremise | 4.4.8 | <https://www.nuget.org/packages/FiftyOne.DeviceDetection.Hash.Engine.OnPremise> | 4.4.23
FiftyOne.DeviceDetection.Hash.Engine.OnPremise.Native | ? | ? | ?
FiftyOne.DeviceDetection.Shared | 4.4.8 | <https://www.nuget.org/packages/FiftyOne.DeviceDetection.Shared> | 4.4.23
FiftyOne.Foundation | 3.2.17.2 | ? | ?
FiftyOne.Pipeline.CloudRequestEngine | 4.4.4 | <https://www.nuget.org/packages/FiftyOne.Pipeline.CloudRequestEngine> | 4.4.15
FiftyOne.Pipeline.Core | 4.4.4 | <https://www.nuget.org/packages/FiftyOne.Pipeline.Core> | 4.4.15
FiftyOne.Pipeline.Engines | 4.4.4 | <https://www.nuget.org/packages/FiftyOne.Pipeline.Engines> | 4.4.15
FiftyOne.Pipeline.Engines.FiftyOne | 4.4.4 | <https://www.nuget.org/packages/FiftyOne.Pipeline.Engines.FiftyOne> | 4.4.15
GreenDonut | 10.5.5.0 | <https://www.nuget.org/packages/GreenDonut> | 13.1.0
HotChocolate.Abstractions | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Abstractions/> | 13.1.0
HotChocolate.AspNetClassic.Abstractions | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.Abstractions> | 10.5.5
HotChocolate.AspNetClassic.Authorization | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.Authorization> | 10.5.5
HotChocolate.AspNetClassic | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic> | 10.5.5
HotChocolate.AspNetClassic.HttpGet | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.HttpGet> | 10.5.5
HotChocolate.AspNetClassic.HttpGetSchema | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.HttpGetSchema> | 10.5.5
HotChocolate.AspNetClassic.HttpPost | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.HttpPost> | 10.5.5
HotChocolate.AspNetClassic.Playground | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.AspNetClassic.Playground> | 10.5.5 / deprecated, critical bugs
HotChocolate.Core | 10.5.5.0 | ? | ?
HotChocolate.Language | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Language> | 13.1.0
HotChocolate.Server | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Server> | 10.5.5
HotChocolate.Subscriptions | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Subscriptions> | 13.1.0
HotChocolate.Subscriptions.InMemory | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Subscriptions.InMemory> | 13.1.0
HotChocolate.Subscriptions.Redis | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Subscriptions.Redis> | 13.1.0
HotChocolate.Types | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Types> | 13.1.0
HotChocolate.Utilities | 10.5.5.0 | <https://www.nuget.org/packages/HotChocolate.Utilities> | 13.1.0
HtmlAgilityPack | 1.4.9.5 | <https://www.nuget.org/packages/HtmlAgilityPack> | 1.11.46
ICSharpCode.SharpZipLib | 1.3.2.10 | <https://www.nuget.org/packages/SharpZipLib> | 1.4.2
IdentityModel | 3.10.10.0 | <https://www.nuget.org/packages/IdentityModel> | 6.1.0
MarkdownSharp | 1.14.5.0 | <https://www.nuget.org/packages/MarkdownSharp> | 2.0.5
Microsoft.AspNet.Identity.Core | 2.2.1 | <https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core> | 2.2.3
Microsoft.AspNet.Identity.Owin | 2.2.1 | <https://www.nuget.org/packages/Microsoft.AspNet.Identity.Owin> | 2.2.3
Microsoft.AspNet.OData | 7.5.9 | <https://www.nuget.org/packages/Microsoft.AspNet.OData> | 7.6.5
Microsoft.AspNet.SessionState.SessionStateModule | 1.1.20502.0 | <https://www.nuget.org/packages/Microsoft.AspNet.SessionState.SessionStateModule> | 1.1.0
Microsoft.AspNet.WebApi.Extensions.Compression.Server | 2.0.3 | <https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Extensions.Compression.Server> | 2.0.6
Microsoft.AspNetCore.Hosting.Abstractions | 2.2.0 | <https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions> | 2.2.0 / deprecated
Microsoft.AspNetCore.Hosting.Server.Abstractions | 2.2.0 | <https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Server.Abstractions> | 2.2.0 / deprecated
Microsoft.AspNetCore.Http.Abstractions | 2.2.0 | <https://www.nuget.org/packages/Microsoft.AspNetCore.Http.Abstractions> | 2.2.0 / deprecated
Microsoft.AspNetCore.Http.Features | 2.2.0 | <https://www.nuget.org/packages/Microsoft.AspNetCore.Http.Features> | 5.0.17 / deprecated
Microsoft.Azure.Amqp | 2.2.0 | <https://www.nuget.org/packages/Microsoft.Azure.Amqp> | 2.6.2
Microsoft.Azure.ServiceBus | 4.100.220.15305 | <https://www.nuget.org/packages/Microsoft.Azure.ServiceBus> | 5.2.0 / deprecated
Microsoft.Azure.Services.AppAuthentication | 1.3.1.0 | <https://www.nuget.org/packages/Microsoft.Azure.Services.AppAuthentication> | 1.6.2 / deprecated, unlisted
Microsoft.Bcl.AsyncInterfaces | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Bcl.AsyncInterfaces> | 7.0.0
Microsoft.Configuration.ConfigurationBuilders.Base | 1.0.30709.0 | <https://www.nuget.org/packages/Microsoft.Configuration.ConfigurationBuilders.Base> | 3.0.0
Microsoft.Configuration.ConfigurationBuilders.Environment | 1.0.30709.0 | <https://www.nuget.org/packages/Microsoft.Configuration.ConfigurationBuilders.Environment> | 3.0.0
Microsoft.Extensions.Caching.Abstractions | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Caching.Abstractions> | 7.0.0
Microsoft.Extensions.Caching.Memory | 6.0.222.6406 | <https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory> | 7.0.0
Microsoft.Extensions.Configuration.Abstractions | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions> | 7.0.0
Microsoft.Extensions.Configuration.Binder | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder> | 7.0.4
Microsoft.Extensions.Configuration.CommandLine | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.CommandLine> | 7.0.0
Microsoft.Extensions.Configuration | 6.0.322.12309 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration> | 7.0.0
Microsoft.Extensions.Configuration.EnvironmentVariables | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables> | 7.0.0
Microsoft.Extensions.Configuration.FileExtensions | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions> | 7.0.0
Microsoft.Extensions.Configuration.Ini | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Ini> | 7.0.0
Microsoft.Extensions.Configuration.Json | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json> | 7.0.0
Microsoft.Extensions.Configuration.Xml | 2.2.0.18315 | <https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Xml> | 7.0.0
Microsoft.Extensions.DependencyInjection.Abstractions | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions> | 7.0.0
Microsoft.Extensions.DependencyInjection | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection> | 7.0.0
Microsoft.Extensions.DependencyModel | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.DependencyModel> | 7.0.0
Microsoft.Extensions.DiagnosticAdapter | 2.1.0.18136 | <https://www.nuget.org/packages/Microsoft.Extensions.DiagnosticAdapter> | 3.1.32
Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions | 6.0.21.52608 | <https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions> | 7.0.5
Microsoft.Extensions.FileProviders.Abstractions | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Abstractions> | 7.0.0
Microsoft.Extensions.FileProviders.Physical | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Physical> | 7.0.0
Microsoft.Extensions.FileSystemGlobbing | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing> | 7.0.0
Microsoft.Extensions.Hosting.Abstractions | 2.2.0.18316 | <https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Abstractions> | 7.0.0
Microsoft.Extensions.Logging.Abstractions | 6.0.322.12309 | <https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions> | 7.0.0
Microsoft.Extensions.Logging | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Logging> | 7.0.0
Microsoft.Extensions.ObjectPool | 2.1.0.18136 | <https://www.nuget.org/packages/Microsoft.Extensions.ObjectPool> | 7.0.5
Microsoft.Extensions.Options | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Options> | 7.0.1
Microsoft.Extensions.Primitives | 6.0.21.52210 | <https://www.nuget.org/packages/Microsoft.Extensions.Primitives> | 7.0.0
Microsoft.IdentityModel.Clients.ActiveDirectory | 4.5.0.0 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory> | 5.3.0 / deprecated
Microsoft.IdentityModel.JsonWebTokens | 5.4.0.60123 | <https://www.nuget.org/packages/Microsoft.IdentityModel.JsonWebTokens> | 6.30.1
Microsoft.IdentityModel.Logging | 5.4.0.60123 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Logging> | 6.30.1
Microsoft.IdentityModel.Protocols | 5.3.0.51005 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Protocols> | 6.30.1
Microsoft.IdentityModel.Protocols.OpenIdConnect | 5.3.0.51005 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Protocols.OpenIdConnect> | 6.30.1
Microsoft.IdentityModel.Protocols.WsFederation | 5.3.0.51005 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Protocols.WsFederation> | 6.30.1
Microsoft.IdentityModel.Tokens | 5.4.0.60123 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens> | 6.30.1
Microsoft.IdentityModel.Tokens.Saml | 5.3.0.51005 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens.Saml> | 6.30.1
Microsoft.IdentityModel.Xml | 5.3.0.51005 | <https://www.nuget.org/packages/Microsoft.IdentityModel.Xml> | 6.30.1
Microsoft.OData.Core | 7.9.0.20512 | <https://www.nuget.org/packages/Microsoft.OData.Core> | 7.16.0
Microsoft.OData.Edm | 7.9.0.20512 | <https://www.nuget.org/packages/Microsoft.OData.Edm> | 7.16.0
Microsoft.Owin.Cors | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Cors> | 4.2.2
Microsoft.Owin | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin> | 4.2.2
Microsoft.Owin.FileSystems | 4.0.70213.103 | <https://www.nuget.org/packages/Microsoft.Owin.FileSystems> | 4.2.2
Microsoft.Owin.Host.SystemWeb | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb> | 4.2.2
Microsoft.Owin.Security.ActiveDirectory | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security.ActiveDirectory> | 4.2.2
Microsoft.Owin.Security.Cookies | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security.Cookies> | 4.2.2
Microsoft.Owin.Security | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security> | 4.2.2
Microsoft.Owin.Security.Jwt | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security.Jwt> | 4.2.2
Microsoft.Owin.Security.OAuth | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security.OAuth> | 4.2.2
Microsoft.Owin.Security.OpenIdConnect | 4.200.222.26002 | <https://www.nuget.org/packages/Microsoft.Owin.Security.OpenIdConnect> | 4.2.2
Microsoft.Owin.StaticFiles | 4.0.70213.103 | <https://www.nuget.org/packages/Microsoft.Owin.StaticFiles> | 4.2.2
Microsoft.Practices.EnterpriseLibrary.Common | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.Common> | 6.0.1304
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling.Caching | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling.Caching> | 6.0.1304 / deprecated
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling.Configuration | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling.Configuration> | 6.0.1304
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling.Data | 6.0.1304.1 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling.Data> | 6.0.1304.1
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling> | 6.0.1304
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling.ServiceBus | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling.ServiceBus> | 6.0.1304 / deprecated
Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling.WindowsAzure.Storage | 6.0.1304.0 | <https://www.nuget.org/packages/EnterpriseLibrary.TransientFaultHandling.WindowsAzure.Storage> | 6.0.1304
Microsoft.Spatial | 7.9.0.20512 | <https://www.nuget.org/packages/Microsoft.Spatial> | 7.16.0
Microsoft.Web.Infrastructure | 1.0.20105.407 | <https://www.nuget.org/packages/Microsoft.Web.Infrastructure> | 2.0.0
Mvp.Xml | 2.3.0.0 | <https://www.nuget.org/packages/Mvp.Xml> | 3.0.0
Newtonsoft.Json | 13.0.1.25517 | <https://www.nuget.org/packages/Newtonsoft.Json> | 13.0.3
Owin | 1.0 | <https://www.nuget.org/packages/Owin> | 1.0.0
PdfSharp.Charting | 1.50.4740.0 | <https://www.nuget.org/packages/PdfSharpCore.PdfSharp.Charting/> | 1.50.0-beta5-3
PdfSharp | 1.50.4740.0 | <https://www.nuget.org/packages/PdfSharpCore.PdfSharp> | 1.50.0-beta5-5
Pipelines.Sockets.Unofficial | 2.2.2.34088 | <https://www.nuget.org/packages/Pipelines.Sockets.Unofficial> | 2.2.8
Polly | 6.1.2.0 | <https://www.nuget.org/packages/Polly> | 7.2.3
protobuf-net | 2.0.0.668 | <https://www.nuget.org/packages/protobuf-net> | 3.2.16
RazorGenerator.Mvc | 2.0.0.0 | <https://www.nuget.org/packages/RazorGenerator.Mvc> | 2.4.9
Rebus.AzureServiceBus | 7.1.3.0 | <https://www.nuget.org/packages/Rebus.AzureServiceBus> | 9.3.5
Rebus | 6.2.1.0 | <https://www.nuget.org/packages/Rebus> | 7.1.0
Rebus.SqlServer | 6.1.2.0 | <https://www.nuget.org/packages/Rebus.SqlServer> | 7.3.1
Remotion.Linq | 2.2.0.30000 | <https://www.nuget.org/packages/Remotion.Linq> | 2.2.0
SolrNet | 1.0.19.0 | <https://www.nuget.org/packages/SolrNet> | 1.1.1
StackExchange.Redis | 2.5.43.42402 | <https://www.nuget.org/packages/StackExchange.Redis> | 2.6.111
System.Buffers | 4.6.28619.01 | <https://www.nuget.org/packages/System.Buffers> | 4.5.1
System.Collections.Immutable | 4.700.20.21406 | <https://www.nuget.org/packages/System.Collections.Immutable> | 7.0.0
System.ComponentModel.Annotations | 4.6.26515.06 | <https://www.nuget.org/packages/System.ComponentModel.Annotations> | 5.0.0 / deprecated
System.Configuration.ConfigurationManager | 4.6.26515.06 | <https://www.nuget.org/packages/System.Configuration.ConfigurationManager> | 7.0.0
System.Data.SqlClient | 4.700.20.6702 | <https://www.nuget.org/packages/System.Data.SqlClient> | 4.8.5
System.Diagnostics.DiagnosticSource | 6.0.21.52210 | <https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource> | 7.0.2
System.Diagnostics.PerformanceCounter | 5.0.20.51904 | <https://www.nuget.org/packages/System.Diagnostics.PerformanceCounter> | 7.0.0
System.IdentityModel.Tokens.Jwt | 5.4.0.60123 | <https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt> | 6.30.1
System.Interactive.Async | 4.0.0.2 | <https://www.nuget.org/packages/System.Interactive.Async> | 6.0.1
System.Interactive.Async.Providers | 4.0.0.2 | <https://www.nuget.org/packages/System.Interactive.Async.Providers> | 6.0.1
System.IO | 4.6.24705.01 | <https://www.nuget.org/packages/System.IO> | 4.3.0 (4.6.24705.01)
System.IO.FileSystem.Primitives | 1.0.24212.01 | <https://www.nuget.org/packages/System.IO.FileSystem.Primitives> | 4.3.0
System.IO.Packaging | 1.0.24212.01 | <https://www.nuget.org/packages/System.IO.Packaging> | 7.0.0
System.IO.Pipelines | 5.0.120.57516 | <https://www.nuget.org/packages/System.IO.Pipelines> | 7.0.0
System.Linq.Async | 4.0.0.2 | <https://www.nuget.org/packages/System.Linq.Async> | 6.0.1
System.Linq.Async.Queryable | 4.0.0.2 | <https://www.nuget.org/packages/System.Linq.Async.Queryable> | 6.0.1
System.Memory | 4.6.28619.01 | <https://www.nuget.org/packages/System.Memory> | 4.5.5
System.Net.Http.Extensions.Compression.Core | 2.0.3 | <https://www.nuget.org/packages/System.Net.Http.Extensions.Compression.Client> | 2.0.5
System.Net.Http.Formatting | 5.2.60510.0 | <https://www.nuget.org/packages/System.Net.Http.Formatting> | 4.0.20710 / unlisted
System.Net.WebSockets.Client | 1.0.25920.05 | <https://www.nuget.org/packages/System.Net.WebSockets.Client> | 4.3.2
System.Net.WebSockets | 1.0.24212.01 | <https://www.nuget.org/packages/System.Net.WebSockets> | 4.3.0
System.Numerics.Vectors | 4.6.26515.06 | <https://www.nuget.org/packages/System.Numerics.Vectors> | 4.5.0
System.Runtime.CompilerServices.Unsafe | 6.0.21.52210 | <https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe> | 6.0.0
System.Runtime | 4.6.24705.01 | <https://www.nuget.org/packages/System.Runtime> | 4.3.1
System.Runtime.InteropServices.RuntimeInformation | 4.6.24705.01 | <https://www.nuget.org/packages/System.Runtime.InteropServices.RuntimeInformation> | 4.3.0
System.Runtime.Serialization.Primitives | 1.0.24212.01 | <https://www.nuget.org/packages/System.Runtime.Serialization.Primitives> | 4.3.0
System.Security.AccessControl | 4.6.26515.06 | <https://www.nuget.org/packages/System.Security.AccessControl> | 6.0.0
System.Security.Cryptography.Encoding | 4.6.24705.01 | <https://www.nuget.org/packages/System.Security.Cryptography.Encoding> | 4.3.0
System.Security.Cryptography.Primitives | 4.6.24705.01 | <https://www.nuget.org/packages/System.Security.Cryptography.Primitives> | 4.3.0
System.Security.Cryptography.X509Certificates | 1.0.24212.01 | <https://www.nuget.org/packages/System.Security.Cryptography.X509Certificates> | 4.3.2
System.Security.Cryptography.Xml | 4.6.26515.06 | <https://www.nuget.org/packages/System.Security.Cryptography.Xml> | 7.0.1
System.Security.Permissions | 4.6.26515.06 | <https://www.nuget.org/packages/System.Security.Permissions> | 7.0.0
System.Security.Principal.Windows | 4.6.26515.06 | <https://www.nuget.org/packages/System.Security.Principal.Windows> | 5.0.0
System.Text.Encodings.Web | 6.0.21.52210 | <https://www.nuget.org/packages/System.Text.Encodings.Web> | 7.0.0
System.Text.Json | 6.0.21.52210 | <https://www.nuget.org/packages/System.Text.Json> | 7.0.2
System.Threading.Channels | 5.0.20.51904 | <https://www.nuget.org/packages/System.Threading.Channels> | 7.0.0
System.Threading.Tasks.Extensions | 4.6.28619.01 | <https://www.nuget.org/packages/System.Threading.Tasks.Extensions> | 4.5.4
System.ValueTuple | 4.6.26515.06 | <https://www.nuget.org/packages/System.ValueTuple> | 4.5.0
System.Web.Cors | 5.2.60510.0 | <https://www.nuget.org/packages/System.Web.Cors> | ?
System.Web.Helpers | 3.0.60201.0 | <https://www.nuget.org/packages/System.Web.Helpers> | ?
System.Web.Http.Cors | 5.2.60510.0 | <https://www.nuget.org/packages/System.Web.Http.Cors> | ?
System.Web.Http | 5.2.60510.0 | <https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Core/> | 5.2.9
System.Web.Http.WebHost | 5.2.60510.0 | <https://www.nuget.org/packages/Microsoft.AspNet.WebApi.WebHost> | 5.2.9
System.Web.Mvc | 5.2.60201.0 | <https://www.nuget.org/packages/Microsoft.AspNet.Mvc> | 5.2.9 (NEVER UPDATE to a newer version than 5.2.4)
System.Web.Optimization | 1.1.40211.0 | <https://www.nuget.org/packages/Microsoft.AspNet.Web.Optimization> | 1.1.3
System.Web.Razor | 3.0.60201.0 | <https://www.nuget.org/packages/Microsoft.AspNet.Razor> | 3.2.9
System.Web.WebPages.Deployment | 3.0.60201.0 | <https://www.nuget.org/packages/Microsoft.AspNet.WebPages> | 3.2.9
System.Web.WebPages | 3.0.60201.0 | <https://www.nuget.org/packages/Microsoft.AspNet.WebPages> | 3.2.9
System.Web.WebPages.Razor | 3.0.60201.0 | <https://www.nuget.org/packages/Microsoft.AspNet.WebPages> | 3.2.9
Telerik.Web.Design | 2020.3.1021.45 | ? | ?
Telerik.Web.Device.Detection | 2020.3.1021.45 | ? | ?
Telerik.Web.UI | 2020.3.1021.45 | ? | ?
Telerik.Web.UI.Skins | 2020.3.1021.45 | ? | ?
WebActivatorEx | 2.0.3 | <https://www.nuget.org/packages/WebActivatorEx> | 2.2.0
WebGrease | 1.5.2.14234 | <https://www.nuget.org/packages/WebGrease> | 1.6.0
Yahoo.Yui.Compressor | 2.7.0.0 | <https://www.nuget.org/packages/Yahoo.Yui.Compressor> | 3.0.0 / unlisted

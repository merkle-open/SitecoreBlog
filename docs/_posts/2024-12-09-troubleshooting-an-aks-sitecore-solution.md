---
title:  "Troubleshooting an AKS Sitecore solution"
date:   2024-11-29 12:00:00 +0100
categories:
- Sitecore
tags:
- Sitecore
- Kubernetes
- AKS
- Docker
- Azure
author: ryilmaz
---

![Kubernetes](../files/2024/12/09/kubernetes.jpg "Kubernetes")

# Introduction
With a Kubernetes solution such as AKS, it is easier to scale the application according to your needs and simpler to deploy. However, troubleshooting is more difficult and requires different tools than with an app service solution.

# Tooling


## OpenLens
OpenLens is a GUI tool to manage Kubernetes clusters, without the need of extensive command line usage.

https://github.com/MuhammedKalkan/OpenLens/releases

### Pod Menu Extension 
With version 6.3.0, the Node / Pod Menu with the useful functionalities attach, shell and logs were removed from OpenLens.

![MissingPodMenu](../files/2024/12/09/missing-pod-menu.png "Missing pod menu")

To bring it back, you can add the POD Menu Extension from [this repository](https://github.com/alebcay/openlens-node-pod-menu).

![PodMenu](../files/2024/12/09/pod-menu.png "Pod menu")

## Alternatives
Currently OpenLens is the tool I use, but since the project is no longer being maintained, there are alternative open source tools that I may use in the future. They are very similar, free, open source and actively in development, here are some examples:

* [K9s](https://github.com/derailed/k9s)
* [Jet Pilot](https://github.com/unxsist/jet-pilot)
* [Seabird](https://github.com/getseabird/seabird)



Photo by <a href="https://unsplash.com/@growtika?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Growtika</a> on <a href="https://unsplash.com/photos/a-group-of-blue-boxes-ZfVyuV8l7WU?utm_content=creditCopyText&utm_medium=referral&utm_source=unsplash">Unsplash</a>
      
---
title:  "Failed to pull Sitecore images on AKS"
date:   2021-02-09 19:00 +0100
categories:
- DevOps
tags:
- AKS
- Kubernetes
- Docker
- Windows
author: fgeiger
---
Last week I tried to spin up my first Sitecore instance on AKS. During the process I ran into the problem that the init jobs weren't able to pull images from Sitecore's container registry. Both pods (mssql-init and solr-init) logged the following error:

> Failed to pull image "scr.sitecore.com/sxp/sitecore-xp1-solr-init:10.0-ltsc2019": rpc error: code = Unknown desc = Error response from daemon: Get https://scr.sitecore.com/v2/: x509: certificate signed by unknown authority

On the local machine this message normally means that your Docker is running in Linux container mode. Switching to Windows container mode fixes the problem. If you see this error on AKS then it probably means that the init jobs run on the Linux node. There are two potential options how to fix this problem.

## Option 1: Node selector

Add a [node selector](https://kubernetes.io/docs/concepts/scheduling-eviction/assign-pod-node/#nodeselector) to the init yaml files. This node selector ensures that the init pods get created on Windows nodes only:

{% highlight yaml %}
spec:
  template:
    spec:
      nodeSelector:
        kubernetes.io/os: windows
{% endhighlight %}

Thanks to Mihály Árvai for pointing out this solution.

## Option 2: Drain Linux node

If the first option didn't work for you then try to [drain](https://kubernetes.io/docs/tasks/administer-cluster/safely-drain-node/) the Linux node before running the init jobs. This makes sure that no new pods get created on the Linux node.

{% highlight powershell %}
kubectl drain <Linux node name>
{% endhighlight %}

Afterwards you can apply the init jobs again as described in the "Installation Guide for Production Environment with Kubernetes":

{% highlight powershell %}
kubectl apply -f ./init/
{% endhighlight %}

When both pods ´mssql-init´ and ´solr-init´ are in state "Completed" you can resume the Linux node again (multiple pods might get created before that due to errors):

{% highlight powershell %}
kubectl uncordon <Linux node name>
{% endhighlight %}
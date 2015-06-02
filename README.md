##Entelect.Core [![Build status](https://teamcity.entelect.co.za:8443/app/rest/builds/buildType:(EntelectCoreC_FullDeployment)/statusIcon)](https://teamcity.entelect.co.za:8443/app/rest/builds/buildType:(EntelectCoreC_FullDeployment)/statusIcon)

##What is it?

Core .net libraries used by [Entelect](http://www.entelect.co.za)

##How To Use

Install via [NuGet](https://www.nuget.org/packages/Entelect/)

Read the [Documentation](http://entelect.github.io/Entelect/)

##How To Contribute

###Setup

Entelect.Core is built using Microsoft Visual Studio.

[Sandcastle Help File Builder](http://shfb.codeplex.com/) is used to generate documentation from XML comments embedded into the source code. All the components needed for Sandcastle can be easily installed using this [Guided Installer](http://www.ewoodruff.us/shfbdocs/html/8c0c97d0-c968-4c15-9fe9-e8f3a443c50a.htm). Once downloaded, unzip and run the SandcastleInstaller.exe. You will be guided through the installation process and prompted to install the various components. You do **NOT** have to install the **_microsoft help 2 compiler_**. Restart your PC after installation.

###Documentation

All code should be well documented using [embedded XML comments](http://msdn.microsoft.com/en-us/library/b2s063f7.aspx).

The documentation is generated from these comments using Sandcastle. To build the documentation from visual studio, open the **Entelect.sln**, right click on the **Entelect.Documentation** project and select build.

To view the documentation, browse to **~\docs\Help\\** and open the **index.html** file in your browser of choice.

###Testing
All code should be supported by unit tests. Unit tests can be found in the **Entelect.Tests** project. **NUnit** is the testing framework of choice.

###Continious Integration
Teamcity is used as a build and test runner for both the master and develop branches.

###Suggested Tools

* Visual Studio 2012 or higher
* [Markdown Pad 2](http://markdownpad.com/) for editing the readme.md


<a name="readme-top"></a>
<!--
*** Thanks for checking out the dotnet-core-api project. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->


<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/jaymistry4/dotnet-core-api">
    <img src="https://raw.githubusercontent.com/othneildrew/Best-README-Template/master/images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">A simple, cross platform, modularized API system built on Microsoft .NET 7</h3>

  <p align="center">
    An awesome .net 7 template to jumpstart your projects!
    <br />
    <a href="https://github.com/jaymistry4/dotnet-core-api"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="http://jaymistry4-001-site3.gtempurl.com/" target="_blank">View Demo</a>
  </p>
</div>

[![Build Status](https://travis-ci.com/jaymistry4/dotnet-core-api.svg?branch=master)](https://travis-ci.com/jaymistry4/dotnet-core-api)


<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#features">Features</a></li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#steps-to-run">Steps to run</a></li>
      </ul>
    </li>
    <li><a href="#release-history">Release History</a></li>
    <li><a href="#contributors">Contributors</a></li>
</li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

Asp Dot Net Core Web and API project with multiple features.

### Built With

Microsoft .NET 7

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Features

* Microsoft .NET 7
* Mongodb Database
* MS SQL Database
* API Pagination
* Entity framework
* Code first
* Rate Limiting
* Swagger (Library: Swashbuckle.AspNetCore 5.3.3)
* Integration test (In memory, Actual database)
* Unit test case with In Memory Database
* Unit test case with Xunit
* JWT token - Authorization Policy (Security Bearer Token)
* Custom exception handling middleware (Global error handling)
* Logger with NLog library
* Cross Origin Request policy
* Generic response for all the API calls


 Example of generic api response:
 
 {
  "message": null,
  "didError": true,
  "errorMessage": "There was an internal error, please contact to technical support.",
  "model": null,
  "pageSize": 10,
  "pageNumber": 1,
  "itemsCount": 0,
  "pageCount": 1
}

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

##### 1. Visual Studio 2022 or Visual Studio Code
##### 2. SQL Server
##### 3. Microsoft .NET 7 
##### 4. Mongodb Database
Link for .Net 7 download (https://dotnet.microsoft.com/download)

- Change the xml documentation path.

Visual studio -> View menu -> DotNetCore.API properties -> Build -> Output -> XML documentation file: -> Here change the path of XML documentation

Current XML documentation path is: "bin\Debug\DotNetCore.API.xml"

- Microsoft SQL Script

Folder: dotnet-core-api\DotNetCore.API\wwwroot\Database Script
Script Name: WideWorldImporters.sql

- Connecting Mongodb Server

Open file "appsettings.json" at the location: dotnet-core-api\DotNetCore.API\

Change the connection string value of "ConnectionBook" and "Connection" property.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


### Steps to run

- Update the connection string in "appsettings.json" file in DotNetCore.API project
- Restore packages
- Build the whole solution
- In Solution Explorer, make sure that DotNetCore.API is selected as the Startup Project
- Create database, name it "WideWorldImporters"
- Perform Migration or Use SQL script (WideWorldImporters.sql) to setup tables in database
- In Visual Studio, press "Control + F5" or Run the program using command line

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Release History

> ### v0.2.0 (24-Sep-2022)
> 
> ##### New features:
> 
> - [#1](https://github.com/jaymistry4/dotnet-core-api/tree/DotNet7) .Net 7 version upgrade.
> - [#2](https://github.com/jaymistry4/dotnet-core-api/tree/DotNet7) Encryption Decryption api added.

> ### v0.1.2 (02-Sep-2022)
> 
> ##### New feature:
> 
> - [#1](https://github.com/jaymistry4/dotnet-core-api/tree/RateLimiting) Rate Limiting added.


> ### v0.1.1 (01-Sep-2022)
> 
> ##### New features:
> 
> - [#1](https://github.com/jaymistry4/dotnet-core-api/tree/MongoDB) Mongodb Database connection added.

> ### v0.1.0 (26-July-2022)
> 
> ##### New features:
> 
> - [#1](https://github.com/jaymistry4/dotnet-core-api/tree/DotNet6) .Net 6 version upgrade.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## Contributors

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="https://github.com/jaymistry4"><img src="https://res.cloudinary.com/gujaratisamajmatrimony/image/upload/v1626961317/gsm/jay_mistry.jpg" width="100px;" alt=""/><br /><sub><b>Jay Mistry</b></sub></a><br /><a href="https://github.com/jaymistry4" title="Bug reports">🐛</a> <a href="https://github.com/jaymistry4" title="Code">💻</a> <a href="https://github.com/jaymistry4" title="Documentation">📖</a></td>
  </tr>
</table>

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->

<!-- ALL-CONTRIBUTORS-LIST:END -->
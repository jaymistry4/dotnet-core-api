
# A simple, cross platform, modularized API system built on Microsoft .NET 5

[![Build Status](https://travis-ci.com/jaymistry4/dotnet-core-api.svg?branch=master)](https://travis-ci.com/jaymistry4/dotnet-core-api)

## Asp Dot Net Core Web and API project with multiple features.

* Microsoft .NET 5
* API Pagination
* Entity framework
* Code first
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

-------


## Prerequisites

#### 1. Visual Studio 2019 or Visual Studio Code
#### 2. SQL Server
#### 3. Microsoft .NET 5 
Link for .Net 5 download (https://dotnet.microsoft.com/download)

- Change the xml documentation path.

Visual studio -> View menu -> DotNetCore.API properties -> Build -> Output -> XML documentation file: -> Here change the path of XML documentation

Current XML documentation path is: "bin\Debug\DotNetCore.API.xml"

- Microsoft SQL Script

Folder: dotnet-core-api\DotNetCore.API\wwwroot\Database Script
Script Name: WideWorldImporters.sql

#### Steps to run

- Update the connection string in "appsettings.json" file in DotNetCore.API project
- Restore packages
- Build the whole solution
- In Solution Explorer, make sure that DotNetCore.API is selected as the Startup Project
- Create database, name it "WideWorldImporters"
- Perform Migration or Use SQL script (WideWorldImporters.sql) to setup tables in database
- In Visual Studio, press "Control + F5" or Run the program using command line


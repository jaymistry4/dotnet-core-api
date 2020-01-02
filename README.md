# dotnet-core-api
Asp Dot Net Core Api with multiple features.

* API Pagination
* Entity framework
* Code first
* Swagger
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

Prerequisite

1) Change the xml documentation path.

Visual studio -> View menu -> DotNetCore.API properties -> Build -> Output -> XML documentation file: -> Here change the path of XML documentation

Current XML documentation path is: C:\Users\jmmistry\Documents\DotNetCore.API.xml

Change the user name "jmmistry" to your PC's user name.

Example: C:\Users\[**Your PC's user name **]\Documents\DotNetCore.API.xml

2) MS SQL Script

Folder: dotnet-core-api\DotNetCore.API\wwwroot\Database Script
Script Name: WideWorldImporters.sql




# MyEshop

Welcome to MyEshop application. This is a REST API application with the following endpoints:  
This endpoint will get all products   
>/Product

This endpoint will get product detail by product id   
>/Product/{id}

This endpoint will update description of given product  
>/Product/{id}/description      

Application has two versions. In the v2 version you are able to use pagination in /Product endpoint.
You can use Mock data or data from database (default). For Mock data please use Test configuration.

## Prerequisits
You need only .NET 8 : https://dotnet.microsoft.com/en-us/download/dotnet/8.0

## How to run application
1. Open your preffered IDE (Visual studio, Rider, ...)
2. Change your Connection string in appsettings.Development.json
   __If you want to use data from DB. If you use local DB from Docker from the Helpful tips part, you don't have to change connection string.__
4. Run the migrations by this command:
   
   ```
   dotnet ef database update
   ```
   (more about migrations: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
5. Start your application

## How to run Unit tests
1. Open your preffered IDE (Visual studio, Rider, ...)
2. Click right on the project _MyEshop.Tests_
3. Select _Run Unit Tests_

## Helpful tips
I can recommend to run local DB by docker. 
You can download Docker here: https://www.docker.com/products/docker-desktop/
And then use these scripts for downloading and setup the image and run the container:
if your operation system is Windows:
  ```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Test123456" -p 1433:1433 --name sql2022 --hostname sql2022 -d mcr.microsoft.com/mssql/server:2022-latest
  ```

if your operation system is macOS:
```
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Test123456" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

These commands setup your: server to "localhost", port to "1433", user name to "sa", and password to "Test123456".


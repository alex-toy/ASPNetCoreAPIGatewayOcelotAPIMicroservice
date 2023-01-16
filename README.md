# ASP.Net Core API Gateway - Ocelot API Microservice

Ocelot manipulates the HttpRequest object into a state specified by its configuration until it reaches a request builder middleware where it creates a HttpRequestMessage object which is used to make a request to a downstream service. The middleware that makes the request is the last thing in the Ocelot pipeline. It does not call the next middleware. The response from the downstream service is retrieved as the requests goes back up the Ocelot pipeline. There is a piece of middleware that maps the HttpResponseMessage onto the HttpResponse object and that is returned to the client.

<img src="/pictures/architecture.png" title="architecture"  width="800">

I have achieved this project based off of the bellow youtube course :

https://www.youtube.com/watch?v=ZCJKiwTMTSs&list=PLzewa6pjbr3JQKhB_U_FiuYwQC70i-TyU&index=4

## Docker

### Create project

<img src="/pictures/create_project.png" title="create project"  width="500">

### Publish project

<img src="/pictures/publish_project.png" title="publish project"  width="500">
<img src="/pictures/publish_project2.png" title="publish project"  width="500">
<img src="/pictures/publish_project3.png" title="publish project"  width="500">


## SQL Server Docker

### Container orchestrator support

Choose *Docker compose* and *Linux*

<img src="/pictures/container_orchestrator_support.png" title="container orchestrator support"  width="500">

### Docker compose

<img src="/pictures/app_db.png" title="application running with a sql database"  width="800">



## Web API Microservice with SQL Server Entity Framework Core

### Customer Web API

<img src="/pictures/customer_api.png" title="customer api database"  width="800">
<img src="/pictures/customer_api2.png" title="customer api postman"  width="800">
<img src="/pictures/customer_api3.png" title="customer api postman"  width="800">

### Product Web API

<img src="/pictures/product_api.png" title="product api create"  width="800">
<img src="/pictures/product_api2.png" title="product api get"  width="800">



## Order MongoDB Microservice

### Order Web API

<img src="/pictures/order_api.png" title="order api create"  width="800">
<img src="/pictures/order_api2.png" title="order api get"  width="800">



## Ocelot API Microservice

### Customer Web API

<img src="/pictures/ocelot_customer_api.png" title="ocelot customer api"  width="800">
<img src="/pictures/ocelot_customer_api2.png" title="ocelot customer api"  width="800">
<img src="/pictures/ocelot_customer_api3.png" title="ocelot customer api"  width="800">

### Product Web API

<img src="/pictures/ocelot_product_api.png" title="ocelot product api"  width="800">
<img src="/pictures/ocelot_product_api2.png" title="ocelot product api"  width="800">

### Order Web API

<img src="/pictures/ocelot_order_api.png" title="ocelot order api"  width="800">
<img src="/pictures/ocelot_order_api2.png" title="ocelot order api"  width="800">



## Blazor Frontend App

<img src="/pictures/blazor.png" title="frontend app"  width="800">
<img src="/pictures/blazor2.png" title="frontend app"  width="800">



## Ocelot API Gateway JWT Authentication

### Packages
```
Microsoft.IdentityModel.Tokens
System.IdentityModel.Tokens.Jwt
Microsoft.Extensions.DependencyInjection.Abstraction
```


## Authentication API

<img src="/pictures/authentication.png" title="authentication"  width="800">
<img src="/pictures/authentication2.png" title="wrong password"  width="800">
<img src="/pictures/authentication3.png" title="get customer without token"  width="800">




# Net Core JWT Authentication - .Net Core JWT Token - ASP.Net Core 5 JWT

## Packages
```
Microsoft.AspNetCore.Authentication
Microsoft.AspNetCore.Authentication.JwtBearer
System.IdentityModel.Tokens.Jwt
```

Get Url for App Settings :

<img src="/pictures/url.png" title="url"  width="800">

https://www.youtube.com/watch?v=3Q_aNm6gJiMx




# ASP.NET Core Web API Authentication and Authorization with JWT

## Packages
```
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.IdentityModel.Tokens
System.IdentityModel.Tokens.Jwt
```

https://www.youtube.com/watch?v=kM1fPt1BcLc
https://github.com/iulianoana/jwt-dotnetcore-web/



## Authentification avec JWT Token d’une API web avec ASP.NET Core - C#

## Packages
```
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.IdentityModel.Tokens
System.IdentityModel.Tokens.Jwt
```

https://www.youtube.com/watch?v=GkfWs-CwneA
https://github.com/kmeziane/JwtApi
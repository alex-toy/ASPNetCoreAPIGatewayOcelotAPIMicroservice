# ASP.Net Core API Gateway - Ocelot API Microservice

Ocelot manipulates the HttpRequest object into a state specified by its configuration until it reaches a request builder middleware where it creates a HttpRequestMessage object which is used to make a request to a downstream service. The middleware that makes the request is the last thing in the Ocelot pipeline. It does not call the next middleware. The response from the downstream service is retrieved as the requests goes back up the Ocelot pipeline. There is a piece of middleware that maps the HttpResponseMessage onto the HttpResponse object and that is returned to the client.

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




https://www.youtube.com/watch?v=ZCJKiwTMTSs&list=PLzewa6pjbr3JQKhB_U_FiuYwQC70i-TyU&index=4

https://github.com/codingdroplets/
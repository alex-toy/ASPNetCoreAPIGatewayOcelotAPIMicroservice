# ASP.Net Core API Gateway - Ocelot API Microservice

Ocelot manipulates the HttpRequest object into a state specified by its configuration until it reaches a request builder middleware where it creates a HttpRequestMessage object which is used to make a request to a downstream service. The middleware that makes the request is the last thing in the Ocelot pipeline. It does not call the next middleware. The response from the downstream service is retrieved as the requests goes back up the Ocelot pipeline. There is a piece of middleware that maps the HttpResponseMessage onto the HttpResponse object and that is returned to the client.

## Create project

<img src="/pictures/create_project.png" title="create project"  width="500">


https://www.youtube.com/watch?v=k4l3Ptd4yjw

https://www.youtube.com/watch?v=dY_AWdCzsCY&list=PLzewa6pjbr3IQEUfNiK2SROQC1NuKl6PV

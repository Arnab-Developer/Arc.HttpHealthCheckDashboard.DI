# Http health check dashboard DI

This is a library for
[http health check dashboard](https://github.com/Arnab-Developer/Arc.HttpHealthCheckDashboard) 
DI for ASP.NET. It has been hosted in [NuGet](https://www.nuget.org/packages/Arc.HttpHealthCheckDashboard.DI/). 

Use below command to install this in your .NET application.

```
dotnet add package Arc.HttpHealthCheckDashboard.DI
```

Use the below code to add `http health check dashboard` into ASP.NET DI.

```csharp
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpHealthCheckDashboard(builder.Configuration);
```

There is a 
[dashboard app](https://github.com/Arnab-Developer/HttpHealthCheckDashboard) 
which uses the library to check health of some http endpoints. This is to show 
how you can use this library in your app.
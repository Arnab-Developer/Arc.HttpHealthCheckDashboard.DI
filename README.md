# Http health check dashboard DI

[![CI CD](https://github.com/Arnab-Developer/Arc.HttpHealthCheckDashboard.DI/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/Arnab-Developer/Arc.HttpHealthCheckDashboard.DI/actions/workflows/ci-cd.yml)
![Nuget](https://img.shields.io/nuget/v/Arc.HttpHealthCheckDashboard.DI)

This is a library for
[http health check dashboard](https://github.com/Arnab-Developer/Arc.HttpHealthCheckDashboard) 
DI for ASP.NET. It has been hosted in [NuGet](https://www.nuget.org/packages/Arc.HttpHealthCheckDashboard.DI/). 

Use below command to install this in your .NET application.

```
dotnet add package Arc.HttpHealthCheckDashboard.DI
```

Use the below code to add `http health check dashboard` into ASP.NET DI.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpHealthCheckDashboard(Configuration);
}
```

There is a 
[dashboard app](https://github.com/Arnab-Developer/HttpHealthCheckDashboard) 
which uses the library to check health of some http endpoints. This is to show 
how you can use this library in your app.

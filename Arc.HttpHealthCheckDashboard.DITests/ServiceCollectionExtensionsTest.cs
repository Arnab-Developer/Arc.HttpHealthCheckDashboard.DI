using Arc.HttpHealthCheckDashboard.DI;
using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Arc.HttpHealthCheckDashboard.DITests;

public class ServiceCollectionExtensionsTest
{
    [Fact]
    public async Task Can_AddHttpHealthCheckDashboard_InjectDependency()
    {
        IServiceCollection services = new ServiceCollection();
        Mock<IConfiguration> configurationMock = new();
        services.AddHttpHealthCheckDashboard(configurationMock.Object);
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        IHealthCheck healthCheck = serviceProvider.GetRequiredService<IHealthCheck>();
        Assert.NotNull(healthCheck);
        bool isGoogleHealthy = await healthCheck.IsHealthyAsync("http://google.com");
        Assert.True(isGoogleHealthy);
        bool isMicrosoftHealthy = await healthCheck.IsHealthyAsync("http://microsoft.com");
        Assert.True(isMicrosoftHealthy);

        ApiDetail apiDetail = new("google", "http://google.com", null, true);
        ICommonHealthCheck commonHealthCheck = serviceProvider.GetRequiredService<ICommonHealthCheck>();
        bool isApiHealthy = await commonHealthCheck.IsApiHealthyAsync(apiDetail);
        Assert.True(isApiHealthy);
    }
}
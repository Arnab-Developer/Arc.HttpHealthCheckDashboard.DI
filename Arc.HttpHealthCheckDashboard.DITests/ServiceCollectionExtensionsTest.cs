using Arc.HttpHealthCheckDashboard.DI;
using ArnabDeveloper.HttpHealthCheck;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Arc.HttpHealthCheckDashboard.DITests
{
    public class ServiceCollectionExtensionsTest
    {
        [Fact]
        public void Can_AddHttpHealthCheckDashboard_InjectDependency()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddHttpHealthCheckDashboard();
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            IHealthCheck healthCheck = serviceProvider.GetRequiredService<IHealthCheck>();
            Assert.NotNull(healthCheck);
            bool isGoogleHealthy = healthCheck.IsHealthy("http://google.com");
            Assert.True(isGoogleHealthy);
            bool isMicrosoftHealthy = healthCheck.IsHealthy("http://microsoft.com");
            Assert.True(isMicrosoftHealthy);

            ApiDetail apiDetail = new("google", "http://google.com", null, true);
            ICommonHealthCheck commonHealthCheck = serviceProvider.GetRequiredService<ICommonHealthCheck>();
            bool isApiHealthy = commonHealthCheck.IsApiHealthy(apiDetail);
            Assert.True(isApiHealthy);
        }
    }
}

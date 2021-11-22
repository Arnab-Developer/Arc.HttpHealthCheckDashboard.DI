using ArnabDeveloper.HttpHealthCheck;
using ArnabDeveloper.HttpHealthCheck.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arc.HttpHealthCheckDashboard.DI
{
    /// <summary>
    /// Service collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add http health check dashboard
        /// </summary>
        /// <param name="services">IServiceCollection type object</param>
        /// <param name="configuration">IConfiguration type object</param>
        /// <returns>IServiceCollection type object</returns>
        public static IServiceCollection AddHttpHealthCheckDashboard(this IServiceCollection services,
            IConfiguration configuration) =>
            services
                .AddHttpHealthCheck()
                .AddTransient(typeof(ICommonHealthCheck), typeof(CommonHealthCheck))
                .AddTransient(options =>
                {
                    IEnumerable<IConfigurationSection> sections = configuration.GetSection("ApiDetails").GetChildren();
                    List<ApiDetail> urlDetails = new();
                    for (var counter = 0; counter < sections.Count(); counter++)
                    {
                        urlDetails.Add(new ApiDetail
                        (
                            configuration.GetValue<string>($"ApiDetails:{counter}:Name"),
                            configuration.GetValue<string>($"ApiDetails:{counter}:Url"),
                            new ApiCredential
                            (
                                configuration.GetValue<string>($"ApiDetails:{counter}:Credential:UserName"),
                                configuration.GetValue<string>($"ApiDetails:{counter}:Credential:Password")
                            ),
                            configuration.GetValue<bool>($"ApiDetails:{counter}:IsEnable")
                        ));
                    }
                    return urlDetails.AsEnumerable();
                });
    }
}

using ArnabDeveloper.HttpHealthCheck.DI;
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
        /// <returns>IServiceCollection type object</returns>
        public static IServiceCollection AddHttpHealthCheckDashboard(this IServiceCollection services) =>
            services
                .AddHttpHealthCheck()
                .AddTransient(typeof(ICommonHealthCheck), typeof(CommonHealthCheck));
    }
}

using Microsoft.Extensions.DependencyInjection;
using Pagos.CrossCutting.Configs;

namespace Pagos.Api.Configuraciones
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddHealthCheckConfiguration
            (this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            services.AddHealthChecks()
                .AddSqlServer(connectionString: appConfiguration.ConexionDBPagos);

            return services;
        }

        public static IApplicationBuilder UseHealthCheckConfiguration
           (this IApplicationBuilder services)
        {
            services.UseHealthChecks("/health");

            return services;
        }
    }
}

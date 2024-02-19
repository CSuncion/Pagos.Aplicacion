using Pagos.Infraestructura.Repositorios.Base;
using Microsoft.Extensions.DependencyInjection;
using Pagos.Dominio.Repositorios;
using Pagos.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pagos.CrossCutting.Configs;

namespace Pagos.Infraestructura
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, IConfiguration configInfo
            )
        {
            var appConfiguration = new AppConfiguration(configInfo);
            services.AddDataBaseFactories(appConfiguration.ConexionDBPagos);
            services.AddRepositorios();

        }
        private static void AddDataBaseFactories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PagosDbContext>(
                options => options.UseSqlServer(connectionString)
            );
        }
        private static void AddRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IPagosRepository, PagosRepository>();
        }
    }
}

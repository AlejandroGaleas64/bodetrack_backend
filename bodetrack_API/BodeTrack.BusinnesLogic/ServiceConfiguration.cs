using BodeTrack.BusinnesLogic.Services;
using BodeTrack.DataAccess;
using BodeTrack.DataAccess.General;
using Microsoft.Extensions.DependencyInjection;

namespace BodeTrack.BusinnesLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            // Initialize the connection string for repositories that use Dapper
            BodeTrack_Context.BuildConnectionString(connectionString);

            services.AddScoped<DepartamentoRepository>();
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralServices>();
            //services.AddScoped<AccesoServices>();
            //services.AddScoped<ReporteServices>();
            //services.AddScoped<DashboardServices>();
        }
    }
}
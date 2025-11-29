using BodeTrack.BusinnesLogic.Services;
using BodeTrack.DataAccess;
using BodeTrack.DataAccess.Repositories.Acceso;
using BodeTrack.DataAccess.Repositories.General;
using BodeTrack.DataAccess.Repositories.Inventario;
using Microsoft.Extensions.DependencyInjection;

namespace BodeTrack.BusinnesLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            // Initialize the connection string for repositories that use Dapper
            BodeTrack_Context.BuildConnectionString(connectionString);

            // General Repositories
            services.AddScoped<ArticulosRepository>();
            services.AddScoped<CargosRepository>();
            services.AddScoped<DepartamentosRepository>();
            services.AddScoped<EmpleadosRepository>();
            services.AddScoped<EstadosCivilesRespository>();
            services.AddScoped<MunicipiosRepository>();
            services.AddScoped<SucursalesRepository>();
            services.AddScoped<VehiculosRepository>();

            // Acceso Repositories
            services.AddScoped<UsuariosRepository>();

            // Inventario Repositories
            services.AddScoped<EntradasRepository>();
            services.AddScoped<LotesRepository>();
            services.AddScoped<SalidasRepository>();
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<GeneralServices>();
            services.AddScoped<AccesoServices>();
            services.AddScoped<InventarioServices>();
        }
    }
}
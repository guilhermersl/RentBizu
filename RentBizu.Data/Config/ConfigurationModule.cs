using RentBizu.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentBizu.Data.Contexto;
using RentBizu.Data.Repository;
using RentBizu.Domain.LocadorContext.Repositories;
using RentBizu.Domain.LocatarioContext.Repositories;
using RentBizu.Domain.AluguelContext.Repositories;

namespace RentBizu.Data.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RentBizuContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped(typeof(Repository<>));
            services.AddScoped<ILocadorRepository, LocadorRepository>();
            services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();
            services.AddScoped<ILocatarioRepository, LocatarioRepository>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();

            return services;
        }
    }
}

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentBizu.Application.AlbumContext.LocadorApp.Service;
using RentBizu.Application.AlbumContext.Service;
using RentBizu.Application.AluguelContext.Service;
using RentBizu.Application.LocadorContext.LocadorApp.Service;
using RentBizu.Application.LocadorContext.Service;
using RentBizu.Application.LocatarioContext.LocatarioApp.Service;

namespace RentBizu.Application.Config
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
            services.AddMediatR(typeof(ConfigurationModule).Assembly);

            services.AddScoped<ILocadorService, LocadorService>();
            services.AddScoped<IPlanoContaService, PlanoContaService>();
            services.AddScoped<ILocatarioService, LocatarioService>();
            services.AddScoped<IAluguelService, AluguelService>();

            return services;
        }
    }
}

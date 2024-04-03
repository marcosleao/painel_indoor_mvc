using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Core.Services.Conteudos;
using PainelIndoor.Application.Core.Services.Paineis;
using PainelIndoor.Application.Interfaces;
using PainelIndoor.Infra.Data.Contexts;
using PainelIndoor.Infra.Data.Repositories;

namespace PainelIndoorWeb.Configurations
{
    public static class DIConfigurations
    {
        public static void AddDIConfig(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped(typeof(IAsyncRepositoryBase<>), typeof(EFAsyncRepositoryBase<>));
            
            services.AddScoped<IConteudosRepository, EFConteudosRepository>();
            services.AddScoped<IPaineisRepository, EFPaineisRepository>();
            services.AddScoped<IFiliaisRepository, EFFiliaisRepository>();

            services.AddScoped<IPaineisService, PaineisHandler>();
            services.AddScoped<PaineisHandler>();
            services.AddScoped<IConteudosService, ConteudosHandler>();
            services.AddScoped<ConteudosHandler>();
        }
    }
}

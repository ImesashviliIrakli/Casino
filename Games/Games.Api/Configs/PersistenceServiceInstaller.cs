using BuildingBlocks.Applictaion.Interfaces;
using Games.Application.Interfaces;
using Games.Persistence.Data;
using Games.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.Configs;

public class PersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            //options.UseNpgsql(configuration["POSTGRES_CONNECTION_STRING"]);
            options.UseNpgsql(configuration.GetConnectionString("POSTGRES_CONNECTION_STRING"));
        });

        services.AddScoped<IGameProviderRepository, GameProviderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
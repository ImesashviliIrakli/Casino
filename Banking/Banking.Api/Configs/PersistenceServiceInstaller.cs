using Banking.Application.Interfaces;
using Banking.Persistence.Data;
using Banking.Persistence.Implementations;
using BuildingBlocks.Applictaion.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Banking.Api.Configs;

public class PersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            //options.UseNpgsql(configuration["POSTGRES_CONNECTION_STRING"]);
            options.UseNpgsql(configuration.GetConnectionString("POSTGRES_CONNECTION_STRING"));
        });

        services.AddScoped<IPaymentSystemRepository, PaymentSystemRepository>();
        services.AddScoped<IPaymentRequestRepository, PaymentRequestRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
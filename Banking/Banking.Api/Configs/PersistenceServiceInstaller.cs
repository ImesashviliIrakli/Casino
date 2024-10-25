using Banking.Application.Interfaces;
using Banking.Persistence.Implementations;
using BuildingBlocks.Applictaion.Interfaces;

namespace Banking.Api.Configs;

public class PersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPaymentSystemRepository, PaymentSystemRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
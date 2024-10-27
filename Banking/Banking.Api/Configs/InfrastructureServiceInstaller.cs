using Banking.Application.Interfaces;
using Banking.Infrastructure.Grpc;
using Users.Api.Grpc;

namespace Banking.Api.Configs;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<WalletManager.WalletManagerClient>("Wallet", o =>
        {
            o.Address = new Uri(configuration["GrpcSettings:UsersGrpcServiceUrl"]);
        });

        services.AddScoped<IWalletGrpcService, WalletGrpcService>();
    }
}

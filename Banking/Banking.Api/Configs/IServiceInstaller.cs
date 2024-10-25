namespace Banking.Api.Configs;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
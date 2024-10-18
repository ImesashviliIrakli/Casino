using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Api.Configs;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}

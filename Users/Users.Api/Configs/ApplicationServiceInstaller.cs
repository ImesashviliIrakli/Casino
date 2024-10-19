using Users.Applictaion;

namespace Users.Api.Configs;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddAutoMapper(AssemblyReference.Assembly);
    }
}

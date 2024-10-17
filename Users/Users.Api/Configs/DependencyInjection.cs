using BuildingBlocks.Api;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Users.Domain.Entities;
using Users.Persistence.Data;

namespace Users.Api.Configs;

public static class DependencyInjection
{
    public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterDBContext(configuration);


        return services;
    }


    private static IServiceCollection RegisterDBContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<Player, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddIdentityCore<Admin>()
            .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        return services;
    }
}
using BuildingBlocks.Applictaion.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Users.Application.Interfaces;
using Users.Application.Options;
using Users.Domain.Entities;
using Users.Persistence.Data;
using Users.Persistence.Implementations;

namespace Users.Api.Configs;

public class IdentityServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

        var connectionString = configuration["SSMS_CONNECTION_STRING"];

        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddScoped<IWalletRepository, WalletRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtOptions:Issuer"],
                ValidAudience = configuration["JwtOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"]))

            };
        });
    }
}

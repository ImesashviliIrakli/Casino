using BuildingBlocks.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;
using System.Text;

namespace BuildingBlocks.Api.Configs;

public class BuildingBlocksBaseServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        //services.AddSwaggerGen(x =>
        //{
        //    x.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
        //    {
        //        Name = "Authorization",
        //        Description = "Enter the bearer authorization string as following: `Bearer Generated JWT TOKEN`",
        //        In = ParameterLocation.Header,
        //        Type = SecuritySchemeType.ApiKey,
        //        Scheme = "Bearer"
        //    });

        //    x.AddSecurityRequirement(new OpenApiSecurityRequirement
        //    {
        //        {
        //            new OpenApiSecurityScheme
        //            {
        //                Reference = new OpenApiReference
        //                {
        //                    Type = ReferenceType.SecurityScheme,
        //                    Id = JwtBearerDefaults.AuthenticationScheme
        //                }
        //            }, new string[]{ }
        //        }
        //    });

        //});

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

        services.AddCors(options =>
        {
            options.AddPolicy("allowall", policy =>
            {
                policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        Log.Logger = new LoggerConfiguration()
           .Enrich.FromLogContext()
           .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
           .WriteTo.File("../Logs/log.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
           .WriteTo.File("../Logs/logError.txt", restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day)
           .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Uri"]!))
           {
               AutoRegisterTemplate = true,
               IndexFormat =
                   $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace('.', '-')}-" +
                   $"{DateTime.UtcNow:yyyy-MM}",
               NumberOfReplicas = 2,
               NumberOfShards = 1
           })
           .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSerilog(dispose: true);
        });
    }
}

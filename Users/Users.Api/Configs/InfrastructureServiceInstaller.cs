
using BuildingBlocks.Applictaion.Interfaces;
using RabbitMQ.Client;
using Users.Infrastructure.BackgroundServices;
using Users.Infrastructure.Handlers;
using Users.Infrastructure.Messages;

namespace Users.Api.Configs;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionFactory>(provider =>
        {
            return new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                Port = AmqpTcpEndpoint.UseDefaultPort
            };
        });

        services.AddSingleton(typeof(IMessageConsumer<>), typeof(RabbitMqMessageConsumer<>));

        services.AddHostedService<PaymentRequestBackgroundService>();

        services.AddScoped<PaymentRequestMessageHandler>();
    }
}

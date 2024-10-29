
using BuildingBlocks.Applictaion.Interfaces;
using RabbitMQ.Client;
using Users.Application.Models.PaymentRequest;
using Users.Infrastructure.BackgroundServices;
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
                // Optional additional settings
                VirtualHost = "/",
                Port = AmqpTcpEndpoint.UseDefaultPort
            };
        });
        services.AddSingleton<IMessageConsumer<PaymentRequestDto>, RabbitMqMessageConsumer<PaymentRequestDto>>();
        services.AddHostedService<RabbitMqBackgroundService<PaymentRequestDto>>();

    }
}

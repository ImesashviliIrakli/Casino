using BuildingBlocks.Applictaion.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace Users.Infrastructure.BackgroundServices;

public class RabbitMqBackgroundService<T> : BackgroundService
{
    private readonly IMessageConsumer<T> _messageConsumer;

    public RabbitMqBackgroundService(IMessageConsumer<T> messageConsumer)
    {
        _messageConsumer = messageConsumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _messageConsumer.ConsumeAsync(async message =>
        {
            // Handle the message here
            Console.WriteLine($"Message received: {JsonSerializer.Serialize(message)}");
            // Add your processing logic here

        }, "transactions_deposit_withdraw_queue", stoppingToken);
    }
}
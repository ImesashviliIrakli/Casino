using BuildingBlocks.Applictaion.Interfaces;
using RabbitMQ.Client;
using System.Text.Json;

namespace Banking.Infrastructure.Messages;

public class RabbitMqMessageProducer<T> : IMessageProducer<T>
{

    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqMessageProducer()
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public Task PublishAsync(T message, string exchangeName, string routingKey = "", CancellationToken cancellationToken = default)
    {
        // Publish to the specified exchange and routing key
        var messageBody = JsonSerializer.Serialize(message);
        var body = System.Text.Encoding.UTF8.GetBytes(messageBody);

        _channel.BasicPublish(
            exchange: exchangeName,
            routingKey: routingKey,
            basicProperties: null,
            body: body
        );

        return Task.CompletedTask;
    }
}

using BuildingBlocks.Applictaion.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Users.Infrastructure.Messages;

public class RabbitMqMessageConsumer<T> : IMessageConsumer<T>
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqMessageConsumer(IConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public Task ConsumeAsync(Func<T, Task> onMessageReceived, string queueName, CancellationToken cancellation = default)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();

            var message = JsonSerializer.Deserialize<T>(body);

            if (message != null)
                await onMessageReceived(message);

            _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}

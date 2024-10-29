namespace BuildingBlocks.Applictaion.Interfaces;

public interface IMessageProducer<T>
{
    Task PublishAsync(T message, string exchangeName, string routingKey = "", CancellationToken cancellationToken = default);
}

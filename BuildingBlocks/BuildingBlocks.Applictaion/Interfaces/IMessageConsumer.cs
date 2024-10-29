namespace BuildingBlocks.Applictaion.Interfaces;

public interface IMessageConsumer<T>
{
    Task ConsumeAsync(Func<T, Task> onMessageReceived, string queueName, CancellationToken cancellation = default);
}

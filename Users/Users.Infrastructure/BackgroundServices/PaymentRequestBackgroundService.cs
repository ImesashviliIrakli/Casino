using BuildingBlocks.Applictaion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.Application.Models.PaymentRequest;
using Users.Infrastructure.Handlers;

namespace Users.Infrastructure.BackgroundServices;

public class PaymentRequestBackgroundService : BackgroundService
{
    private static readonly string QueueName = "transactions_deposit_withdraw_queue";
    private readonly IMessageConsumer<PaymentRequestDto> _messageConsumer;
    private readonly IServiceScopeFactory _scopeFactory;

    public PaymentRequestBackgroundService(
        IMessageConsumer<PaymentRequestDto> messageConsumer,
        IServiceScopeFactory scopeFactory
        )
    {
        _messageConsumer = messageConsumer;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _messageConsumer.ConsumeAsync(async message =>
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<PaymentRequestMessageHandler>();

                await handler.Handle(message, cancellationToken);
            }
                
        }, QueueName, cancellationToken);
    }
}
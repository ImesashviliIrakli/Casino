using Banking.Domain.Entities;
using Banking.Domain.Events;
using BuildingBlocks.Applictaion.Interfaces;

namespace Banking.Application.Events;

public class PaymentRequestStatusUpdatedHandler : IDomainEventHandler<PaymentRequestStatusUpdated>
{
    private static readonly string ExchangeName = "deposit_withdraw_exchange";
    private readonly IMessageProducer<PaymentRequest> _messageProducer;
    public PaymentRequestStatusUpdatedHandler(IMessageProducer<PaymentRequest> messageProducer)
    {
        _messageProducer = messageProducer;
    }
    public async Task Handle(PaymentRequestStatusUpdated notification, CancellationToken cancellationToken)
    {
        await _messageProducer.PublishAsync(notification.paymentRequest, ExchangeName, cancellationToken: cancellationToken);
    }
}

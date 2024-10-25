using Banking.Domain.Events;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Domain.Entities;

public class PaymentRequest : Entity
{
    [ForeignKey("PaymentSystemId")]
    public Guid PaymentSystemId { get; private set; }
    public PaymentSystem? PaymentSystem { get; private set; } // Navigation Property
    public string PlayerUserId { get; private set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public PaymentDirection PaymentDirection { get; private set; }
    public TransactionStatus Status { get; private set; } 

    public PaymentRequest()
    { }

    public PaymentRequest(
            Guid paymentSystemId, 
            string playerUserId,
            decimal amount,
            Currency currency,
            PaymentDirection paymentDirection,
            TransactionStatus status
        )
    {
        Id = Guid.NewGuid();
        PaymentSystemId = paymentSystemId;
        PlayerUserId = playerUserId;
        Amount = amount;
        Currency = currency;
        PaymentDirection = paymentDirection;
        Status = status;

        if(paymentDirection == PaymentDirection.Withdraw)
            AddDomainEvent(new PaymentRequestCreatedEvent(Guid.NewGuid(), this));
    }

    public void UpdateStatus(TransactionStatus status)
    {
        Status = status;

        AddDomainEvent(new PaymentRequestStatusUpdated(Guid.NewGuid(), this));
    }
}

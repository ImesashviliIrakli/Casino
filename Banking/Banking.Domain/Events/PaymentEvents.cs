using Banking.Domain.Entities;
using BuildingBlocks.Domain.Primitives;

namespace Banking.Domain.Events;

public record PaymentRequestCreatedEvent(Guid id, PaymentRequest paymentRequest) : DomainEvent(id);
public record PaymentRequestStatusUpdated(Guid id, PaymentRequest paymentRequest) : DomainEvent(id);
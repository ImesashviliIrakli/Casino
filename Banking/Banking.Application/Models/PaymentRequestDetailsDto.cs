using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Models;

public class PaymentRequestDetailsDto
{
    public Guid Id { get; set; }
    public Guid PaymentSystemId { get; set; }
    public PaymentSystemDto? PaymentSystem { get; set; }
    public required string PlayerUserId { get; set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public PaymentDirection PaymentDirection { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

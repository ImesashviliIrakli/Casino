using BuildingBlocks.Domain.Enums;

namespace Users.Application.Models.PaymentRequest;

public class PaymentRequestDto
{
    public Guid Id { get; set; }
    public Guid PaymentSystemId { get; set; }
    public required string PlayerUserId { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
    public PaymentDirection PaymentDirection { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

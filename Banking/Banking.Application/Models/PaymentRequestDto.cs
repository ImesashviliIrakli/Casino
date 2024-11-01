using Banking.Domain.Entities;
using BuildingBlocks.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Application.Models;

public class PaymentRequestDto
{
    public Guid Id { get; set; }
    public Guid PaymentSystemId { get; set; }
    public required string PlayerUserId { get; set; }
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }
    public PaymentDirection PaymentDirection { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

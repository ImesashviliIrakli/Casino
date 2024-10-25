using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Models;

public class PaymentSystemDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal MinimumLimit { get; set; }
    public decimal MaximumLimit { get; set; }
    public PaymentDirection PaymentDirection { get; set; }
    public bool IsTest { get; set; }
    public bool IsDisabled { get; set; } = false;
    public required string ImageUrl { get; set; }
}

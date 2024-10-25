using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Banking.Application.Features.Commands.UpdatePaymentSystem;

public class UpdatePaymentSystemCommand : ICommandQuery
{
    [Required]
    public Guid PaymentSystemId { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public decimal MinimumLimit { get; set; }
    [Required]
    public decimal MaximumLimit { get; set; }
    [Required]
    public PaymentDirection PaymentDirection { get; set; }
    public bool IsTest { get; set; } = true;
    [Required]
    public required string ImageUrl { get; set; }
}

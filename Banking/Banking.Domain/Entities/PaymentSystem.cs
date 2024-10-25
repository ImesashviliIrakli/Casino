using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Primitives;

namespace Banking.Domain.Entities;

public class PaymentSystem : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal MinimumLimit { get; private set; }
    public decimal MaximumLimit { get; private set; }
    public PaymentDirection PaymentDirection { get; private set; }
    public bool IsTest { get; private set; }
    public bool IsDisabled { get; private set; } = false;
    public string ImageUrl { get; private set; }

    public PaymentSystem()
    {
    }

    public PaymentSystem(
        string name,
        string description,
        decimal minimumLimit,
        decimal maximumLimit,
        PaymentDirection paymentDirection,
        bool isTest,
        string imageUrl
        )
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        MinimumLimit = minimumLimit;
        MaximumLimit = maximumLimit;
        PaymentDirection = paymentDirection;
        IsTest = isTest;
        ImageUrl = imageUrl;
    }

    public void UpdateDetails(
        string name,
        string description,
        decimal minimumLimit,
        decimal maximumLimit,
        PaymentDirection paymentDirection)
    {
        Name = name;
        Description = description;
        MinimumLimit = minimumLimit;
        MaximumLimit = maximumLimit;
        PaymentDirection = paymentDirection;
    }

    public void UpdateIsDisabled(bool isDisabled) => IsDisabled = isDisabled;

    public void UpdateIsTest(bool isTest) => IsTest = isTest;

    public void UpdateImageUrl(string imageUrl) => ImageUrl = imageUrl;
}

using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Primitives;

namespace Banking.Domain.Entities;

public class PaymentSystem : Entity
{
    public string BankName { get; private set; }
    public string BankDescription { get; private set; }
    public decimal MinimumLimit { get; private set; }
    public decimal MaximumLimit { get; private set; }
    public PaymentSystemType PaymentSystemType { get; private set; }
    public bool IsTest { get; private set; }
    public string ImageUrl { get; private set; }

    public PaymentSystem()
    {
    }

    public PaymentSystem(
        string bankName,
        string bankDescription,
        decimal minimumLimit,
        decimal maximumLimit,
        PaymentSystemType paymentType,
        bool isTest,
        string imageUrl)
    {
        Id = Guid.NewGuid();
        BankName = bankName;
        BankDescription = bankDescription;
        MinimumLimit = minimumLimit;
        MaximumLimit = maximumLimit;
        PaymentSystemType = paymentType;
        IsTest = isTest;
        ImageUrl = imageUrl;
    }

    public void UpdateBankDetails(
        string bankName,
        string bankDescription,
        decimal minimumLimit,
        decimal maximumLimit,
        PaymentSystemType paymentType)
    {
        BankName = bankName;
        BankDescription = bankDescription;
        MinimumLimit = minimumLimit;
        MaximumLimit = maximumLimit;
        PaymentSystemType = paymentType;
    }

    public void UpdateIsTest(bool isTest) => IsTest = isTest;

    public void UpdateImageUrl(string imageUrl) => ImageUrl = imageUrl;
}

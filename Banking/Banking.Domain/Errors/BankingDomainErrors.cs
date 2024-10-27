using BuildingBlocks.Domain.Shared;

namespace Banking.Domain.Errors;

public static class BankingDomainErrors
{
    public static readonly Error NotFound = new(
            "NotFound",
            $"Payment system not found."
            );

    public static readonly Error UnsupportedDirection = new(
            "BadRequest",
            $"Payment direction is not supported."
            );

    public static readonly Error PendingPaymentRequests = new(
            "BadRequest",
            $"User has pending payment requests."
            );

    public static readonly Error AmountNotInLimits = new(
            "BadRequest",
            $"Amount not in limits."
            );

    public static readonly Error PaymentRequestNotFound = new(
            "BadRequest",
            $"Payment request not found"
            );

    public static readonly Error AlreadyProcessedRequest = new(
            "BadRequest",
            $"Payment request has already been processed"
            );

    public static readonly Error DifferentAmounts = new(
            "BadRequest",
            $"Amounts are different."
            );
}

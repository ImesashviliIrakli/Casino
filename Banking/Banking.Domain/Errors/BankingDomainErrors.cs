using BuildingBlocks.Domain.Shared;

namespace Banking.Domain.Errors;

public static class BankingDomainErrors
{
    public static readonly Error NotFound = new(
            "NotFound",
            $"Payment system not found."
            );
}

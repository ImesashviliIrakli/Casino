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
}

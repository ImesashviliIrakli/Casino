using BuildingBlocks.Domain.Shared;

namespace BuildingBlocks.Domain.Errors;

public static class GlobalErrors
{
    public static readonly Error UnsupportedTransactionType = new(
       "BadRequest",
       $"The specified transaction type is not supported in this method."
       );

    public static readonly Error AmountLessThenZero = new(
       "BadRequest",
       $"Amount must not be less then or equal to 0."
       );

    public static readonly Func<string, Error> SystemFailure = exception => new(
        "SystemFailure",
        exception
        );

}

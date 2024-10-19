using BuildingBlocks.Domain.Shared;

namespace Users.Domain.Errors;

public static class UserDomainErrors
{
    public static class User
    {
        public static readonly Error LoginFailed = new(
            "BadRequest",
            "Login failed."
            );

        public static readonly Func<string, Error> RegistrationFailed = errors => new(
            "BadRequest",
            $"Registration failed: {errors}"
            );

        public static readonly Func<string, Error> NotFound = email => new(
            "NotFound",
            $"The specified user: {email} could not be found."
            );
    }
    public static class Wallet
    {
        public static readonly Error NotFound = new(
            "NotFound",
            $"Wallet not found."
            );

        public static readonly Error NotEnoughFunds = new(
           "BadRequest",
           $"Not enough funds."
           );
    }
}

using BuildingBlocks.Domain.Shared;

namespace Users.Domain.Errors;

public static class UserDomainErrors
{
    public static class User
    {
        public static readonly Error LoginFailed = new(
            "LoginFailed",
            "Login failed."
            );

        public static readonly Func<string, Error> RegistrationFailed = errors =>  new(
            "RegistrationFailed",
            $"Registration failed: {errors}"
            );

        public static readonly Func<string, Error> NotFound = email => new(
                "NotFound",
                $"The specified user: {email} could not be found.");
    }
    public static class Wallet
    {
        public static readonly Func<string, Error> NotFound = email => new(
                "NotFound",
                $"The specified wallet for user: {email} could not be found.");
    }
}

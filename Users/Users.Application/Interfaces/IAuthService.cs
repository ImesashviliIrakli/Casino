using Users.Application.Models;

namespace Users.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
    Task<RegistrationResponse> RegisterPlayerAsync(RegistrationRequest registrationRequest);
    Task<RegistrationResponse> RegisterAdminAsync(RegistrationRequest registrationRequest);
}

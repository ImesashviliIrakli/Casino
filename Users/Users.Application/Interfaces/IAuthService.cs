using Users.Application.Models;

namespace Users.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
    Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest);
}

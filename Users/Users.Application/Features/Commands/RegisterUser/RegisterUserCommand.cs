using BuildingBlocks.Applictaion.Features;
using Users.Application.Models;

namespace Users.Application.Features.Commands.RegisterUser;

public class RegisterUserCommand : ICommandQuery<RegistrationResponse>
{
    public RegistrationRequest body { get; set; }
}

using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using Users.Application.Models;

namespace Users.Application.Features.Commands.RegisterUser;

public class RegisterUserCommand : ICommandQuery<RegistrationResponse>
{
    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string SID { get; set; }

    public Roles Role { get; set; }

    public required string Password { get; set; }
}

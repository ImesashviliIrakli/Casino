using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using Users.Application.Models;

namespace Users.Application.Features.Commands.RegisterUser;

public class RegisterUserCommand : ICommandQuery<RegistrationResponse>
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string SID { get; set; }

    [Required]
    public Roles Role { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}

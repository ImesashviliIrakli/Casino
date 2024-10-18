using BuildingBlocks.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Users.Application.Models;

public class RegistrationRequest
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

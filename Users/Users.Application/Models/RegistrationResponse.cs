using System.ComponentModel.DataAnnotations;

namespace Users.Application.Models;

public class RegistrationResponse
{
    [Required]
    public string UserId { get; set; }

    public RegistrationResponse(string userId)
    {
        UserId = userId;
    }
}

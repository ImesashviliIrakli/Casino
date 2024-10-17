using System.ComponentModel.DataAnnotations;

namespace Users.Application.Models;

public class LoginResponse
{
    [Required]
    public string Token { get; set; }
    public string UserId { get; set; }

    public LoginResponse(string token, string userId)
    {
        Token = token;
        UserId = userId;
    }
}
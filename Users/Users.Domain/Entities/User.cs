
using Microsoft.AspNetCore.Identity;

namespace Users.Domain.Entities;

public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PrivateId { get; set; }
}

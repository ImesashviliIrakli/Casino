
using Microsoft.AspNetCore.Identity;

namespace Users.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PrivateId { get; set; }
    
    public Wallet? Wallet{ get; set; }
}

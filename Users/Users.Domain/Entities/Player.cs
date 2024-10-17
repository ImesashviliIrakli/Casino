using Users.Domain.Enums;

namespace Users.Domain.Entities;

public class Player : User
{
    public Ranks Rank { get; set; }
    public Wallet? Wallet { get; set; }
}

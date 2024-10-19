using BuildingBlocks.Domain.Enums;

namespace Users.Application.Models.Wallet;

public class WalletDto
{
    public required decimal Balance { get; set; }
    public required Currency Currency { get; set; }
}

using BuildingBlocks.Applictaion.Features;
using Users.Application.Models.Wallet;

namespace Users.Application.Features.Queries.GetWalletByUserId;

public record GetWalletByUserIdQuery(string playerUserId) : ICommandQuery<WalletDto>;

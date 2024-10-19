using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Users.Application.Features.Commands.UpdateWallet;

public record UpdateWalletCommand(TransactionType transactionType, string playerUserId, decimal amount) : ICommandQuery;

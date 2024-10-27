using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Deposit.StartBOGDeposit;

public record StartBOGDepositCommand(decimal Amount, string playerUserId) : ICommandQuery;

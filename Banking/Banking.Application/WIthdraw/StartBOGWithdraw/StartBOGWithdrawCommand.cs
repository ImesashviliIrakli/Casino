using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.WIthdraw.StartBOGWithdraw;

public record StartBOGWithdrawCommand(decimal Amount, string PlayerUserId) : ICommandQuery;

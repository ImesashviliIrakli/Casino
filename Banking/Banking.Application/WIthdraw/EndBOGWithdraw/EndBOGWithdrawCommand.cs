using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Banking.Application.WIthdraw.EndBOGWithdraw;

public record EndBOGWithdrawCommand(Guid PaymentRequestId, decimal Amount, TransactionStatus TransactionStatus) : ICommandQuery;

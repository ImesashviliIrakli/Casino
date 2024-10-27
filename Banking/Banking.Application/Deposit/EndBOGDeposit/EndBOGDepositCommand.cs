using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Deposit.EndBOGDeposit;

public record EndBOGDepositCommand(Guid PaymentRequestId, decimal Amount, TransactionStatus TransactionStatus) : ICommandQuery;

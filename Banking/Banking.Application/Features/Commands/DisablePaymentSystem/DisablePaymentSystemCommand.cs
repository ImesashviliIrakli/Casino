using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Features.Commands.DisablePaymentSystem;

public record DisablePaymentSystemCommand(Guid PaymentSystemId, bool IsDisabled) : ICommandQuery;

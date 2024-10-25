using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Features.Commands.DeletePaymentSystem;

public record DeletePaymentSystemCommand(Guid PaymentSystemId) : ICommandQuery;

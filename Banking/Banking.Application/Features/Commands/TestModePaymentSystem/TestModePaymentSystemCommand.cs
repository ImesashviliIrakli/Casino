using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Features.Commands.TestModePaymentSystem;

public record TestModePaymentSystemCommand(Guid PaymentSystemId, bool IsTest) : ICommandQuery;

using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Features.Queries.GetPaymentSystemById;

public record GetPaymentSystemByIdQuery(Guid PaymentSystemId) : ICommandQuery<PaymentSystemDto>;

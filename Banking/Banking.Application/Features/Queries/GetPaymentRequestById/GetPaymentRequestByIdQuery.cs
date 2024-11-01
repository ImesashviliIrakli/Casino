using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;

namespace Banking.Application.Features.Queries.GetPaymentRequestById;

public record GetPaymentRequestByIdQuery(Guid PaymentRequestId) : ICommandQuery<PaymentRequestDetailsDto>;

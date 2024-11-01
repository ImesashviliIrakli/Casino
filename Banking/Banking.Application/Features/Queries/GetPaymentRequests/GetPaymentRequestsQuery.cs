using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Models.Filters;

namespace Banking.Application.Features.Queries.GetPaymentRequests;

public record GetPaymentRequestsQuery(FilterParameters FilterParameters) : ICommandQuery<List<PaymentRequestDto>>;

using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Banking.Application.Features.Queries.GetPaymentSystems;

public record GetPaymentSystemsQuery(PaymentDirection PaymentDirection, bool IncludeTestPaymentSystems) : ICommandQuery<List<PaymentSystemDto>>;
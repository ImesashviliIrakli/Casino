using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Users.Application.Features.Commands.ChangePlayerCurrency;

public record ChangePlayerCurrencyCommand(string playerUserId, Currency currency) : ICommandQuery;
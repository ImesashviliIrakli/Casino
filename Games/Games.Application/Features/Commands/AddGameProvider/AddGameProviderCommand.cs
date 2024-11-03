using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Games.Application.Features.Commands.AddGameProvider;

public record AddGameProviderCommand(string Name, string ViewName, GameType GameType) : ICommandQuery;
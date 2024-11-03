using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.DisableGame;

public record DisableGameCommand(Guid GameId, bool IsDisabled) : ICommandQuery;

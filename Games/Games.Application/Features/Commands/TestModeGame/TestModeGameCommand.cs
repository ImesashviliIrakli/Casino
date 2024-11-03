using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.TestModeGame;

public record TestModeGameCommand(Guid GameId, bool ForTesting) : ICommandQuery;


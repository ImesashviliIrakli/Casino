using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.TestModeGameProvider;

public record TestModeGameProviderCommand(Guid GameProviderId, bool ForTesting) : ICommandQuery;

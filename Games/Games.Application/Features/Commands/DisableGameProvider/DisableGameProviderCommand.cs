using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.DisableGameProvider;

public record DisableGameProviderCommand(Guid GameProviderId, bool IsDisabled) : ICommandQuery;

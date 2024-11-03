using BuildingBlocks.Applictaion.Features;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGameProviderById;

public record GetGameProviderByIdQuery(Guid GameProviderId) : ICommandQuery<GameProviderDto>;

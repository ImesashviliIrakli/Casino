using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGameProviders;

public record GetGameProvidersQuery(GameType GameType) : ICommandQuery<List<GameProviderDto>>;

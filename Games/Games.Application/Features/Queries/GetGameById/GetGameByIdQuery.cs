using BuildingBlocks.Applictaion.Features;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGameById;

public record GetGameByIdQuery(Guid GameId) : ICommandQuery<GameDto>;

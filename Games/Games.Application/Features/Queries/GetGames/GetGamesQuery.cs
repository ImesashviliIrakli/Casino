using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGames;

public record GetGamesQuery(GameType GameType) : ICommandQuery<List<GameDto>>;

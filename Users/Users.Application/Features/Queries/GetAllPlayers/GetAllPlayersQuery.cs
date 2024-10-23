using BuildingBlocks.Applictaion.Features;
using Users.Application.Models.Players;

namespace Users.Application.Features.Queries.GetAllPlayers;

public record GetAllPlayersQuery : ICommandQuery<List<PlayerDto>>;

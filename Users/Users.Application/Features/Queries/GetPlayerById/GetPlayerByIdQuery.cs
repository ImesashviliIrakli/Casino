using BuildingBlocks.Applictaion.Features;
using Users.Application.Models.Players;

namespace Users.Application.Features.Queries.GetPlayerById;

public record GetPlayerByIdQuery(string playerId) : ICommandQuery<PlayerDto>;

using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Users.Application.Models.Players;
using Users.Domain.Entities;

namespace Users.Application.Features.Queries.GetAllPlayers;

public class GetAllPlayersQueryHandler : ICommandQueryHandler<GetAllPlayersQuery, List<PlayerDto>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    public GetAllPlayersQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<Result<List<PlayerDto>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var usersInRole = await _userManager.GetUsersInRoleAsync(Roles.Player.ToString());

        var players = _mapper.Map<List<PlayerDto>>(usersInRole.ToList());

        return players;
    }
}

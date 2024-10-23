using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Users.Application.Models.Players;
using Users.Domain.Entities;
using Users.Domain.Errors;

namespace Users.Application.Features.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : ICommandQueryHandler<GetPlayerByIdQuery, PlayerDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    public GetPlayerByIdQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<Result<PlayerDto>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.playerId);

        if (user is null)
            return Result.Failure<PlayerDto>(UserDomainErrors.User.NotFound(request.playerId));

        var checkRole = await _userManager.IsInRoleAsync(user, Roles.Player.ToString());

        if (!checkRole)
            return Result.Failure<PlayerDto>(UserDomainErrors.User.NotFound(request.playerId));

        return _mapper.Map<PlayerDto>(user);
    }
}

using BuildingBlocks.Application;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Users.Application.Models;
using Users.Application.Options;
using Users.Domain.Entities;
using Users.Domain.Errors;

namespace Users.Application.Features.Commands.Login;

public class LoginCommandHandler : ICommandQueryHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtOptions _jwtOptions;
    public LoginCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JwtOptions> jwtOptions
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);

        if (user is null)
            return Result.Failure<LoginResponse>(UserDomainErrors.User.NotFound(request.email));

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.password, false);

        if (result.Succeeded == false)
            return Result.Failure<LoginResponse>(UserDomainErrors.User.LoginFailed);

        JwtSecurityToken jwt = await GenerateTokenAsync(user);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new LoginResponse(token, user.Id);
    }

    private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
           issuer: _jwtOptions.Issuer,
        audience: _jwtOptions.Audience,
           claims: claims,
           expires: DateTime.Now.AddMinutes(_jwtOptions.DurationInMinutes),
           signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }
}

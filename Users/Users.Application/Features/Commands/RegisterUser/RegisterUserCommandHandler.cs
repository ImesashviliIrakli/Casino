using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Users.Application.Interfaces;
using Users.Application.Models;
using Users.Domain.Entities;
using Users.Domain.Errors;

namespace Users.Application.Features.Commands.RegisterUser;

public class RegisterUserCommandHandler : ICommandQueryHandler<RegisterUserCommand, RegistrationResponse>
{
    private readonly IWalletRepository _wallet;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public RegisterUserCommandHandler(
        IWalletRepository wallet,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUnitOfWork unitOfWork
        )
    {
        _wallet = wallet;
        _userManager = userManager;
        _signInManager = signInManager;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<RegistrationResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        using var transaction = _unitOfWork.BeginTransaction();

        try
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                EmailConfirmed = true,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PrivateId = request.SID
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createUserResult.Succeeded)
            {
                transaction.Rollback();
                return Result.Failure<RegistrationResponse>(UserDomainErrors.User.RegistrationFailed(BuildErrorMessage(createUserResult.Errors)));    
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, request.Role.ToString());

            if (!addRoleResult.Succeeded)
            {
                transaction.Rollback();
                return Result.Failure<RegistrationResponse>(UserDomainErrors.User.RegistrationFailed(BuildErrorMessage(addRoleResult.Errors)));
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, request.Role.ToString())
            };

            var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);

            if (!addClaimsResult.Succeeded)
            {
                transaction.Rollback();
                return Result.Failure<RegistrationResponse>(UserDomainErrors.User.RegistrationFailed(BuildErrorMessage(addClaimsResult.Errors)));
            }

            if (request.Role != Roles.Admin)
            {
                var wallet = new Wallet(Currency.USD, user.Id);

                await _wallet.AddAsync(wallet);
            }

            await _unitOfWork.SaveChangesAsync();

            transaction.Commit();

            return new RegistrationResponse(user.Id);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw new Exception("Registration failed: " + ex.Message);
        }
    }

    private string BuildErrorMessage(IEnumerable<IdentityError> errors)
    {
        var stringBuilder = new StringBuilder();
        foreach (var error in errors)
        {
            stringBuilder.AppendLine($"• {error.Description}");
        }
        return stringBuilder.ToString();
    }
}

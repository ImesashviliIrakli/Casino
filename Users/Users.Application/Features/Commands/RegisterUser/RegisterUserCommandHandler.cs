using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Users.Application.Interfaces;
using Users.Application.Models;

namespace Users.Application.Features.Commands.RegisterUser;

public class RegisterUserCommandHandler : ICommandQueryHandler<RegisterUserCommand, RegistrationResponse>
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<RegistrationResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var register = await _authService.RegisterAsync(request.body);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return register;
    }
}

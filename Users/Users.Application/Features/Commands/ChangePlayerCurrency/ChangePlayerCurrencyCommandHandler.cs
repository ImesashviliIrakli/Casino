using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Users.Application.Interfaces;
using Users.Domain.Errors;

namespace Users.Application.Features.Commands.ChangePlayerCurrency;

public class ChangePlayerCurrencyCommandHandler : ICommandQueryHandler<ChangePlayerCurrencyCommand>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ChangePlayerCurrencyCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
    {
        _walletRepository = walletRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(ChangePlayerCurrencyCommand request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetWalletByUserId(request.playerUserId);

        if (wallet is null)
            return Result.Failure(UserDomainErrors.Wallet.NotFound);

        wallet.ChangeCurrency(request.currency);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

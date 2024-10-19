using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Errors;
using BuildingBlocks.Domain.Shared;
using Users.Application.Interfaces;
using Users.Domain.Errors;

namespace Users.Application.Features.Commands.UpdateWallet;

public class UpdateWalletCommandHandler : ICommandQueryHandler<UpdateWalletCommand>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateWalletCommandHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
    {
        _walletRepository = walletRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateWalletCommand request, CancellationToken cancellationToken)
    {
        if (request.transactionType != TransactionType.Withdraw || request.transactionType != TransactionType.Deposit)
            return Result.Failure(GlobalErrors.UnsupportedTransactionType);

        if (request.amount <= 0)
            return Result.Failure(GlobalErrors.AmountLessThenZero);

        var wallet = await _walletRepository.GetWalletByUserId(request.playerUserId);

        if (wallet is null)
            return Result.Failure(UserDomainErrors.Wallet.NotFound);

        if(request.transactionType == TransactionType.Withdraw)
        {
            if ((wallet.Balance - request.amount) < 0)
                return Result.Failure(UserDomainErrors.Wallet.NotEnoughFunds);

            wallet.RemoveFromBalance(request.amount);

            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            wallet.AddToBalance(request.amount);

            await _unitOfWork.SaveChangesAsync();
        }

        return Result.Success();
    }
}

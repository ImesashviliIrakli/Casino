using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using System.Net.Http.Headers;
using Users.Application.Interfaces;
using Users.Application.Models.PaymentRequest;

namespace Users.Infrastructure.Handlers;

public class PaymentRequestMessageHandler
{
    private readonly IWalletRepository _walletRepository;
    private readonly IUnitOfWork _unitOfWork;
    public PaymentRequestMessageHandler(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
    {
        _walletRepository = walletRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(PaymentRequestDto paymentRequestDto, CancellationToken cancellationToken = default)
    {
        var wallet = await _walletRepository.GetWalletByUserId(paymentRequestDto.PlayerUserId);

        if (wallet is null)
            throw new Exception("Not found");

        switch (paymentRequestDto.PaymentDirection)
        {
            case PaymentDirection.Deposit:
                wallet.AddToBalance(paymentRequestDto.Amount);
                break;
            case PaymentDirection.Withdraw:
                wallet.RemoveFromBalance(paymentRequestDto.Amount);
                break;
            default:
                throw new Exception("Unsupported type");
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Errors;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.WIthdraw.StartBOGWithdraw;

public class StartBOGWithdrawCommandHandler : ICommandQueryHandler<StartBOGWithdrawCommand>
{
    private static readonly Guid PaymentSystemId = new Guid("Withdraw GUID");

    private readonly IWalletGrpcService _walletGrpcService;
    private readonly IPaymentRequestRepository _paymentRequestRepository;
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public StartBOGWithdrawCommandHandler(
        IPaymentRequestRepository paymentRequestRepository,
        IPaymentSystemRepository paymentSystemRepository,
        IWalletGrpcService walletGrpcService,
        IUnitOfWork unitOfWork
        )
    {
        _paymentRequestRepository = paymentRequestRepository;
        _paymentSystemRepository = paymentSystemRepository;
        _walletGrpcService = walletGrpcService;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(StartBOGWithdrawCommand request, CancellationToken cancellationToken)
    {
        if (await _paymentRequestRepository.CheckForPendingRequestsAsync(request.PlayerUserId))
            return Result.Failure(BankingDomainErrors.PendingPaymentRequests);

        if (request.Amount <= 0)
            return Result.Failure(GlobalErrors.AmountLessThenZero);

        var (minimumLimit, maximumLimit) = await _paymentSystemRepository.GetPaymentSystemLimitsAsync(PaymentSystemId, cancellationToken);

        if (request.Amount < minimumLimit || request.Amount > maximumLimit)
            return Result.Failure(BankingDomainErrors.AmountNotInLimits);

        var walletDto = await _walletGrpcService.GetWalletDataAsync(request.PlayerUserId, cancellationToken);

        var paymentRequest = new PaymentRequest(
            PaymentSystemId,
            request.PlayerUserId,
            request.Amount,
            walletDto.Currency,
            PaymentDirection.Withdraw,
            TransactionStatus.Pending
        );

        await _paymentRequestRepository.AddAsync(paymentRequest, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

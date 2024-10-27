using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Errors;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Deposit.StartBOGDeposit;

public class StartBOGDepositCommandHandler : ICommandQueryHandler<StartBOGDepositCommand>
{
    private static readonly Guid PaymentSystemId = new Guid("2b2ef896-55c5-47fb-aa7c-bb9f7e127829");

    private readonly IWalletGrpcService _walletGrpcService;
    private readonly IPaymentRequestRepository _paymentRequestRepository;
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public StartBOGDepositCommandHandler(
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
    public async Task<Result> Handle(StartBOGDepositCommand request, CancellationToken cancellationToken)
    {
        if (await _paymentRequestRepository.CheckForPendingRequestsAsync(request.playerUserId))
            return Result.Failure(BankingDomainErrors.PendingPaymentRequests);

        if (request.Amount <= 0)
            return Result.Failure(GlobalErrors.AmountLessThenZero);

        var (minimumLimit, maximumLimit) = await _paymentSystemRepository.GetPaymentSystemLimitsAsync(PaymentSystemId, cancellationToken);

        if (request.Amount < minimumLimit || request.Amount > maximumLimit)
            return Result.Failure(BankingDomainErrors.AmountNotInLimits);

        var walletDto = await _walletGrpcService.GetWalletDataAsync(request.playerUserId, cancellationToken);

        var paymentRequest = new PaymentRequest(
            PaymentSystemId,
            request.playerUserId,
            request.Amount,
            walletDto.Currency,
            PaymentDirection.Deposit,
            TransactionStatus.Pending
        );

        await _paymentRequestRepository.AddAsync(paymentRequest, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

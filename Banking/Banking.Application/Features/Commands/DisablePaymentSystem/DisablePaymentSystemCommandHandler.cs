using Banking.Application.Interfaces;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Commands.DisablePaymentSystem;

public class DisablePaymentSystemCommandHandler : ICommandQueryHandler<DisablePaymentSystemCommand>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DisablePaymentSystemCommandHandler(IPaymentSystemRepository paymentSystemRepository, IUnitOfWork unitOfWork)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DisablePaymentSystemCommand request, CancellationToken cancellationToken)
    {
        var paymentSystem = await _paymentSystemRepository.GetPaymentSystemByIdAsync(request.PaymentSystemId, cancellationToken);

        if (paymentSystem is null)
            return Result.Failure(BankingDomainErrors.NotFound);

        paymentSystem.UpdateIsDisabled(request.IsDisabled);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

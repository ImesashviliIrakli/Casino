using Banking.Application.Interfaces;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Commands.UpdatePaymentSystem;

public class UpdatePaymentSystemCommandHandler : ICommandQueryHandler<UpdatePaymentSystemCommand>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePaymentSystemCommandHandler(IPaymentSystemRepository paymentSystemRepository, IUnitOfWork unitOfWork)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdatePaymentSystemCommand request, CancellationToken cancellationToken)
    {
        var paymentSystem = await _paymentSystemRepository.GetPaymentSystemByIdAsync(request.PaymentSystemId, cancellationToken);

        if (paymentSystem is null)
            return Result.Failure(BankingDomainErrors.NotFound);

        paymentSystem.UpdateDetails(
            request.Name,
            request.Description,
            request.MinimumLimit,
            request.MaximumLimit,
            request.PaymentDirection
        );

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

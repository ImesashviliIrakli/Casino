using Banking.Application.Interfaces;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Commands.TestModePaymentSystem;

public class TestModePaymentSystemCommandHandler : ICommandQueryHandler<TestModePaymentSystemCommand>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public TestModePaymentSystemCommandHandler(IPaymentSystemRepository paymentSystemRepository, IUnitOfWork unitOfWork)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(TestModePaymentSystemCommand request, CancellationToken cancellationToken)
    {
        var paymentSystem = await _paymentSystemRepository.GetPaymentSystemByIdAsync(request.PaymentSystemId, cancellationToken);

        if (paymentSystem is null)
            return Result.Failure(BankingDomainErrors.NotFound);

        paymentSystem.UpdateIsTest(request.IsTest);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

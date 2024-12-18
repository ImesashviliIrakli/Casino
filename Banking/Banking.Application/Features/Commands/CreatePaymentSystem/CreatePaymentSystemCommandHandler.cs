﻿using Banking.Application.Interfaces;
using Banking.Domain.Entities;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Commands.CreatePaymentSystem;

public class CreatePaymentSystemCommandHandler : ICommandQueryHandler<CreatePaymentSystemCommand>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreatePaymentSystemCommandHandler(IPaymentSystemRepository paymentSystemRepository, IUnitOfWork unitOfWork)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(CreatePaymentSystemCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(PaymentDirection), request.PaymentDirection))
            return Result.Failure(BankingDomainErrors.UnsupportedDirection);

        var paymentSystem = new PaymentSystem(
            request.Name,
            request.Description,
            request.MinimumLimit,
            request.MaximumLimit,
            request.PaymentDirection,
            request.IsTest,
            request.ImageUrl
        );

        await _paymentSystemRepository.AddAsync(paymentSystem, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

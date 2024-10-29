﻿using Banking.Application.Interfaces;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;
using MediatR;
using System.Runtime.InteropServices;

namespace Banking.Application.Deposit.EndBOGDeposit;

public class EndBOGDepositCommandHandler : ICommandQueryHandler<EndBOGDepositCommand>
{
    private readonly IPaymentRequestRepository _paymentRequestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public EndBOGDepositCommandHandler(
        IPaymentRequestRepository paymentRequestRepository, 
        IUnitOfWork unitOfWork,
        IMediator mediator
        )
    {
        _paymentRequestRepository = paymentRequestRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }
    public async Task<Result> Handle(EndBOGDepositCommand request, CancellationToken cancellationToken)
    {
        var paymentRequest = await _paymentRequestRepository.GetPaymentRequestByIdAsync(request.PaymentRequestId, cancellationToken);

        if (paymentRequest is null)
            return Result.Failure(BankingDomainErrors.PaymentRequestNotFound);

        if (paymentRequest.Status != TransactionStatus.Pending)
            return Result.Failure(BankingDomainErrors.AlreadyProcessedRequest);

        if (request.Amount != paymentRequest.Amount)
            return Result.Failure(BankingDomainErrors.DifferentAmounts);

        paymentRequest.UpdateStatus(request.TransactionStatus);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in paymentRequest.DomainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        return Result.Success();
    }
}

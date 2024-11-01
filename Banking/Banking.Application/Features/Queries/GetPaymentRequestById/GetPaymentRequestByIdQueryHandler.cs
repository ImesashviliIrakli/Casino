using AutoMapper;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Queries.GetPaymentRequestById;

public class GetPaymentRequestByIdQueryHandler : ICommandQueryHandler<GetPaymentRequestByIdQuery, PaymentRequestDetailsDto>
{
    private readonly IPaymentRequestRepository _paymentRequestRepository;
    private readonly IMapper _mapper;
    public GetPaymentRequestByIdQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
    {
        _paymentRequestRepository = paymentRequestRepository;
        _mapper = mapper;
    }
    public async Task<Result<PaymentRequestDetailsDto>> Handle(GetPaymentRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var paymentRequest = await _paymentRequestRepository.GetPaymentRequestByIdAsync(request.PaymentRequestId, cancellationToken);

        if (paymentRequest is null)
            return Result.Failure<PaymentRequestDetailsDto>(BankingDomainErrors.PaymentRequestNotFound);

        return _mapper.Map<PaymentRequestDetailsDto>(paymentRequest);
    }
}

using AutoMapper;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Queries.GetPaymentRequests;

public class GetPaymentRequestsQueryHandler : ICommandQueryHandler<GetPaymentRequestsQuery, List<PaymentRequestDto>>
{
    private readonly IPaymentRequestRepository _paymentRequestRepository;
    private readonly IMapper _mapper;
    public GetPaymentRequestsQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
    {
        _paymentRequestRepository = paymentRequestRepository;
        _mapper = mapper;
    }
    public async Task<Result<List<PaymentRequestDto>>> Handle(GetPaymentRequestsQuery request, CancellationToken cancellationToken)
    {
        var paymentRequests = await _paymentRequestRepository.GetPaymentRequestsAsync(request.FilterParameters, cancellationToken);

        return _mapper.Map<List<PaymentRequestDto>>(paymentRequests);
    }
}

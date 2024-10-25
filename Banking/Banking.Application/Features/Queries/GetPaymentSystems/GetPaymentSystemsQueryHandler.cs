using AutoMapper;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Queries.GetPaymentSystems;

public class GetPaymentSystemsQueryHandler : ICommandQueryHandler<GetPaymentSystemsQuery, List<PaymentSystemDto>>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IMapper _mapper;
    public GetPaymentSystemsQueryHandler(IPaymentSystemRepository paymentSystemRepository, IMapper mapper)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _mapper = mapper;
    }
   
    public async Task<Result<List<PaymentSystemDto>>> Handle(GetPaymentSystemsQuery request, CancellationToken cancellationToken)
    {
        var paymentSystems = await _paymentSystemRepository.GetPaymentSystemsAsync(request.PaymentDirection, request.IncludeTestPaymentSystems, cancellationToken);

        return _mapper.Map<List<PaymentSystemDto>>(paymentSystems);
    }
}

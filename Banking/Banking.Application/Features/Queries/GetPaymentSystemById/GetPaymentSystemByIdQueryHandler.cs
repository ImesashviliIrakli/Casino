using AutoMapper;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Errors;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;

namespace Banking.Application.Features.Queries.GetPaymentSystemById;

internal class GetPaymentSystemByIdQueryHandler : ICommandQueryHandler<GetPaymentSystemByIdQuery, PaymentSystemDto>
{
    private readonly IPaymentSystemRepository _paymentSystemRepository;
    private readonly IMapper _mapper;
    public GetPaymentSystemByIdQueryHandler(IPaymentSystemRepository paymentSystemRepository, IMapper mapper)
    {
        _paymentSystemRepository = paymentSystemRepository;
        _mapper = mapper;
    }
    public async Task<Result<PaymentSystemDto>> Handle(GetPaymentSystemByIdQuery request, CancellationToken cancellationToken)
    {
        var paymentSystem = await _paymentSystemRepository.GetPaymentSystemByIdAsync(request.PaymentSystemId, cancellationToken);

        if (paymentSystem is null)
            return Result.Failure<PaymentSystemDto>(BankingDomainErrors.NotFound);

        return _mapper.Map<PaymentSystemDto>(paymentSystem);
    }
}

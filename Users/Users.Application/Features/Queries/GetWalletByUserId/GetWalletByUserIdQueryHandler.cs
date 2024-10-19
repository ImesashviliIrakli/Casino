using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Users.Application.Interfaces;
using Users.Application.Models.Wallet;
using Users.Domain.Errors;

namespace Users.Application.Features.Queries.GetWalletByUserId;

public class GetWalletByUserIdQueryHandler : ICommandQueryHandler<GetWalletByUserIdQuery, WalletDto>
{
    private readonly IWalletRepository _walletRepository;
    private readonly IMapper _mapper;
    public GetWalletByUserIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
    {
        _walletRepository = walletRepository;
        _mapper = mapper;
    }
    public async Task<Result<WalletDto>> Handle(GetWalletByUserIdQuery request, CancellationToken cancellationToken)
    {
        var wallet = await _walletRepository.GetWalletByUserId(request.playerUserId);

        if (wallet is null)
            return Result.Failure<WalletDto>(UserDomainErrors.Wallet.NotFound);

        return _mapper.Map<WalletDto>(wallet);
    }
}

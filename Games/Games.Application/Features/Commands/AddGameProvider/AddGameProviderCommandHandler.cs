using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Entities;
using Games.Domain.Errors;

namespace Games.Application.Features.Commands.AddGameProvider;

public class AddGameProviderCommandHandler : ICommandQueryHandler<AddGameProviderCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AddGameProviderCommandHandler(IGameProviderRepository gameProviderRepository, IUnitOfWork unitOfWork)
    {
        _gameProviderRepository = gameProviderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(AddGameProviderCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(GameType), request.GameType))
            return Result.Failure(GameDomainErrors.UnsupportedGameType);

        GameProvider gameProvider = new(request.Name, request.ViewName, request.GameType);

        await _gameProviderRepository.AddAsync(gameProvider, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
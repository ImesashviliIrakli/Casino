using BuildingBlocks.Domain.Shared;

namespace Games.Domain.Errors;

public static class GameDomainErrors
{
    public static readonly Error GameNotFound = new(
           "NotFound",
           $"Game not found."
           );

    public static readonly Error ProviderNotFound = new(
           "NotFound",
           $"Provider not found."
           );

    public static readonly Error UnsupportedGameType = new(
           "BadRequest",
           $"Unsupported game type."
           );
    
}

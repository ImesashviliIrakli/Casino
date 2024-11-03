using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.AddGame;

public record AddGameCommand : ICommandQuery
{
    public Guid GameProviderId { get; set; }
    public string Name { get; set; }
    public string RealUrl { get; set; }
    public string GameId { get; set; }
    public string ImageUrl { get; set; }
}

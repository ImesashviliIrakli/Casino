using BuildingBlocks.Applictaion.Features;

namespace Games.Application.Features.Commands.UpdateGame;

public record UpdateGameCommand : ICommandQuery
{
    public Guid Id { get; set; }
    public Guid GameProviderId { get; set; }
    public string Name { get; set; }
    public string RealUrl { get; set; }
    public string GameId { get; set; }
    public string ImageUrl { get; set; }
    public bool ForTesting { get; set; }
    public bool IsDisabled { get; set; }
}

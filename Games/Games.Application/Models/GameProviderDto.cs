using BuildingBlocks.Domain.Enums;

namespace Games.Application.Models;

public class GameProviderDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ViewName { get; set; }
    public GameType GameType { get; set; }
    public bool IsDisabled { get; set; }
    public bool ForTesting { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
}

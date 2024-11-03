using Games.Domain.Entities;

namespace Games.Application.Models;

public class GameDto
{
    public Guid Id { get; set; }
    public Guid GameProviderId { get; set; }
    public GameProvider? GameProvider { get; set; }
    public string Name { get; set; }
    public string RealUrl { get; set; }
    public string GameId { get; set; }
    public string ImageUrl { get; set; }
    public bool ForTesting { get; set; }
    public bool IsDisabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

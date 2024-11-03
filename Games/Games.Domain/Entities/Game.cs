using BuildingBlocks.Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Domain.Entities;

public class Game : Entity
{
    [ForeignKey("GameProviderId")]
    public Guid GameProviderId { get; private set; }
    public GameProvider? GameProvider { get; set; }
    public string Name { get; private set; }
    public string RealUrl { get; private set; }
    public string GameId { get; private set; }
    public string ImageUrl { get; private set; }
    public bool ForTesting { get; private set; } = true;
    public bool IsDisabled { get; private set; } = false;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; }

    public Game()
    {

    }

    public Game(Guid gameProviderId, string name, string realUrl, string gameId, string imageUrl, bool forTesting, bool isDisabled)
    {
        Id = Guid.NewGuid();
        GameProviderId = gameProviderId;
        Name = name;
        RealUrl = realUrl;
        GameId = gameId;
        ImageUrl = imageUrl;
        ForTesting = forTesting;
        IsDisabled = isDisabled;
    }

    public void UpdateGameDetails(Guid gameProviderId, string name, string realUrl, string gameId, string imageUrl, bool forTesting, bool isDisabled)
    {
        GameProviderId = gameProviderId;
        Name = name;
        RealUrl = realUrl;
        GameId = gameId;
        ImageUrl = imageUrl;
        ForTesting = forTesting;
        IsDisabled = isDisabled;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateForTesting(bool forTesting) => ForTesting = forTesting;

    public void UpdateIsDisabled(bool isDisabled) => IsDisabled = isDisabled;

}

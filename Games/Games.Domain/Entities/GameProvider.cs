using BuildingBlocks.Domain.Enums;
using BuildingBlocks.Domain.Primitives;

namespace Games.Domain.Entities;

public class GameProvider : Entity
{
    public string Name { get; private set; }
    public string ViewName { get; private set; }
    public GameType GameType { get; private set; }
    public bool IsDisabled { get; private set; } = false;
    public bool ForTesting { get; private set; } = true;
    public string ImageUrl { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    // Navigation property
    public ICollection<Game> Games { get; set; }
    public GameProvider()
    {

    }

    public GameProvider(string name, string viewName, GameType gameType, bool isDisabled = false, bool forTesting = true, string imageUrl = "")
    {
        Id = Guid.NewGuid();
        Name = name;
        ViewName = viewName;
        GameType = gameType;
        IsDisabled = isDisabled;
        ForTesting = forTesting;
        ImageUrl = imageUrl;
    }

    public void UpdateProviderDetails(string name, string viewName, GameType gameType, bool forTesting = true, string imageUrl = "")
    {
        Name = name;
        ViewName = viewName;
        GameType = gameType;
        ForTesting = forTesting;
        ImageUrl = imageUrl;
    }

    public void UpdateIsDisabled(bool isDisabled)
    {
        IsDisabled = isDisabled;
    }

    public void UpdateForTesting(bool forTesting)
    {
        ForTesting = forTesting;
    }
}

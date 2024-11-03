using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Enums;

namespace Games.Application.Features.Commands.UpdateGameProvider;

public record UpdateGameProviderCommand : ICommandQuery
{
    public Guid GameProviderId { get; set; }
    public string Name { get; set; }
    public string ViewName { get; set; }
    public GameType GameType { get; set; }
    public bool IsDisabled { get; set; }
    public bool ForTesting { get; set; }
    public string ImageUrl { get; set; }
}
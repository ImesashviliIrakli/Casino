using MediatR;

namespace BuildingBlocks.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}

public abstract record DomainEvent(Guid Id) : IDomainEvent;
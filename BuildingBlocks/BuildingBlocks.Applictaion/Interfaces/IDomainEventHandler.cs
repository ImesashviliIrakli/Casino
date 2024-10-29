using BuildingBlocks.Domain.Primitives;
using MediatR;

namespace BuildingBlocks.Applictaion.Interfaces;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}

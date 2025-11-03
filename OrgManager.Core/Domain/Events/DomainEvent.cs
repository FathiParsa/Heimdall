using MediatR;

namespace OrgManager.Core.Domain.Events;

public abstract class DomainEvent : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

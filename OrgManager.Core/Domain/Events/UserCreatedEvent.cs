using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Events;

public class UserCreatedEvent : DomainEvent
{
    public User User { get; }

    public UserCreatedEvent(User user)
    {
        User = user;
    }
}

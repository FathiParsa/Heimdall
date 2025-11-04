using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Events;

public class UserUpdatedEvent : DomainEvent
{
    public User User { get; }

    public UserUpdatedEvent(User user)
    {
        User = user;
    }
}

using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Events;

public class UserDeletedEvent : DomainEvent
{
    public User User { get; }

    public UserDeletedEvent(User user)
    {
        User = user;
    }
}

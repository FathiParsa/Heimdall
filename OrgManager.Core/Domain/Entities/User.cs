using OrgManager.Core.Domain.Enums;
using OrgManager.Core.Domain.Events;

namespace OrgManager.Core.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FullName { get; private set; }
    public string? Department { get; private set; }
    public Role Role { get; private set; }
    public bool IsDeleted { get; private set; }

    private User(Guid id, string username, string email, string passwordHash, string fullName, string? department, Role role)
        : base(id)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        FullName = fullName;
        Department = department;
        Role = role;
        IsDeleted = false;
    }

    public static User Create(string username, string email, string passwordHash, string fullName, string? department, Role role)
    {
        var user = new User(Guid.NewGuid(), username, email, passwordHash, fullName, department, role);
        user.AddDomainEvent(new UserCreatedEvent(user));
        return user;
    }
}

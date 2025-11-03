using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Contracts.Infrastructure;

public interface IPasswordHasher
{
    string HashPassword(User user, string password);
}

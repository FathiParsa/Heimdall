using OrgManager.Core.Domain.Entities;

namespace OrgManager.Application.Contracts.Infrastructure;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

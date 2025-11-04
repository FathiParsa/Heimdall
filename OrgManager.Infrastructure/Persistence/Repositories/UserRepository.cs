using Microsoft.EntityFrameworkCore;
using OrgManager.Core.Domain.Repositories;
using OrgManager.Infrastructure.Persistence;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OrgManagerDbContext _dbContext;

    public UserRepository(OrgManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetCountAsync()
    {
        return await _dbContext.Users.CountAsync();
    }
}

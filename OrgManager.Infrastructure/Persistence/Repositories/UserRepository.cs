using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(OrgManagerDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public override async Task<IReadOnlyList<User>> GetAllAsync()
    {
        return await _dbContext.Users.Where(u => !u.IsDeleted).ToListAsync();
    }
}

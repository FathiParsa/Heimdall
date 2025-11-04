using Microsoft.EntityFrameworkCore;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Enums;
using OrgManager.Core.Domain.Repositories;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly OrgManagerDbContext _dbContext;

    public AdminRepository(OrgManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users
            .Where(u => u.Role == Role.Admin && !u.IsDeleted)
            .ToListAsync();
    }
}

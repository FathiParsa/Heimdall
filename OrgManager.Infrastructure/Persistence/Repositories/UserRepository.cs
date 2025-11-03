using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OrgManagerDbContext _context;

    public UserRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _context.Users.Where(u => ids.Contains(u.Id)).ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetCountAsync()
    {
        return await _context.Users.CountAsync();
    }
}

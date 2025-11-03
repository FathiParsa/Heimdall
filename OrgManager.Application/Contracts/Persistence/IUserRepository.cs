using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<IReadOnlyList<User>> GetAllAsync();
    Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task<User?> GetByIdAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<int> GetCountAsync();
}

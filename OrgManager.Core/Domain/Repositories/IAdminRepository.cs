using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Repositories;

public interface IAdminRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}

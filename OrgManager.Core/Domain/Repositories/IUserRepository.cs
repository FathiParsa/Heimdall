namespace OrgManager.Core.Domain.Repositories;

public interface IUserRepository
{
    Task<int> GetCountAsync();
}

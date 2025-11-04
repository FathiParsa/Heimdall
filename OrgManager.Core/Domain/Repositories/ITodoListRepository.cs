using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Repositories;

public interface ITodoListRepository
{
    Task AddAsync(TodoList todoList);
    Task<IEnumerable<TodoList>> GetByUserIdAsync(Guid userId);
}

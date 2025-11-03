using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface ITodoListRepository
{
    Task AddAsync(TodoList todoList);
    Task<TodoList?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<TodoList>> GetByUserIdAsync(Guid userId);
}

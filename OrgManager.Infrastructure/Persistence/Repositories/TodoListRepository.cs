using Microsoft.EntityFrameworkCore;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Repositories;
using OrgManager.Infrastructure.Persistence;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class TodoListRepository : ITodoListRepository
{
    private readonly OrgManagerDbContext _dbContext;

    public TodoListRepository(OrgManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(TodoList todoList)
    {
        await _dbContext.TodoLists.AddAsync(todoList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TodoList>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.TodoLists
            .Where(t => t.UserId == userId)
            .Include(t => t.Items)
            .ToListAsync();
    }
}

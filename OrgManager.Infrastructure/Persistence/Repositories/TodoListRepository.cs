using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class TodoListRepository : ITodoListRepository
{
    private readonly OrgManagerDbContext _context;

    public TodoListRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TodoList todoList)
    {
        await _context.TodoLists.AddAsync(todoList);
        await _context.SaveChangesAsync();
    }

    public async Task<TodoList?> GetByIdAsync(Guid id)
    {
        return await _context.TodoLists.Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IReadOnlyList<TodoList>> GetByUserIdAsync(Guid userId)
    {
        return await _context.TodoLists.Where(t => t.UserId == userId).Include(t => t.Items).ToListAsync();
    }
}

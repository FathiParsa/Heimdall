using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OrgManager.Core.Domain.Entities;

public class TodoList : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public ICollection<TodoItem> Items { get; private set; } = new List<TodoItem>();

    private TodoList(Guid id, Guid userId, string title) : base(id)
    {
        UserId = userId;
        Title = title;
    }

    public static TodoList Create(Guid userId, string title)
    {
        return new TodoList(Guid.NewGuid(), userId, title);
    }
}

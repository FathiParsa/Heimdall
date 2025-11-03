using OrgManager.Core.Domain.Entities;
using System;

namespace OrgManager.Core.Domain.Entities;

public class TodoItem : BaseEntity
{
    public Guid TodoListId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime? DueDate { get; private set; }
    public int Priority { get; private set; }
    public bool IsCompleted { get; private set; }

    private TodoItem(Guid id, Guid todoListId, string title, string description, DateTime? dueDate, int priority) : base(id)
    {
        TodoListId = todoListId;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        IsCompleted = false;
    }

    public static TodoItem Create(Guid todoListId, string title, string description, DateTime? dueDate, int priority)
    {
        return new TodoItem(Guid.NewGuid(), todoListId, title, description, dueDate, priority);
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}

namespace OrgManager.Application.Features.Todo.Dtos;

public class TodoListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<TodoItemDto> Items { get; set; }
}

public class TodoItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}

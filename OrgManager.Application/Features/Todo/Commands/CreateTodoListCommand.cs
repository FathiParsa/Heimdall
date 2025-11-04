using MediatR;

namespace OrgManager.Application.Features.Todo.Commands;

public class CreateTodoListCommand : IRequest<Guid>
{
    public string Title { get; set; }
}

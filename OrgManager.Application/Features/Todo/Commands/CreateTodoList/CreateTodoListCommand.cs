using MediatR;
using System;

namespace OrgManager.Application.Features.Todo.Commands.CreateTodoList;

public class CreateTodoListCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
}

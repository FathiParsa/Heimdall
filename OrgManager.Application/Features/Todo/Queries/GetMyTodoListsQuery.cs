using MediatR;
using OrgManager.Application.Features.Todo.Dtos;

namespace OrgManager.Application.Features.Todo.Queries;

public class GetMyTodoListsQuery : IRequest<IEnumerable<TodoListDto>>
{
}

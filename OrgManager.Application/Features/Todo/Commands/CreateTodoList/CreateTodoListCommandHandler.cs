using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Todo.Commands.CreateTodoList;

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoListRepository _todoListRepository;

    public CreateTodoListCommandHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var todoList = TodoList.Create(request.UserId, request.Title);
        await _todoListRepository.AddAsync(todoList);
        return todoList.Id;
    }
}

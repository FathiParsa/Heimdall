using MediatR;
using Microsoft.AspNetCore.Http;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Repositories;
using System.Security.Claims;

namespace OrgManager.Application.Features.Todo.Commands;

public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoListRepository _todoListRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateTodoListCommandHandler(ITodoListRepository todoListRepository, IHttpContextAccessor httpContextAccessor)
    {
        _todoListRepository = todoListRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var todoList = TodoList.Create(request.Title, userId);
        await _todoListRepository.AddAsync(todoList);
        return todoList.Id;
    }
}

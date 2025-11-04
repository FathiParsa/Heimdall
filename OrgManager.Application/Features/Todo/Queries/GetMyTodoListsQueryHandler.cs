using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using OrgManager.Application.Features.Todo.Dtos;
using OrgManager.Core.Domain.Repositories;
using System.Security.Claims;

namespace OrgManager.Application.Features.Todo.Queries;

public class GetMyTodoListsQueryHandler : IRequestHandler<GetMyTodoListsQuery, IEnumerable<TodoListDto>>
{
    private readonly ITodoListRepository _todoListRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetMyTodoListsQueryHandler(ITodoListRepository todoListRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _todoListRepository = todoListRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<TodoListDto>> Handle(GetMyTodoListsQuery request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var todoLists = await _todoListRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<TodoListDto>>(todoLists);
    }
}

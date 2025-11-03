using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Todo.Commands.CreateTodoList;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoListCommand command)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        command.UserId = userId;
        var todoListId = await _mediator.Send(command);
        return Ok(new { TodoListId = todoListId });
    }
}

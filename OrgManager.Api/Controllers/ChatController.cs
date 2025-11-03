using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Chat.Commands.CreateChatRoom;
using OrgManager.Application.Features.Chat.Commands.SendMessage;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("rooms")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateChatRoomCommand command)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (!command.UserIds.Contains(userId))
        {
            command.UserIds.Add(userId);
        }

        var chatRoomId = await _mediator.Send(command);
        return Ok(new { ChatRoomId = chatRoomId });
    }

    [HttpPost("messages")]
    public async Task<IActionResult> SendMessage([FromForm] SendMessageCommand command)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        command.UserId = userId;
        await _mediator.Send(command);
        return Ok();
    }
}

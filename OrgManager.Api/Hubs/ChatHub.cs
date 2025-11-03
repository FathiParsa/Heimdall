using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OrgManager.Application.Features.Chat.Commands.SendMessage;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrgManager.Api.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private readonly IMediator _mediator;

    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task SendMessage(Guid chatRoomId, string message)
    {
        var userId = Guid.Parse(Context.User.FindFirstValue(ClaimTypes.NameIdentifier));
        var command = new SendMessageCommand { ChatRoomId = chatRoomId, UserId = userId, Message = message };
        await _mediator.Send(command);

        await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", userId, message);
    }

    public async Task AddToGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace OrgManager.Api.Hubs;

[Authorize]
public class ChatHub : Hub
{
    public async Task SendMessage(Guid chatRoomId, string message)
    {
        await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", message);
    }

    public async Task AddToGroup(Guid chatRoomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }

    public async Task RemoveFromGroup(Guid chatRoomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }
}

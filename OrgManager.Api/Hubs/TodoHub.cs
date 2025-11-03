using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace OrgManager.Api.Hubs;

public class TodoHub : Hub
{
    public async Task SendTodoListUpdate()
    {
        await Clients.All.SendAsync("ReceiveTodoListUpdate");
    }
}

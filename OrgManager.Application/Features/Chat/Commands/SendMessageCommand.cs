using MediatR;

namespace OrgManager.Application.Features.Chat.Commands;

public class SendMessageCommand : IRequest
{
    public Guid ChatRoomId { get; set; }
    public string Message { get; set; }
}

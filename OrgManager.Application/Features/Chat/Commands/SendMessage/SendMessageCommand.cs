using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace OrgManager.Application.Features.Chat.Commands.SendMessage;

public class SendMessageCommand : IRequest
{
    public Guid ChatRoomId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public IFormFile? Attachment { get; set; }
}

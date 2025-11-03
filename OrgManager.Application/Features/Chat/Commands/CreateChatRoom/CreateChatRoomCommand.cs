using MediatR;
using System;
using System.Collections.Generic;

namespace OrgManager.Application.Features.Chat.Commands.CreateChatRoom;

public class CreateChatRoomCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public List<Guid> UserIds { get; set; } = new();
}

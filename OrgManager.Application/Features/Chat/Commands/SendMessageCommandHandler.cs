using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using OrgManager.Api.Hubs;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Repositories;
using System.Security.Claims;

namespace OrgManager.Application.Features.Chat.Commands;

public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
{
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IHubContext<ChatHub> _hubContext;

    public SendMessageCommandHandler(IChatMessageRepository chatMessageRepository, IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> hubContext)
    {
        _chatMessageRepository = chatMessageRepository;
        _httpContextAccessor = httpContextAccessor;
        _hubContext = hubContext;
    }

    public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var chatMessage = ChatMessage.Create(request.ChatRoomId, userId, request.Message);
        await _chatMessageRepository.AddAsync(chatMessage);

        await _hubContext.Clients.Group(request.ChatRoomId.ToString()).SendAsync("ReceiveMessage", userId, request.Message);

        return Unit.Value;
    }
}

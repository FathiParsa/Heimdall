using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Chat.Commands.CreateChatRoom;

public class CreateChatRoomCommandHandler : IRequestHandler<CreateChatRoomCommand, Guid>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IUserRepository _userRepository;

    public CreateChatRoomCommandHandler(IChatRoomRepository chatRoomRepository, IUserRepository userRepository)
    {
        _chatRoomRepository = chatRoomRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
    {
        var chatRoom = ChatRoom.Create(request.Name);
        var users = await _userRepository.GetByIdsAsync(request.UserIds);
        foreach (var user in users)
        {
            chatRoom.Users.Add(user);
        }

        await _chatRoomRepository.AddAsync(chatRoom);

        return chatRoom.Id;
    }
}

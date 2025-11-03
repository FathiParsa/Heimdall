using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface IChatMessageRepository
{
    Task AddAsync(ChatMessage chatMessage);
    Task<IReadOnlyList<ChatMessage>> GetByChatRoomIdAsync(Guid chatRoomId);
}

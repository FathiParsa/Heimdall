using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface IChatRoomRepository
{
    Task AddAsync(ChatRoom chatRoom);
    Task<ChatRoom?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<ChatRoom>> GetByUserIdAsync(Guid userId);
}

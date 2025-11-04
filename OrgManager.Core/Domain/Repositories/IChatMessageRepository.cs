using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Repositories;

public interface IChatMessageRepository
{
    Task AddAsync(ChatMessage chatMessage);
}

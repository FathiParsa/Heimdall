using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Repositories;
using OrgManager.Infrastructure.Persistence;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly OrgManagerDbContext _dbContext;

    public ChatMessageRepository(OrgManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(ChatMessage chatMessage)
    {
        await _dbContext.ChatMessages.AddAsync(chatMessage);
        await _dbContext.SaveChangesAsync();
    }
}

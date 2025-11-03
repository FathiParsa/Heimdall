using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly OrgManagerDbContext _context;

    public ChatMessageRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ChatMessage chatMessage)
    {
        await _context.ChatMessages.AddAsync(chatMessage);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<ChatMessage>> GetByChatRoomIdAsync(Guid chatRoomId)
    {
        return await _context.ChatMessages.Where(c => c.ChatRoomId == chatRoomId).OrderBy(c => c.Timestamp).ToListAsync();
    }
}

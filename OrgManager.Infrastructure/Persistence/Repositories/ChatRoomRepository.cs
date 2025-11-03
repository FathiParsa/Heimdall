using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class ChatRoomRepository : IChatRoomRepository
{
    private readonly OrgManagerDbContext _context;

    public ChatRoomRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ChatRoom chatRoom)
    {
        await _context.ChatRooms.AddAsync(chatRoom);
        await _context.SaveChangesAsync();
    }

    public async Task<ChatRoom?> GetByIdAsync(Guid id)
    {
        return await _context.ChatRooms.Include(c => c.Users).Include(c => c.Messages).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IReadOnlyList<ChatRoom>> GetByUserIdAsync(Guid userId)
    {
        return await _context.ChatRooms.Where(c => c.Users.Any(u => u.Id == userId)).ToListAsync();
    }
}

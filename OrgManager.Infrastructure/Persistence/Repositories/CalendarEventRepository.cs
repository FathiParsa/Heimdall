using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class CalendarEventRepository : ICalendarEventRepository
{
    private readonly OrgManagerDbContext _context;

    public CalendarEventRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CalendarEvent calendarEvent)
    {
        await _context.CalendarEvents.AddAsync(calendarEvent);
        await _context.SaveChangesAsync();
    }
}

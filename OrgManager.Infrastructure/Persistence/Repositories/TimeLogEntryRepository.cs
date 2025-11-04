using Microsoft.EntityFrameworkCore;
using OrgManager.Core.Domain.Entities;
using OrgManager.Core.Domain.Repositories;
using OrgManager.Infrastructure.Persistence;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class TimeLogEntryRepository : ITimeLogEntryRepository
{
    private readonly OrgManagerDbContext _dbContext;

    public TimeLogEntryRepository(OrgManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TimeLogEntry>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, Guid? userId)
    {
        var query = _dbContext.TimeLogEntries.AsQueryable();

        if (userId.HasValue)
        {
            query = query.Where(t => t.UserId == userId.Value);
        }

        return await query
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .ToListAsync();
    }
}

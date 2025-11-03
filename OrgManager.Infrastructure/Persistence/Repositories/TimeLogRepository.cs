using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class TimeLogRepository : ITimeLogRepository
{
    private readonly OrgManagerDbContext _context;

    public TimeLogRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TimeLogEntry timeLogEntry)
    {
        await _context.TimeLogEntries.AddAsync(timeLogEntry);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<TimeLogEntry>> GetReportAsync(DateTime? startDate, DateTime? endDate, Guid? userId)
    {
        var query = _context.TimeLogEntries.AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(t => t.Date >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(t => t.Date <= endDate.Value);
        }

        if (userId.HasValue)
        {
            query = query.Where(t => t.UserId == userId.Value);
        }

        return await query.ToListAsync();
    }
}

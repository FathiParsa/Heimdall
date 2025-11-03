using Microsoft.EntityFrameworkCore;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using OrgManager.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace OrgManager.Infrastructure.Persistence.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly OrgManagerDbContext _context;

    public AttendanceRepository(OrgManagerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AttendanceRecord attendanceRecord)
    {
        await _context.AttendanceRecords.AddAsync(attendanceRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<AttendanceRecord?> GetByIdAsync(Guid id)
    {
        return await _context.AttendanceRecords.FindAsync(id);
    }

    public async Task UpdateAsync(AttendanceRecord attendanceRecord)
    {
        _context.Entry(attendanceRecord).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

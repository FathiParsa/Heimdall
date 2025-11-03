using OrgManager.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface IAttendanceRepository
{
    Task AddAsync(AttendanceRecord attendanceRecord);
    Task<AttendanceRecord?> GetByIdAsync(Guid id);
    Task UpdateAsync(AttendanceRecord attendanceRecord);
}

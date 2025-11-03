using OrgManager.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface ITimeLogRepository
{
    Task AddAsync(TimeLogEntry timeLogEntry);
    Task<IReadOnlyList<TimeLogEntry>> GetReportAsync(DateTime? startDate, DateTime? endDate, Guid? userId);
}

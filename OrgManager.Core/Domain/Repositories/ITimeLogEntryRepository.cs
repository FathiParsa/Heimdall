using OrgManager.Core.Domain.Entities;

namespace OrgManager.Core.Domain.Repositories;

public interface ITimeLogEntryRepository
{
    Task<IEnumerable<TimeLogEntry>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, Guid? userId);
}

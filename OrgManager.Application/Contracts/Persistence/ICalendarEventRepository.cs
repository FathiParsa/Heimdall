using OrgManager.Core.Domain.Entities;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Persistence;

public interface ICalendarEventRepository
{
    Task AddAsync(CalendarEvent calendarEvent);
}

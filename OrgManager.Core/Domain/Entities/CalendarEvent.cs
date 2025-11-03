using OrgManager.Core.Domain.Entities;
using System;

namespace OrgManager.Core.Domain.Entities;

public class CalendarEvent : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    private CalendarEvent(Guid id, Guid userId, string title, string description, DateTime startTime, DateTime endTime) : base(id)
    {
        UserId = userId;
        Title = title;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static CalendarEvent Create(Guid userId, string title, string description, DateTime startTime, DateTime endTime)
    {
        // Add validation and domain logic here
        return new CalendarEvent(Guid.NewGuid(), userId, title, description, startTime, endTime);
    }
}

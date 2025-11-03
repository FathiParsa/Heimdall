using OrgManager.Core.Domain.Entities;
using System;

namespace OrgManager.Core.Domain.Entities;

public class TimeLogEntry : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime Date { get; private set; }
    public int DurationInMinutes { get; private set; }
    public string Category { get; private set; }
    public string Description { get; private set; }

    private TimeLogEntry(Guid id, Guid userId, DateTime date, int durationInMinutes, string category, string description) : base(id)
    {
        UserId = userId;
        Date = date;
        DurationInMinutes = durationInMinutes;
        Category = category;
        Description = description;
    }

    public static TimeLogEntry Create(Guid userId, DateTime date, int durationInMinutes, string category, string description)
    {
        // Add validation and domain logic here
        return new TimeLogEntry(Guid.NewGuid(), userId, date, durationInMinutes, category, description);
    }
}

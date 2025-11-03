using OrgManager.Core.Domain.Entities;
using System;

namespace OrgManager.Core.Domain.Entities;

public class AttendanceRecord : BaseEntity
{
    public Guid UserId { get; private set; }
    public DateTime CheckInTime { get; private set; }
    public DateTime? CheckOutTime { get; private set; }

    private AttendanceRecord(Guid id, Guid userId, DateTime checkInTime) : base(id)
    {
        UserId = userId;
        CheckInTime = checkInTime;
    }

    public static AttendanceRecord Create(Guid userId)
    {
        return new AttendanceRecord(Guid.NewGuid(), userId, DateTime.UtcNow);
    }

    public void CheckOut()
    {
        CheckOutTime = DateTime.UtcNow;
    }
}

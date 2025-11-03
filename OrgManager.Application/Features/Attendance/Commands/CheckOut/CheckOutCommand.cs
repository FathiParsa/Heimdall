using MediatR;
using System;

namespace OrgManager.Application.Features.Attendance.Commands.CheckOut;

public class CheckOutCommand : IRequest
{
    public Guid AttendanceRecordId { get; set; }
}

using MediatR;
using System;

namespace OrgManager.Application.Features.Attendance.Commands.CheckIn;

public class CheckInCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
}

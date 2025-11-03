using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Attendance.Commands.CheckIn;

public class CheckInCommandHandler : IRequestHandler<CheckInCommand, Guid>
{
    private readonly IAttendanceRepository _attendanceRepository;

    public CheckInCommandHandler(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<Guid> Handle(CheckInCommand request, CancellationToken cancellationToken)
    {
        var attendanceRecord = AttendanceRecord.Create(request.UserId);

        await _attendanceRepository.AddAsync(attendanceRecord);

        return attendanceRecord.Id;
    }
}

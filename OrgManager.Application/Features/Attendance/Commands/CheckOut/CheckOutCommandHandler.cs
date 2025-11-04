using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Application.Exceptions;
using OrgManager.Core.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Attendance.Commands.CheckOut;

public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand>
{
    private readonly IAttendanceRepository _attendanceRepository;

    public CheckOutCommandHandler(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        var attendanceRecord = await _attendanceRepository.GetByIdAsync(request.AttendanceRecordId);
        if (attendanceRecord == null)
        {
            throw new NotFoundException(nameof(AttendanceRecord), request.AttendanceRecordId);
        }

        attendanceRecord.CheckOut();
        await _attendanceRepository.UpdateAsync(attendanceRecord);
    }
}

using MediatR;
using OrgManager.Application.Contracts.Persistence;
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
            // In a real application, you would throw a custom exception
            // and handle it in a middleware.
            throw new System.Exception("Attendance record not found");
        }

        attendanceRecord.CheckOut();
        await _attendanceRepository.UpdateAsync(attendanceRecord);
    }
}

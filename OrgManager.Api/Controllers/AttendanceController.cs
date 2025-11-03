using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Attendance.Commands.CheckIn;
using OrgManager.Application.Features.Attendance.Commands.CheckOut;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AttendanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttendanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("checkin")]
    public async Task<IActionResult> CheckIn()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var command = new CheckInCommand { UserId = userId };
        var attendanceRecordId = await _mediator.Send(command);
        return Ok(new { AttendanceRecordId = attendanceRecordId });
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> CheckOut([FromBody] CheckOutCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}

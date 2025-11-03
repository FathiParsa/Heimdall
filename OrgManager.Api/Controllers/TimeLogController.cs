using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.TimeLog.Commands.LogTime;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TimeLogController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimeLogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> LogTime([FromBody] LogTimeCommand command)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        command.UserId = userId;
        var timeLogEntryId = await _mediator.Send(command);
        return Ok(new { TimeLogEntryId = timeLogEntryId });
    }
}

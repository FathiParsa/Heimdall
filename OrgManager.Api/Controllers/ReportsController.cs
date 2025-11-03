using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin, SuperAdmin")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("timelog")]
    public async Task<IActionResult> GetTimeLogReport([FromQuery] GetTimeLogReportQuery query)
    {
        var report = await _mediator.Send(query);
        return Ok(report);
    }
}

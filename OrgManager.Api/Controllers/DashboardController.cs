using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Dashboard.Queries.GetUserCount;
using System.Threading.Tasks;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin, SuperAdmin")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("usercount")]
    public async Task<IActionResult> GetUserCount()
    {
        var userCount = await _mediator.Send(new GetUserCountQuery());
        return Ok(userCount);
    }
}

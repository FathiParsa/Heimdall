using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrgManager.Application.Features.Admins.Queries;

namespace OrgManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var admins = await _mediator.Send(new GetAllAdminsQuery());
        return Ok(admins);
    }
}

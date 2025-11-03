using MediatR;
using System;

namespace OrgManager.Application.Features.Calendar.Commands.CreateEvent;

public class CreateEventCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

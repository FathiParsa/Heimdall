using MediatR;
using System;

namespace OrgManager.Application.Features.TimeLog.Commands.LogTime;

public class LogTimeCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.TimeLog.Commands.LogTime;

public class LogTimeCommandHandler : IRequestHandler<LogTimeCommand, Guid>
{
    private readonly ITimeLogRepository _timeLogRepository;

    public LogTimeCommandHandler(ITimeLogRepository timeLogRepository)
    {
        _timeLogRepository = timeLogRepository;
    }

    public async Task<Guid> Handle(LogTimeCommand request, CancellationToken cancellationToken)
    {
        var timeLogEntry = TimeLogEntry.Create(request.UserId, request.Date, request.DurationInMinutes, request.Category, request.Description);

        await _timeLogRepository.AddAsync(timeLogEntry);

        return timeLogEntry.Id;
    }
}

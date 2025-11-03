using MediatR;
using OrgManager.Application.Contracts.Persistence;
using OrgManager.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Calendar.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly ICalendarEventRepository _calendarEventRepository;

    public CreateEventCommandHandler(ICalendarEventRepository calendarEventRepository)
    {
        _calendarEventRepository = calendarEventRepository;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var calendarEvent = CalendarEvent.Create(request.UserId, request.Title, request.Description, request.StartTime, request.EndTime);

        await _calendarEventRepository.AddAsync(calendarEvent);

        return calendarEvent.Id;
    }
}

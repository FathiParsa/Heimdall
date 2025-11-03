using AutoMapper;
using MediatR;
using OrgManager.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;

public class GetTimeLogReportQueryHandler : IRequestHandler<GetTimeLogReportQuery, List<TimeLogReportDto>>
{
    private readonly ITimeLogRepository _timeLogRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetTimeLogReportQueryHandler(ITimeLogRepository timeLogRepository, IUserRepository userRepository, IMapper mapper)
    {
        _timeLogRepository = timeLogRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<TimeLogReportDto>> Handle(GetTimeLogReportQuery request, CancellationToken cancellationToken)
    {
        var timeLogEntries = await _timeLogRepository.GetReportAsync(request.StartDate, request.EndDate, request.UserId);
        var report = new List<TimeLogReportDto>();

        foreach (var entry in timeLogEntries)
        {
            var user = await _userRepository.GetByIdAsync(entry.UserId);
            var dto = _mapper.Map<TimeLogReportDto>(entry);
            dto.Username = user?.Username ?? "Unknown";
            report.Add(dto);
        }

        return report;
    }
}

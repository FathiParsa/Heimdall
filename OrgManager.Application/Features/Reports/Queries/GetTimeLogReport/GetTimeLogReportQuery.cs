using MediatR;
using System;
using System.Collections.Generic;

namespace OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;

public class GetTimeLogReportQuery : IRequest<List<TimeLogReportDto>>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? UserId { get; set; }
}

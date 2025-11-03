using System;

namespace OrgManager.Application.Features.Reports.Queries.GetTimeLogReport;

public class TimeLogReportDto
{
    public string Username { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

using MediatR;

namespace OrgManager.Application.Features.Reports.Queries;

public class ExportTimeLogReportQuery : IRequest<byte[]>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? UserId { get; set; }
    public string Format { get; set; } // "pdf" or "excel"
}

using MediatR;
using OrgManager.Core.Domain.Repositories;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace OrgManager.Application.Features.Reports.Queries;

public class ExportTimeLogReportQueryHandler : IRequestHandler<ExportTimeLogReportQuery, byte[]>
{
    private readonly ITimeLogEntryRepository _timeLogEntryRepository;

    public ExportTimeLogReportQueryHandler(ITimeLogEntryRepository timeLogEntryRepository)
    {
        _timeLogEntryRepository = timeLogEntryRepository;
    }

    public async Task<byte[]> Handle(ExportTimeLogReportQuery request, CancellationToken cancellationToken)
    {
        var timeLogs = await _timeLogEntryRepository.GetByDateRangeAsync(request.StartDate, request.EndDate, request.UserId);

        if (request.Format == "pdf")
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text("گزارش ساعات کاری")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("تاریخ");
                                header.Cell().Text("مدت زمان");
                                header.Cell().Text("توضیحات");
                            });

                            foreach (var log in timeLogs)
                            {
                                table.Cell().Text(log.Date.ToString("yyyy/MM/dd"));
                                table.Cell().Text(log.Duration.ToString());
                                table.Cell().Text(log.Description);
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("صفحه ");
                            x.CurrentPageNumber();
                        });
                });
            }).GeneratePdf();
        }

        // Add Excel export logic here
        return new byte[0];
    }
}

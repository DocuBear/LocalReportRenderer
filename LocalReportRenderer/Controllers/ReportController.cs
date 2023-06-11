using LocalReportRenderer.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;

namespace LocalReportRenderer.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    [HttpGet(Name = "Generate")]
    public IActionResult Get()
    {
        var order = new List<OrderDto>()
        {
            new OrderDto("Customer #1", "ABC123")
        };

        var lines = new List<OrderLineDto>()
        {
            new OrderLineDto("Product #1", 1, 10),
            new OrderLineDto("Product #2", 3, 5)
        };

        using (var reportDefinition = new StreamReader("Reports/Example.rdlc"))
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);
            report.DataSources.Add(new ReportDataSource("Order", order));
            report.DataSources.Add(new ReportDataSource("OrderLines", lines));

            byte[] pdf = report.Render("PDF");

            return File(pdf, "application/pdf", "Example.pdf");
        }
    }
}

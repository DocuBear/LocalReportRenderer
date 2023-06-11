using LocalReportRenderer.DTOs;
using System.Text;

namespace LocalReportRenderer;

public static class ReportDatasourceCreator
{
    public static void Create()
    {
        var types = new[] { typeof(OrderDto), typeof(OrderLineDto) };

        var xri = new System.Xml.Serialization.XmlReflectionImporter();
        var xss = new System.Xml.Serialization.XmlSchemas();
        var xse = new System.Xml.Serialization.XmlSchemaExporter(xss);

        foreach (var type in types)
        {
            var xtm = xri.ImportTypeMapping(type);
            xse.ExportTypeMapping(xtm);
        }

        using var sw = new System.IO.StreamWriter("Reports/ReportItemSchemas.xsd", false, Encoding.UTF8);
        for (int i = 0; i < xss.Count; i++)
        {
            var xs = xss[i];
            xs.Id = "ReportItemSchemas";
            xs.Write(sw);
        }
    }
}
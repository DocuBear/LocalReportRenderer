namespace LocalReportRenderer.DTOs;

public class OrderDto
{
    public OrderDto()
    {
        
    }

    public OrderDto(string customerName, string reference)
    {
        CustomerName = customerName;
        Reference = reference;
    }

    public string CustomerName { get; set; }
    public string Reference { get; set; }
}

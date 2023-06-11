namespace LocalReportRenderer.DTOs;

public class OrderLineDto
{
    public OrderLineDto()
    {
        
    }

    public OrderLineDto(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
        Total = quantity * price;
    }

    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double Total { get; set; }
}

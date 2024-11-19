namespace eTicaretServer.Models;

public sealed class Order
{
    public Order()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string OrderNumber { get; set; } = CreateOrderNumber();
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }

    public static string CreateOrderNumber()
    {
        string s = "S2024" + DateTime.Now.ToFileTime();
        return s;
    }
}

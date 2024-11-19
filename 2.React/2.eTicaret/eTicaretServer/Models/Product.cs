namespace eTicaretServer.Models;

public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public int Stock { get; set; }
    public decimal Price { get; set; }
}
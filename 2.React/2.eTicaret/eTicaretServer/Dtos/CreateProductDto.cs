namespace eTicaretServer.Dtos;

public sealed class CreateProductDto
{
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
}

namespace StokTakip.WebAPI.Dtos;

public sealed record CreateProductDto(
    string Name,
    int Stock,
    decimal Price);

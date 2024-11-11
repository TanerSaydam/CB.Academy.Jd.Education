namespace StokTakip.WebAPI.Dtos;

public sealed record UpdateProductDto(
    Guid Id,
    string Name,
    int Stock,
    decimal Price);
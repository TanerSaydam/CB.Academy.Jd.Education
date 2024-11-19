namespace eTicaretServer.Dtos;

public sealed record AddShoppingCartDto(
    Guid ProductId,
    int Quantity);

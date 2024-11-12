﻿namespace StokTakip.WebAPI.Models;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public decimal Price { get; set; }
}

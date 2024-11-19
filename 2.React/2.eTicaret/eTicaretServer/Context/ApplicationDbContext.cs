using eTicaretServer.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicaretServer.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
}

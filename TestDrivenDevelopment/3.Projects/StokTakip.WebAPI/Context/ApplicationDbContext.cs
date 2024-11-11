using GenericRepository;
using Microsoft.EntityFrameworkCore;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Context;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}

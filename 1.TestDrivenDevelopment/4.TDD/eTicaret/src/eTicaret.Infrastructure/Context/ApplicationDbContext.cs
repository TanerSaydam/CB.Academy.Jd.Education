using eTicaret.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.Context;
public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = default!;
}
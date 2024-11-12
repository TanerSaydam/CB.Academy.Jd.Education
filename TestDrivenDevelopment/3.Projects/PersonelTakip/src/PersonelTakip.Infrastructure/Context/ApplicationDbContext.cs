using GenericRepository;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Domain.Models;

namespace PersonelTakip.Infrastructure.Context;
internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}

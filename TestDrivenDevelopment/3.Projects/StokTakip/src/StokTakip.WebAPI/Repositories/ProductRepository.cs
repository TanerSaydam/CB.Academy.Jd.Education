using GenericRepository;
using StokTakip.WebAPI.Context;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Repositories;

public sealed class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}

using StokTakip.WebAPI.Context;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;

namespace StokTakip.WebAPI.Services;

public interface IProductService
{
    Task<Product> CreateAsync(CreateProductDto request, CancellationToken cancellationToken);
    Task<Product> UpdateAsync(UpdateProductDto request, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
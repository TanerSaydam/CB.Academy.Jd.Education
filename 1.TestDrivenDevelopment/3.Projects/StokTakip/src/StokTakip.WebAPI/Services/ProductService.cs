using AutoMapper;
using FluentValidation;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using StokTakip.WebAPI.Dtos;
using StokTakip.WebAPI.Models;
using StokTakip.WebAPI.Repositories;
using StokTakip.WebAPI.Validations;

namespace StokTakip.WebAPI.Services;

public sealed class ProductService(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : IProductService
{
    public async Task<Product> CreateAsync(CreateProductDto request, CancellationToken cancellationToken)
    {
        CreateProductDtoValidator validator = new();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        bool isProductNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductNameExists)
        {
            throw new ArgumentException("Ürün adı daha önce kullanılmış");
        }

        Product product = mapper.Map<Product>(request);

        productRepository.Add(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentNullException();
        }

        productRepository.Delete(product);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAll().ToListAsync(cancellationToken);

        return products;
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentNullException();
        }

        return product;
    }

    public async Task<Product> UpdateAsync(UpdateProductDto request, CancellationToken cancellationToken)
    {
        UpdateProductDtoValidator validator = new();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        Product? product = await productRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentNullException();
        }

        if (product.Name != request.Name)
        {
            bool isProductNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isProductNameExists)
            {
                throw new ArgumentException("Ürün adı daha önce kullanılmış");
            }
        }

        mapper.Map(request, product);

        await unitOfWork.SaveChangesAsync();
        return product;
    }
}

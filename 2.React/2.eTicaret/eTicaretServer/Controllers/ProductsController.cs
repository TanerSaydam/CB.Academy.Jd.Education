using eTicaretServer.Abstractions;
using eTicaretServer.Context;
using eTicaretServer.Dtos;
using eTicaretServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicaretServer.Controllers;

public sealed class ProductsController(
    ApplicationDbContext context) : CommonApi
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var products = await context.Products.OrderBy(p => p.Name).ToListAsync(cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto request, CancellationToken cancellationToken)
    {
        bool isNameExists = await context.Products.AnyAsync(p => p.Name == request.Name, cancellationToken);

        if (isNameExists)
        {
            return BadRequest(new { Message = "Ürün adı daha önce oluşturulmuş" });
        }

        Product product = new()
        {
            Name = request.Name,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            Stock = request.Stock,
        };

        await context.Products.AddAsync(product);

        await context.SaveChangesAsync(cancellationToken);

        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto request, CancellationToken cancellationToken)
    {
        Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product is null)
        {
            return NotFound();
        }

        if (request.Name != product.Name)
        {
            bool isNameExists = await context.Products.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isNameExists)
            {
                return BadRequest(new { Message = "Ürün adı daha önce oluşturulmuş" });
            }
        }

        product.Name = request.Name;
        product.ImageUrl = request.ImageUrl;
        product.Price = request.Price;
        product.Stock = request.Stock;

        await context.SaveChangesAsync(cancellationToken);

        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product is null)
        {
            return NotFound();
        }

        context.Products.Remove(product);

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}

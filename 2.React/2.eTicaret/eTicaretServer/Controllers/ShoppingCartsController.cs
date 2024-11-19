using eTicaretServer.Abstractions;
using eTicaretServer.Context;
using eTicaretServer.Dtos;
using eTicaretServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicaretServer.Controllers;

public sealed class ShoppingCartsController(
    ApplicationDbContext context) : CommonApi
{
    [HttpPost]
    public async Task<IActionResult> Add(AddShoppingCartDto request, CancellationToken cancellationToken)
    {
        ShoppingCart cart = new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
        };

        context.Add(cart);
        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var shoppingCars = await context.ShoppingCarts.Include(p => p.Product).ToListAsync(cancellationToken);

        return Ok(shoppingCars);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        ShoppingCart? shoppingCart = await context.ShoppingCarts.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (shoppingCart is null)
        {
            return NotFound();
        }

        context.ShoppingCarts.Remove(shoppingCart);

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpGet("Pay")]
    public async Task<IActionResult> Pay(CancellationToken cancellationToken)
    {
        var carts = await context.ShoppingCarts.Include(p => p.Product).ToListAsync(cancellationToken);

        foreach (var cart in carts)
        {
            Order order = new()
            {
                OrderDate = DateTime.Now,
                Price = cart.Product!.Price,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity
            };

            context.Orders.Add(order);
        }

        context.RemoveRange(carts);

        await context.SaveChangesAsync(cancellationToken);

        return Ok(new { Message = "Ödeme başarıyla tamamlandı" });
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetCount(CancellationToken cancellationToken)
    {
        var count = await context.ShoppingCarts.CountAsync(cancellationToken);

        return Ok(count);
    }
}

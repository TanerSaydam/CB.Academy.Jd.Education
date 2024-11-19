using eTicaretServer.Abstractions;
using eTicaretServer.Context;
using eTicaretServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicaretServer.Controllers;

public sealed class ShoppingCartsController(
    ApplicationDbContext context) : CommonApi
{
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
}

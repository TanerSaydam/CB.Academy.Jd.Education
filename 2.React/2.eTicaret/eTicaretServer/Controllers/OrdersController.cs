using eTicaretServer.Abstractions;
using eTicaretServer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicaretServer.Controllers;

public sealed class OrdersController(
    ApplicationDbContext context) : CommonApi
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var orders = await context.Orders.Include(p => p.Product).ToListAsync(cancellationToken);

        return Ok(orders);
    }
}
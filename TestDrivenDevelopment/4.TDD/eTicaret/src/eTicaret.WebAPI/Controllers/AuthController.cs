using eTicaret.Application;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Ok();
    }
}

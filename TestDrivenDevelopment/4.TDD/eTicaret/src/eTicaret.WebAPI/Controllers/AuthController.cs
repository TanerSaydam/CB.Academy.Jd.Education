using eTicaret.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Ok();
    }
}

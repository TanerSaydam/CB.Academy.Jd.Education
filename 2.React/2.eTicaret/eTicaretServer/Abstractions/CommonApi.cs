using Microsoft.AspNetCore.Mvc;

namespace eTicaretServer.Abstractions;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class CommonApi : ControllerBase
{
}

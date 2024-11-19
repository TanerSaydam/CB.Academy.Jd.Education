using Microsoft.AspNetCore.Mvc;

namespace eTicaretServer.Abstractions;

[Route("api/[controller]")]
[ApiController]
public abstract class CommonApi : ControllerBase
{
}

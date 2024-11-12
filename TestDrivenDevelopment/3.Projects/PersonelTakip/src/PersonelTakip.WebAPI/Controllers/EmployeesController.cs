using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonelTakip.Application.Features.Employees;
using PersonelTakip.WebAPI.AOP;

namespace PersonelTakip.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class EmployeesController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    [EnableQueryWithMetadata]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetAllEmployeesQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GetEmployeeByIdQuery(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DeleteEmployeeByIdCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
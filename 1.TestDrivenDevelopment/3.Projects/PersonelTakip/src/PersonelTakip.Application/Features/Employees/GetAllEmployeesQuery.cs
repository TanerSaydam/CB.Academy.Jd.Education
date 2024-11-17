using MediatR;
using PersonelTakip.Domain.Models;
using PersonelTakip.Domain.Repositories;

namespace PersonelTakip.Application.Features.Employees;
public sealed record GetAllEmployeesQuery() : IRequest<IQueryable<Employee>>;

internal sealed class GetAllEmployeesQueryHandler(
    IEmployeeRepository employeeRepository) : IRequestHandler<GetAllEmployeesQuery, IQueryable<Employee>>
{
    public Task<IQueryable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = employeeRepository.GetAll();

        return Task.FromResult(employees);
    }
}
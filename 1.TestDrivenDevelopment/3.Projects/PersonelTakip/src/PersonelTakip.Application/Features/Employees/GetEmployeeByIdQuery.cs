using MediatR;
using PersonelTakip.Domain.Models;
using PersonelTakip.Domain.Repositories;
using TS.Result;

namespace PersonelTakip.Application.Features.Employees;
public sealed record GetEmployeeByIdQuery(
    Guid Id) : IRequest<Result<Employee>>;

internal sealed class GetEmployeeByIdQueryHandler(
    IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, Result<Employee>>
{
    public async Task<Result<Employee>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (employee is null)
        {
            return Result<Employee>.Failure("Personel bulunamadı");
        }

        return employee;
    }
}

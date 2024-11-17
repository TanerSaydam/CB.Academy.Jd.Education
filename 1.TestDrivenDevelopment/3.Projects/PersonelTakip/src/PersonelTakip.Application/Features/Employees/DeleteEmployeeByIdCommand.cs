using GenericRepository;
using MediatR;
using PersonelTakip.Domain.Repositories;
using TS.Result;

namespace PersonelTakip.Application.Features.Employees;
public sealed record DeleteEmployeeByIdCommand(
    Guid Id) : IRequest<Result<string>>;

internal sealed class DeleteEmployeeByIdCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmployeeByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (employee is null)
        {
            return Result<string>.Failure("Personel bulunamadı");
        }

        employee.IsDeleted = true;
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel başarıyla silindi";
    }
}
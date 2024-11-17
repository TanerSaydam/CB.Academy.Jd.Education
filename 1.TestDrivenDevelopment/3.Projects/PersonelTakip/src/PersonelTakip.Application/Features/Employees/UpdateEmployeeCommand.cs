using AutoMapper;
using FluentValidation;
using GenericRepository;
using MediatR;
using PersonelTakip.Domain.Repositories;
using TS.Result;

namespace PersonelTakip.Application.Features.Employees;
public sealed record UpdateEmployeeCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string IdentityNumber,
    DateOnly StartDate,
    decimal Salary) : IRequest<Result<string>>;

public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(p => p.FirstName).MinimumLength(3).WithMessage("Personel adı en az 3 karakter olmalıdır");
        RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Personel soyadı en az 3 karakter olmalıdır");
        RuleFor(p => p.IdentityNumber)
            .MinimumLength(11).WithMessage("TC numarası 11 karakter olmalıdır")
            .MaximumLength(11).WithMessage("TC numarası 11 karakter olmalıdır");
        RuleFor(p => p.Salary).GreaterThanOrEqualTo(17002).WithMessage("Ücret asgari ücretten az olamaz");
    }
}

internal sealed class UpdateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmployeeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (employee is null)
        {
            return Result<string>.Failure("Personel bulunamadı");
        }

        if (employee.IdentityNumber != request.IdentityNumber)
        {
            bool isIdentityNumberExists = await employeeRepository.AnyAsync(p => p.IdentityNumber == request.IdentityNumber, cancellationToken);

            if (isIdentityNumberExists)
            {
                return Result<string>.Failure("TC numarası daha önce kaydedilmiş");
            }

            bool isIdentityNumberAvaliable = request.IdentityNumber.IsIdentityNumberAvailable();
            if (!isIdentityNumberAvaliable)
            {
                return Result<string>.Failure("TC numarası geçersiz");
            }
        }

        mapper.Map(request, employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel başarıyla güncellendi";
    }
}
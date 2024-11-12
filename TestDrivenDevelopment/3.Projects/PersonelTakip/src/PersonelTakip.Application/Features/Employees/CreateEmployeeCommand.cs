using AutoMapper;
using FluentValidation;
using GenericRepository;
using MediatR;
using PersonelTakip.Domain.Models;
using PersonelTakip.Domain.Repositories;
using TS.Result;

namespace PersonelTakip.Application.Features.Employees;
public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string IdentityNumber,
    DateOnly StartDate,
    decimal Salary) : IRequest<Result<string>>;

public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(p => p.FirstName).MinimumLength(3).WithMessage("Personel adı en az 3 karakter olmalıdır");
        RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Personel soyadı en az 3 karakter olmalıdır");
        RuleFor(p => p.IdentityNumber)
            .MinimumLength(11).WithMessage("TC numarası 11 karakter olmalıdır")
            .MaximumLength(11).WithMessage("TC numarası 11 karakter olmalıdır");
        RuleFor(p => p.Salary).GreaterThanOrEqualTo(17002).WithMessage("Ücret asgari ücretten az olamaz");
    }
}

internal sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateEmployeeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
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

        Employee employee = mapper.Map<Employee>(request);

        employeeRepository.Add(employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel kaydı başarılı";
    }
}
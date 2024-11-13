using FluentValidation;
using StokTakip.WebAPI.Dtos;

namespace StokTakip.WebAPI.Validations;

public sealed class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır");
        RuleFor(p => p.Stock).GreaterThan(0).WithMessage("Stok adedi 0 dan büyük olmalıdır");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Birim fiyatı 0 dan büyük olmalıdır");
    }
}

using BirlesikOdeme.API.Dtos;
using FluentValidation;

namespace BirlesikOdeme.API.Validation
{
    public class MernisValidator : AbstractValidator<CitizenRequestModel>
    {
        public MernisValidator()
        {
            RuleFor(x => x.Ad).NotNull().NotEmpty().WithMessage("Ad alanı zorunludur.");
            RuleFor(x => x.Soyad).NotNull().NotEmpty().WithMessage("Soyad alanı zorunludur.");
            RuleFor(x => x.DogumTarihi).NotNull().NotEmpty().LessThan(p => 2023);
            RuleFor(a => a.TcKimlikNo).NotNull().NotEmpty()
                    .Must(w => w.ToString().Length == 11)
                    .WithMessage("Tc Kimlik No 11 karakter olmak zorundadır.");


        }
    }
}

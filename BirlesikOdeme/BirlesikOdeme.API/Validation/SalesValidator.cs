using BirlesikOdeme.Core.Entities.Dtos;
using FluentValidation;

namespace BirlesikOdeme.API.Validation
{
    public class SalesValidator : AbstractValidator<SalesRequestModel>
    {
        public SalesValidator()
        {
            RuleFor(x => x.BankaAdi).NotNull().NotEmpty().WithMessage("Banka Adı alanı zorunludur.");
            RuleFor(x => x.KartNumarasi).NotNull().NotEmpty()
                .Must(w => w.Length == 16).WithMessage("Kart numarası alanı 16 karakter olmak zorundadır.");
            RuleFor(x => x.KartSonKullanmaAyi).InclusiveBetween("1", "12").NotNull().NotEmpty()
                .Must(w => w.Length == 2).WithMessage("Kart son kullanma ayı giriniz. Örn Ocak ise 1 , Aralık ise 12");
            RuleFor(x => x.KartSonKullanmaYili).NotNull().NotEmpty()
                .Must(w => w.Length == 2).GreaterThan(w=> "21").WithMessage("Kart son kullanma yılı son iki hanesi. Örn: 2025 ise 25 olarak giriniz.");
           //kart kullanma yılı 2021den büyük olmalı
        }
    }
}

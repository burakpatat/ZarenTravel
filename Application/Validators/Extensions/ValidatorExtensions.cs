using FluentValidation;
using FluentValidation.Validators;
using WordyWellHero.Application.Interfaces.Serialization.Serializers;

namespace WordyWellHero.Application.Validators.Extensions
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeJson<T>(this IRuleBuilder<T, string> ruleBuilder, IPropertyValidator<T, string> validator) where T : class
        {
            return ruleBuilder.SetValidator(validator);
        }
    }
}
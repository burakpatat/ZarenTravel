
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


public static class ValidatorConfigration
{
    public static IServiceCollection AddValidatorConfigrationLayer(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(ValidationFilter));
        }).AddFluentValidation(c =>
        {
                //c.RegisterValidatorsFromAssemblyContaining<MyListValidator>();
                //c.RegisterValidatorsFromAssemblyContaining<MyListSMAValidator>();
                c.ImplicitlyValidateChildProperties = true;
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}

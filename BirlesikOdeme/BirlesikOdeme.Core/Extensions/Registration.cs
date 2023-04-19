using BirlesikOdeme.Core.Services.Classes;
using BirlesikOdeme.Core.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace BirlesikOdeme.Core.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrasturctureRegistration(this IServiceCollection services)
        {
            services.AddTransient<IMernisService, MernisService>();
            services.AddTransient<IRestService, RestService>();
            return services;
        }

        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddValidatorsFromAssembly(assm);
            return services;
        }
    }
}

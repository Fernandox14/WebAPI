

using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using WebAPI.Application;

namespace WebAPI.Ioc
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluent(this IServiceCollection services, Type assemblyContainingValidators)
        {
            services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssemblyContaining(assemblyContainingValidators);
                conf.AutomaticValidationEnabled = false;
                conf.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
            });

            return services;
        }

    }
}


using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Application.Validation;
using WebAPI.Application.Mapping;
using WebAPI.Ioc;
using WebAPI.Application.interfaces;
using WebAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Database;
using Pr.Web.Infra.Repository;
using WebAPI.Domain.Interfaces;

namespace WebAPI.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySQL("Database=autoglas;Data Source=127.0.0.1;User Id=autoglas;Password=autoglas", 
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ConfigurationMapping));
            services.AddFluent(typeof(ProductDTOValidator));

            return services;
        }
    }
}
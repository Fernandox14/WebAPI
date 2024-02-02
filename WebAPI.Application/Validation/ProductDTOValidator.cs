using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Entities.DTO;

namespace WebAPI.Application.Validation
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(model => model.Description).NotEmpty();
            RuleFor(model => model.Description).NotEmpty().MinimumLength(10).MaximumLength(255);
            RuleFor(model => model.DateManufacturing).NotEmpty().Must(x=> x  > new DateTime (1900,01,01));
            RuleFor(model => model.DateValidation).NotEmpty().Must(x => x > new DateTime(1900, 01, 01));
            RuleFor(model => model.Status).NotEmpty().MinimumLength(5).MaximumLength(7);
            RuleFor(model => model.Status).Must(x=> x == "Ativo" || x == "Inativo");
            RuleFor(model => model.Provider!.Document).InclusiveBetween(1, 99999999999999);
            RuleFor(model => model.Provider!.Description).NotEmpty().MinimumLength(10).MaximumLength(255);
            RuleFor(model => model.DateManufacturing).LessThan(r => r.DateValidation)
                .WithMessage("Data de fabricação não pode ser maior ou igual a data de validade");
        }
    }
}

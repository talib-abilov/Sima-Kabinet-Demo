using FluentValidation;
using SimaApp.Application.Features.Companies.Command.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommandRequest>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x=> x.Name)
                .NotEmpty();

            RuleFor(x=>x.TIN)
                .NotEmpty();
        }
    }
}

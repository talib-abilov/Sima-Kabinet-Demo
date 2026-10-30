using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.UpdateCompany
{
    public class UpdateCompanyCommandValidator:AbstractValidator<UpdateCompanyCommandRequest>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(x=>x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x=>x.TIN)
                .NotEmpty();

        }
    }
}

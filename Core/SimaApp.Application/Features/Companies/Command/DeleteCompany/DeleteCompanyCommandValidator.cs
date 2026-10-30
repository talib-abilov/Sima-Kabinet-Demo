using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Companies.Command.DeleteCompany
{
    public class DeleteCompanyCommandValidator:AbstractValidator<DeleteCompanyCommandRequest>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}

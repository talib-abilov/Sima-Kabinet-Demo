using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateEmployeeCompany
{
    public class CreateEmployeeCompanyCommandValidator : AbstractValidator<CreateEmployeeCompanyCommandRequest>
    {
       
        public CreateEmployeeCompanyCommandValidator()
        {
            RuleFor(x => x.Position)
                .NotEmpty();
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Surname)
                .NotEmpty();
            RuleFor(x => x.Fullname)
                .NotEmpty();
            RuleFor(x => x.CompanyId)
                .GreaterThan(0);
        }
    }
}

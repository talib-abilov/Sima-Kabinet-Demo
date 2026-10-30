using FluentValidation;
using SimaApp.Application.Features.Companies.Command.DeleteCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.DeleteEmployeeCompany
{
    public class DeleteEmployeeCompanyCommandValidator : AbstractValidator<DeleteCompanyCommandRequest>
    {
        public DeleteEmployeeCompanyCommandValidator()
        {
            RuleFor(x=>x.Id)
                .GreaterThan(0);
        }
    }
}

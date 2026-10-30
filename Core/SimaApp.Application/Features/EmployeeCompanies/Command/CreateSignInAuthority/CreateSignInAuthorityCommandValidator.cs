using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateSignInAuthority
{
    public class CreateSignInAuthorityCommandValidator:AbstractValidator<CreateSignInAuthorityCommandRequest>
    {
        public CreateSignInAuthorityCommandValidator()
        {
            RuleFor(x=>x.EmployeesCompaniesId)
                .NotEmpty();
        }
    }
}

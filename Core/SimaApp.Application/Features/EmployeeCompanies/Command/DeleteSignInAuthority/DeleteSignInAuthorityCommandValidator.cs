using FluentValidation;
using SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignIntAuthority;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.DeleteSignInAuthority
{
    public class DeleteSignInAuthorityCommandValidator : AbstractValidator<DeleteSignIntAuthorityCommandRequest>
    {
        public DeleteSignInAuthorityCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}

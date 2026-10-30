using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommandRequest>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}

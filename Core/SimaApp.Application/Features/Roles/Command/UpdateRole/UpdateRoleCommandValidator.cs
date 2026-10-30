using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.UpdateRole
{
    public class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommandRequest>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}

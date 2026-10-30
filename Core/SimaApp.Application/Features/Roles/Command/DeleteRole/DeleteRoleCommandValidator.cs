using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandValidator:AbstractValidator<DeleteRoleCommandRequest>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty();
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteRole
{
    public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommandRequest>
    {
        public DeleteUserRoleCommandValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0);
            
        }
    }
}

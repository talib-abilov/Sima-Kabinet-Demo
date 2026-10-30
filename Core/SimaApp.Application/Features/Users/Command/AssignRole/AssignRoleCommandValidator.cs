using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.AssignRole
{
    public class AssignRoleCommandValidator : AbstractValidator<AssignRoleCommandRequest>
    {
        public AssignRoleCommandValidator()
        {
            RuleFor(x => x.UserProfileId)
                .GreaterThan(0);
            RuleFor(x => x.RoleId)
                .GreaterThan(0);
        }
    }
}

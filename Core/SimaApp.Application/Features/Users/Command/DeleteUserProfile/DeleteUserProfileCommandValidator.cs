using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteUserProfile
{
    public class DeleteUserProfileCommandValidator:AbstractValidator<DeleteUserProfileCommandRequest>
    {
        public DeleteUserProfileCommandValidator()
        {

            RuleFor(x => x.Id)
               .GreaterThan(0);
        }
    }
}

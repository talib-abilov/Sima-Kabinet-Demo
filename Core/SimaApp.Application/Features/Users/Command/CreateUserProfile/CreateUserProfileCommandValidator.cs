using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.CreateUserProfile
{
    public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommandRequest>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(x => x.UserId)
               .GreaterThan(0);
            RuleFor(x => x.CompanyId)
                .GreaterThan(0);
        }
    }
}

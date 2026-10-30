using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQueryRequest>
    {
        public GetUserQueryValidator()
        {

            RuleFor(x => x.Id)
               .GreaterThan(0);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Queries.GetRole
{
    public class GetRoleQueryValidator:AbstractValidator<GetRoleQueryRequest>
    {
        public GetRoleQueryValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty();
        }
    }
}

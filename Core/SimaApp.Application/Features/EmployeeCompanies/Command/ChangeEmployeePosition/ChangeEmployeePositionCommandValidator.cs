using FluentValidation;
using SimaApp.Application.Features.EmployeeCompanies.Command.ChangePosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.ChangeEmployeePosition
{
    public class ChangeEmployeePositionCommandValidator : AbstractValidator<ChangeEmployeePositionCommandRequest>
    {
        public ChangeEmployeePositionCommandValidator()
        {
            RuleFor(x => x.Position)
                .NotEmpty();
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.ChangePosition
{
    public class ChangeEmployeePositionCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Position { get; set; }
    }
}

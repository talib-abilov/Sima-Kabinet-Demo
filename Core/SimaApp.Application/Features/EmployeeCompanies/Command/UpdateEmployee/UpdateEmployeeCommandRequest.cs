using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest :IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string PIN { get; set; }
    }
}

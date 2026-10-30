using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Command.CreateSignInAuthority
{
    public class CreateSignInAuthorityCommandRequest:IRequest<Unit>
    {
        public int EmployeesCompaniesId { get; set; }
    }
}

using MediatR;
using SimaApp.Application.Features.Roles.Queries.GetRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetEmployee
{
    public class GetEmployeeQueryRequest: IRequest<GetEmployeeQueryResponse>
    {
        public string Pin {  get; set; }
    }
}

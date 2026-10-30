using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetAllEmployeesByCompanyId
{
    public class GetAllEmployeesByCompanyIdQueryRequest:IRequest<IList<GetAllEmployeesByCompanyIdQueryResponse>>
    {
        public int CompanyId { get; set; }
    }
}

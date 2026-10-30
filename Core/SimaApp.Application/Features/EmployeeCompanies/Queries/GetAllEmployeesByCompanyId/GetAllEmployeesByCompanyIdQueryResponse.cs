using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetAllEmployeesByCompanyId
{
    public class GetAllEmployeesByCompanyIdQueryResponse
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string PIN { get; set; }
        public string Position { get; set; }

    }
}

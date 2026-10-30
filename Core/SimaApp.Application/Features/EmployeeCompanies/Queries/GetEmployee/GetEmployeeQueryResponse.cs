using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.EmployeeCompanies.Queries.GetEmployee
{
    public class GetEmployeeQueryResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string PIN { get; set; }
    }
}

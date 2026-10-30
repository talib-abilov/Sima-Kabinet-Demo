using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class SignInAuthority:EntityBase
    {
        public int EmployeesCompaniesId { get; set; }
        public EmployeesCompanies EmployeesCompanies { get; set; } = null!;
    }
}

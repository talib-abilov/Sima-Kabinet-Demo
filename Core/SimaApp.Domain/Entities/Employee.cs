using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class Employee:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        //public string PatronymicName { get; set; }  
        public EmployeeDocument? EmployeeDocument { get; set; }
        public User? User { get; set; }
        public ICollection<EmployeesCompanies>EmployeesCompanies { get; set; } = new List<EmployeesCompanies>();

    }
}

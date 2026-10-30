using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class Company:EntityBase
    {
        public string Name { get; set; }
        public string TIN { get; set; }
        public ICollection<EmployeesCompanies> EmployeesCompanies { get; set; } = new List<EmployeesCompanies>();
        public ICollection<UserProfile>UserProfiles{ get; set; }=new List<UserProfile>();
    }
    
}

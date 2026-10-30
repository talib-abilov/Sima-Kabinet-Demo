using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class User:EntityBase
    {
        public string Email { get; set; }
        public int EmployeeId   { get; set; }
        public Employee Employee { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }=new List<UserProfile>();
    }
}

using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class EmployeeDocument:EntityBase
    {
        public string PIN { get; set; }
        //public string Serial { get; set; }
        //public int SerialNumber { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}

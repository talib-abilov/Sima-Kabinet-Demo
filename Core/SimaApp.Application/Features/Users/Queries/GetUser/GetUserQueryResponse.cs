using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryResponse
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }

    }
}

using SimaApp.Application.Features.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
    }
}

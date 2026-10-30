using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.CreateUser
{
    public class CreateUserCommandRequest:IRequest<Unit>
    { 
        public string Email { get; set; }
        public int EmployeeId { get; set; }
    }
}

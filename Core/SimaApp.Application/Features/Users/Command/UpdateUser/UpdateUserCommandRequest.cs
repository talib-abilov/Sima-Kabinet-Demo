using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}

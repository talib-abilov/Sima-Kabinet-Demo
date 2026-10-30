using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.DeleteUSer
{
    public class DeleteUserCommandRequest:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

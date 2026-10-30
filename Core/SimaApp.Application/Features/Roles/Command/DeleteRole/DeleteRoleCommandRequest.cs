using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.DeleteRole
{
    public class DeleteRoleCommandRequest:IRequest<Unit>
    {
        public int Id  { get; set; }
    }
}

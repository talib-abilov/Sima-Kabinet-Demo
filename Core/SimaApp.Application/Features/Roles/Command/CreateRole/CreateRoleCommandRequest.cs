using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Command.CreateRole
{
    public class CreateRoleCommandRequest:IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description {  get; set; }
    }
}

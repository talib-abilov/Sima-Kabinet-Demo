using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.AssignRole
{
    public class AssignRoleCommandRequest:IRequest<Unit>
    {
        public int UserProfileId    { get; set; }
        public int RoleId { get; set; } 
    }
}

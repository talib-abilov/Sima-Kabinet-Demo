using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Command.CreateUserProfile
{
    public class CreateUserProfileCommandRequest:IRequest<Unit>
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; } 
    }
}

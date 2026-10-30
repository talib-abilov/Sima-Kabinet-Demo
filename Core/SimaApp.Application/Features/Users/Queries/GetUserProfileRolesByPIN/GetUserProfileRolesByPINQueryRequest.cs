using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfileRolesByPIN
{
    public class GetUserProfileRolesByPINQueryRequest:IRequest<IList<GetUserProfileRolesByPINQueryResponse>>
    {
        public string PIN { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Queries.GetRole
{
    public class GetRoleQueryRequest:IRequest<GetRoleQueryResponse>
    {
        public int Id { get; set; }
    }
}

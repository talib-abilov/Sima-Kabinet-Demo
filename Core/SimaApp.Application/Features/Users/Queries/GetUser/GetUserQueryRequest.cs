using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryRequest:IRequest<GetUserQueryResponse>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetAllUser
{
    public class GetAllUserQueryRequest:IRequest<IList<GetAllUserQueryResponse>>
    {
    }
}

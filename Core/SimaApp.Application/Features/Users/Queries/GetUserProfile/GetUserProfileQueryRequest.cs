using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryRequest:IRequest<GetUserProfileQueryResponse>
    {
        public string PIN { get; set; }
        public string TIN { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
    }
}

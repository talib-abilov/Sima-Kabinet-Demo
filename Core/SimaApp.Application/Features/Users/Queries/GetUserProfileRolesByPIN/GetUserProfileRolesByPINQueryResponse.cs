using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Users.Queries.GetUserProfileRolesByPIN
{
    public class GetUserProfileRolesByPINQueryResponse
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int RoleId { get; set; }
    }
}

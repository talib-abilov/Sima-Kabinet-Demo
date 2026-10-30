using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class UserProfilesRoles:EntityBase
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int UserProfileId {  get; set; }
        public UserProfile UserProfile { get; set; }
    }
}

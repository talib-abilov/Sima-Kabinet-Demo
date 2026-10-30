using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class UserProfile:EntityBase
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<UserProfilesRoles> UserProfilesRoles { get; set; } = new List<UserProfilesRoles>();
    }
}

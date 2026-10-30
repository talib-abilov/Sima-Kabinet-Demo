using SimaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Domain.Entities
{
    public class Role:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserProfilesRoles> UserProfilesRoles { get; set; }=new List<UserProfilesRoles>();
    }
}

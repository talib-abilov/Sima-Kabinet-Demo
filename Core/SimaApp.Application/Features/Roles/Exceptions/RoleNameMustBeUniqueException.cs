using SimaApp.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Exceptions
{
    public class RoleNameMustBeUniqueException:BaseExceptions
    {
        public RoleNameMustBeUniqueException():base("Role with this name already exists")
        {
            
        }
    }
}

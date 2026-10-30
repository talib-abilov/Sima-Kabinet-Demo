using SimaApp.Application.Bases;
using SimaApp.Application.Features.Companies.Exceptions;
using SimaApp.Application.Features.Roles.Exceptions;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Features.Roles.Rules
{
    public class RoleRules:BaseRules
    {
        public Task RoleNameMustBeUnique(IList<Role> roles, string roleName)
        {
            if (roles.Any(x => x.Name.ToLower() == roleName.ToLower()))
                throw new RoleNameMustBeUniqueException();
            return Task.CompletedTask;
        }
    }
}

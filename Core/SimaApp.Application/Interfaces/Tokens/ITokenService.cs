using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        //Task<JwtSecurityToken> CreateToken(UserProfilesRoles userProfileRole, IList<string> roles);
        //Task<JwtSecurityToken> CreateToken(User user);
        Task<JwtSecurityToken> CreateToken(UserProfile profile);

        string GenerateRefreshToken();
        //ClaimsPrincipal? GetPrincipalFromExpiredToken();
    }
}

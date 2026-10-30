using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimaApp.Application.Interfaces.Tokens;
using SimaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimaApp.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> options)
        {
            _tokenSettings = options.Value;
        }
        public async Task<JwtSecurityToken> CreateToken(UserProfile userProfile)
        {
            
            
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,userProfile.Id.ToString()),
                new Claim("UserId",userProfile.UserId.ToString()),
                new Claim("CompanyId",userProfile.CompanyId.ToString()),
                //new Claim("UserProfilesRoles",userProfile.UserProfilesRoles.ToList().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        //public async Task<JwtSecurityToken> CreateToken(UserProfilesRoles userProfileRole, IList<string> roles)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //        new Claim(ClaimTypes.NameIdentifier,userProfileRole.Id.ToString()),
        //        new Claim("UserProfileId",userProfileRole.UserProfileId.ToString()),
        //        new Claim("RoleId",userProfileRole.RoleId.ToString())
        //    };

        //    foreach(var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role,role));
        //    }

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

        //    var token = new JwtSecurityToken(
        //        issuer: _tokenSettings.Issuer,
        //        audience: _tokenSettings.Audience,
        //        expires: DateTime.Now.AddMinutes(_tokenSettings.TokenValidityInMinutes),
        //        claims: claims,
        //        signingCredentials :new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
        //        );

        //    return token;
        //}

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

    }
}

using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EarlyBird.BusinessLogic.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthorizationSettings authorizationSettings;

        public TokenService(IOptions<AuthorizationSettings> authorizationSettings)
        {
            this.authorizationSettings = authorizationSettings.Value;
        }
        public string GenerateAccessToken(UserDto user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authorizationSettings.Secret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("userName", user.Username),
                new Claim("firstName", user.Firstname),
                new Claim("lastName", user.Lastname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(GetClaimsAssociatedWithRole(user.Role));

            var tokenOptions = new JwtSecurityToken(
                issuer: authorizationSettings.Issuer,
                audience: authorizationSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(authorizationSettings.TokenLifetimeInMinutes),
                signingCredentials: signinCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public Guid GetUserIdFromClaims(ClaimsIdentity identity)
        {
            IEnumerable<Claim> claims = identity.Claims;
            var idClaim = claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            return Guid.Parse(idClaim.Value);
        }

        public Roles GetRoleFromClaims(ClaimsIdentity identity)
        {
            IEnumerable<Claim> claims = identity.Claims;
            
            if (claims.FirstOrDefault(x => x.Type == Claims.Admin) != null)
                return Roles.Admin;
            if (claims.FirstOrDefault(x => x.Type == Claims.Worker) != null)
                return Roles.Worker;
            if (claims.FirstOrDefault(x => x.Type == Claims.Publisher) != null)
                return Roles.Publisher;
            return Roles.All;

        }



        #region private methods

        private IEnumerable<Claim> GetClaimsAssociatedWithRole(Roles? role)
        {
            switch (role)
            {
                case Roles.Admin:
                    return new List<Claim>
                    {
                        new Claim(Claims.Admin, "true"),
                        new Claim(Claims.Worker, "true"),
                        new Claim(Claims.Publisher, "true"),
                        new Claim(Claims.All, "true")
                    };

                case Roles.Worker:
                    return new List<Claim>
                    {
                        new Claim(Claims.Worker, "true"),
                        new Claim(Claims.All, "true")
                    };

                case Roles.Publisher:
                    return new List<Claim>
                    {
                        new Claim(Claims.Publisher, "true"),
                        new Claim(Claims.All, "true")
                    };
                default:
                    return new List<Claim>
                    {
                        new Claim(Claims.All, "true")
                    };

            }
        }

        #endregion
    }
}

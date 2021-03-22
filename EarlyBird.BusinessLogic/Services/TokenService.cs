using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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



        #region private methods

        private IEnumerable<Claim> GetClaimsAssociatedWithRole(string role)
        {
            switch (role)
            {
                case Constants.Roles.Admin:
                    return new List<Claim>
                    {
                        new Claim(Constants.Claims.Admin, "true"),
                        new Claim(Constants.Claims.Worker, "true"),
                        new Claim(Constants.Claims.Publisher, "true"),
                        new Claim(Constants.Claims.All, "true")
                    };

                case Constants.Roles.Worker:
                    return new List<Claim>
                    {
                        new Claim(Constants.Claims.Worker, "true"),
                        new Claim(Constants.Claims.All, "true")
                    };

                case Constants.Roles.Publisher:
                    return new List<Claim>
                    {
                        new Claim(Constants.Claims.Publisher, "true"),
                        new Claim(Constants.Claims.All, "true")
                    };
                default:
                    return new List<Claim>
                    {
                        new Claim(Constants.Claims.All, "true")
                    };

            }
        }

        #endregion
    }
}

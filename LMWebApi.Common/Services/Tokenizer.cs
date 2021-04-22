using LMWebApi.Common.Helpers;
using LMWebApi.Common.Iterfaces;
using LMWebApi.Common.Models.Database;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace LMWebApi.Common.Services
{
    public class Tokenizer : ITokenizer
    {
        private JwtHeader _header;

        public Tokenizer()
        {
            InitHeader();
        }

        public string CreateRegistrationToken(string email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var expires = DateTime.Now.AddMinutes(30);
            var payload = new JwtPayload(AppSettings.ValidIssuer, AppSettings.ValidAudience, authClaims, DateTime.Now, expires);

            var secToken = new JwtSecurityToken(_header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public IEnumerable<KeyValuePair<string, string>> DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            var claimsIdentity = (ClaimsPrincipal)principal;
            foreach (var claim in claimsIdentity.Claims)
                yield return new KeyValuePair<string, string>(claim.Type, claim.Value);

        }

        public string GenerateUserJwtToken(User user, bool isRefreshToken = false)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var expires = isRefreshToken ? DateTime.Now.AddYears(1) : DateTime.Now.AddHours(1);
            var payload = new JwtPayload(AppSettings.ValidIssuer, AppSettings.ValidAudience, authClaims, DateTime.Now, expires);

            var secToken = new JwtSecurityToken(_header, payload);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(secToken);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                if (principal != null)
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = AppSettings.ValidIssuer,
                ValidAudience = AppSettings.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Secret))
            };
        }

        private void InitHeader()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            _header = new JwtHeader(credentials);
        }
    }
}
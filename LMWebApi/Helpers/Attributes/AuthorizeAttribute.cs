using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Services;
using LMWebApi.Helpers.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace LMWebApi.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IUserDatabaseService _dbService;
        private AuthorizationFilterContext _context;
        private string accessSecToken;

        public AuthorizeAttribute()
        {
            _dbService = new UserDatabaseService();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var handler = new JwtSecurityTokenHandler();
            _context = context;
            ;
            if (context.HttpContext.Request.Cookies.TryGetValue("access_token", out string accessToken)
                && ValidateToken(accessToken)) return;

            if (context.HttpContext.Request.Cookies.TryGetValue("refresh_token", out string token)
                && ValidateToken(token))
            {
                var username = (handler.ReadToken(token) as JwtSecurityToken).Claims.FirstOrDefault(claim => claim.Type.Contains("name")).Value;
                var user = _dbService.FindByUsernameAsync(username).GetAwaiter().GetResult();
                if (user != null && user.RefreshTokens.Any(rt => rt == token))
                {
                    accessSecToken = user.GenerateJwtToken();
                    SetAccessToken(accessSecToken, context);
                    return;
                }
            }

            context.Result = new UnauthorizedResult();
        }

        private bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                _context.HttpContext.User = (ClaimsPrincipal)principal;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private TokenValidationParameters GetValidationParameters()
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

        private void SetAccessToken(string accessToken, AuthorizationFilterContext context)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
            };
            context.HttpContext.Response.Cookies.Append("access_token", accessToken, cookieOptions);
        }
    }
}
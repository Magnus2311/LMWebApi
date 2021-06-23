using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using LMWebApi.Common.Iterfaces;
using LMWebApi.Common.Models.Global;
using LMWebApi.Common.Services;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Services;
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
        private readonly ITokenizer _tokenizer;
        private AuthorizationFilterContext _context;
        private string accessSecToken;

        public AuthorizeAttribute()
        {
            _dbService = new UserDatabaseService();
            _tokenizer = new Tokenizer();
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
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
                var user = await _dbService.FindByUsernameAsync(username);
                if (user != null && user.RefreshTokens.Any(rt => rt == token))
                {
                    accessSecToken = _tokenizer.GenerateUserJwtToken(user);
                    SetAccessToken(accessSecToken, context);
                    GlobalHelpers.CurrentUser = user;
                    return;
                }
            }

            context.Result = new UnauthorizedResult();
        }

        private bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = _tokenizer.GetValidationParameters();

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
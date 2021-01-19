using System;
using System.Linq;
using System.Threading.Tasks;
using LMWebApi.Database.Interfaces;
using LMWebApi.Database.Models;
using LMWebApi.Helpers.Attributes;
using LMWebApi.Helpers.Extensions;
using LMWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutbotReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserDatabaseService _dbService;

        public UsersController(IUserDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("add")]
        public async Task Add(User user)
            => await _dbService.Add(user);

        [HttpDelete("delete")]
        public async Task Delete(string username)
            => await _dbService.Delete(username);

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var isSuccessful = await _dbService.Login(user);
            if (isSuccessful)
            {
                var token = user.GenerateJwtToken();
                var refreshToken = user.GenerateJwtToken(true);
                user.RefreshTokens.Add(refreshToken);
                await _dbService.UpdateRefreshToken(user);
                // SetAccessTokenInCookie(token);
                SetRefreshTokenInCookie(refreshToken);

                return Ok(new AuthenticateResponse(user, token.ToString()));
            }
            return Unauthorized();
        }

        [HttpGet("getUsername")]
        [Authorize]
        public async Task<IActionResult> GetUserName() => Ok(await _dbService.FindByUsernameAsync(HttpContext.User.Identity.Name));

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var user = await _dbService.FindByUsernameAsync(HttpContext.User.Identity.Name);
            var refreshToken = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "refresh_token").Value;
            user.RefreshTokens.Remove(refreshToken);
            await _dbService.UpdateRefreshToken(user);
            HttpContext.Response.Cookies.Delete("access_token");
            HttpContext.Response.Cookies.Delete("refresh_token");
            return Ok();
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddYears(1),
            };
            Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);
        }

        private void SetAccessTokenInCookie(string accessToken)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
            };
            Response.Cookies.Append("refresh_token", accessToken, cookieOptions);
        }
    }
}

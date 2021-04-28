using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LMWebApi.Common.Iterfaces;
using LMWebApi.Common.Models.Database;
using LMWebApi.Database.Interfaces;
using LMWebApi.Emails.Interfaces;
using LMWebApi.Helpers.Attributes;
using LMWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FutbotReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserDatabaseService _dbService;
        private readonly IEmailsService _emailsService;
        private readonly ITokenizer _tokenizer;

        public UsersController(IUserDatabaseService dbService,
            IEmailsService emailsService,
            ITokenizer tokenizer)
        {
            _dbService = dbService;
            _emailsService = emailsService;
            _tokenizer = tokenizer;
        }

        [HttpPost("add")]
        public async Task Add(User user)
        {
            var host = Request.Host.ToString();
            var token = _tokenizer.CreateRegistrationToken(user.Username);
            await _emailsService.SendRegistrationEmail(Request.Host.ToString(), user.Username, token, user.Template);
            await _dbService.Add(user);
        }

        [HttpDelete("delete")]
        public async Task Delete(string username)
            => await _dbService.Delete(username);

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var isSuccessful = await _dbService.Login(user);
            if (isSuccessful)
            {
                var token = _tokenizer.GenerateUserJwtToken(user);
                var refreshToken = _tokenizer.GenerateUserJwtToken(user, true);
                user.RefreshTokens.Add(refreshToken);
                await _dbService.UpdateRefreshToken(user);
                SetAccessTokenInCookie(token);
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

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (!_tokenizer.ValidateToken(token)) return BadRequest();

            var claims = _tokenizer.DecodeToken(token).ToDictionary(x => x.Key, x => x.Value);
            var tempEmail = claims[ClaimTypes.Email];

            if (email.ToUpper() == tempEmail.ToUpper())
                await _dbService.ConfirmEmailAsync(email);
            else
                return BadRequest();

            return Ok();
        }

        [HttpPost("sendSecondaryConfirmationEmail")]
        public async Task SecondaryConfirmationEmail(string email)
        {
            var host = Request.Host.ToString();
            var token = _tokenizer.CreateRegistrationToken(email);
            await _emailsService.ReSendRegistrationEmail(Request.Host.ToString(), email, token);
        }

        [HttpPost("changePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePassParams passes)
        {
            var user = await _dbService.FindByUsernameAsync(HttpContext.User.Identity.Name);
            user.Password = passes.OldPassword;
            if (await _dbService.Login(user))
                if (await _dbService.TryChangePasswordAsync(user, passes.NewPassword))
                    return Ok();

            return BadRequest();
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

        public class ChangePassParams
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }
    }
}

using System.Collections.Generic;
using LMWebApi.Common.Models.Database;
using Microsoft.IdentityModel.Tokens;

namespace LMWebApi.Common.Iterfaces
{
    public interface ITokenizer
    {
        string CreateRegistrationToken(string email);
        IEnumerable<KeyValuePair<string, string>> DecodeToken(string token);
        string GenerateUserJwtToken(User user, bool isRefreshToken = false);
        TokenValidationParameters GetValidationParameters();
        bool ValidateToken(string token);
    }
}
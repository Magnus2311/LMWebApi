using System.Text.Json.Serialization;
using LMWebApi.Common.Models.Database;

namespace LMWebApi.Models
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public bool IsConfirmed { get; set; }
        public string Username { get; set; }
        [JsonPropertyName("access_token")]
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            IsConfirmed = user.IsConfirmed;
            Token = token;
        }
    }
}

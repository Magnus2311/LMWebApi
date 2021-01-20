using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LMWebApi.Database.Models
{
    public class User
    {
        private List<string> refreshTokens = new List<string>();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefreshTokensStr
        {
            get { return JsonConvert.SerializeObject(refreshTokens); }
            set { refreshTokens = JsonConvert.DeserializeObject<List<string>>(value); }
        }
        [NotMappedAttribute]
        public List<string> RefreshTokens
        {
            get
            {
                return refreshTokens;
            }
            set
            {
                refreshTokens = value;
            }
        }
    }
}
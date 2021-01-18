using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LMWebApi.Database.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public string RefreshTokensStr
        {
            get
            {
                return JsonConvert.SerializeObject(RefreshTokens);
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    RefreshTokens = new List<string>();
                else
                    RefreshTokens = JsonConvert.DeserializeObject<List<string>>(value);
            }
        }
        [NotMappedAttribute]
        public List<string> RefreshTokens { get; set; } = new List<string>();
    }
}
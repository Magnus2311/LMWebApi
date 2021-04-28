using System;

namespace LMWebApi.Common.Models.Database
{
    public class Login
    {
        public Login(User user)
        {
            Date = DateTime.Now;
        }

        public Login(User user, bool isSuccessful)
            : this(user)
        {
            IsSuccessful = isSuccessful;
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
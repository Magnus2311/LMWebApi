using System;

namespace LMWebApi.Common.Helpers
{
    public static class AppSettings
    {
        public static string Secret { get; } = "AMGOYbZNFa5ru6IkghTu5QW8Qxp9UePRjCRe5mbq"; //Environment.GetEnvironmentVariable("JwtSecret", EnvironmentVariableTarget.Machine);
        public const string ValidIssuer = "https://localhost:5001/";
        public const string ValidAudience = "https://localhost:5001/";
    }
}

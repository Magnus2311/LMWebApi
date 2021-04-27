using System.Threading.Tasks;

namespace LMWebApi.Emails.Interfaces
{
    public interface IEmailsService
    {
        Task SendRegistrationEmail(string url, string email, string token, string template);
        Task ReSendRegistrationEmail(string url, string email, string token);
        Task SendResetPasswordEmail(string url, string email, string token, string template);
    }
}
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using LMWebApi.Emails.Interfaces;

namespace LMWebApi.Emails.Services
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private const string FROM_EMAIL = "lifemode2311@gmail.com";
        private readonly string password = Environment.GetEnvironmentVariable("GmailPass", EnvironmentVariableTarget.Machine);
        private readonly SmtpClient _smtpClient;

        public GmailSmtpEmailsService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FROM_EMAIL, password),
                EnableSsl = true,
            };
        }

        public async Task ReSendRegistrationEmail(string url, string email)
        {
            var message = new MailMessage(FROM_EMAIL, email, "New confirmation email from Life Mode", $"{url}/user/confirmEmail");
            message.IsBodyHtml = true;
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendRegistrationEmail(string url, string email)
        {
            var message = new MailMessage(FROM_EMAIL, email, "Welcome to Life Mode", $"{url}/user/confirmEmail");
            message.IsBodyHtml = true;
            await _smtpClient.SendMailAsync(message);
        }
    }
}
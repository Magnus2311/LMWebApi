using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using LMWebApi.Emails.Interfaces;

namespace LMWebApi.Emails.Services
{
    public class GmailSmtpEmailsService : IEmailsService
    {
        private const string FROM_EMAIL = "lifemode2311@gmail.com";
        private readonly string password = "A23112019a@"; //Environment.GetEnvironmentVariable("GmailPass", EnvironmentVariableTarget.Machine);
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

        public async Task ReSendRegistrationEmail(string url, string email, string token)
        {
            var message = new MailMessage(FROM_EMAIL, email, "New confirmation email from Life Mode", $"{url}/auth/confirmEmail/{email}&{token}");
            message.IsBodyHtml = true;
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendRegistrationEmail(string url, string email, string token, string template)
        {
            var message = new MailMessage(FROM_EMAIL, email)
            {
                Subject = "Welcome to Life Mode"
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(GetEmbeddedImage("./Images/logo_transparent.png", template, token));

            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendResetPasswordEmail(string url, string email, string token, string template)
        {
            var message = new MailMessage(FROM_EMAIL, email)
            {
                Subject = "Reset password for Life Mode"
            };
            message.IsBodyHtml = true;
            message.AlternateViews.Add(GetEmbeddedImage("./Images/logo_transparent.png", template, token));

            await _smtpClient.SendMailAsync(message);
        }

        private AlternateView GetEmbeddedImage(String filePath, string template, string token)
        {
            LinkedResource res = new LinkedResource(filePath);
            res.ContentType = new ContentType()
            {
                MediaType = "image/png",
                Name = "logo_transparent.png"
            };
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = string.Format(template, res.ContentId, token);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
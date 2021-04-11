using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
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

        public async Task ReSendRegistrationEmail(string url, string email, string token)
        {
            var message = new MailMessage(FROM_EMAIL, email, "New confirmation email from Life Mode", $"{url}/auth/confirmEmail/{email}&{token}");
            message.IsBodyHtml = true;
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendRegistrationEmail(string url, string email, string token)
        {
            var templateData = await GetTemplate(url, "confirmationEmail", new string[] { email, token });
            var message = new MailMessage(FROM_EMAIL, email, "Welcome to Life Mode", templateData);
            message.IsBodyHtml = true;
            await _smtpClient.SendMailAsync(message);
        }

        private async Task<string> GetTemplate(string url, string templateName, string[] parameters)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            string downloadUrl = $"https://{url}/templates/{templateName}/{WebUtility.UrlEncode(parameters[0])}/{WebUtility.UrlEncode(parameters[1])}/";
            var client = new HttpClient(clientHandler);
            using var response = await client.GetAsync(downloadUrl);
            using var content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }
    }
}
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
            clientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.Brotli;
            string downloadUrl = $"https://{url}/templates/{templateName}/{WebUtility.UrlEncode(parameters[0])}/{WebUtility.UrlEncode(parameters[1])}/";
            var client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept-Charset", "ISO-8859-1");
            client.DefaultRequestHeaders.Add("sec-ch-ua", @"Google Chrome"";v=""89"", ""Chromium"";v=""89"", "";Not A Brand"";v=""99""");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "document");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "navigate");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "none");
            client.DefaultRequestHeaders.Add("sec-fetch-user", "?1");
            client.DefaultRequestHeaders.Add("upgrade-insecure-requests", "1");
            using var response = await client.GetAsync(downloadUrl);
            using var content = response.Content;
            string result = await content.ReadAsStringAsync();
            return result;
        }
    }
}
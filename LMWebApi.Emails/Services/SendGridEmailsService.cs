using System;
using System.Threading.Tasks;
using LMWebApi.Emails.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LMWebApi.Emails.Services
{
    // Трябва да се създаде domain и да може да се потвърди в SendGrid, за да работи
    public class SendGridEmailsService : IEmailsService
    {
        public Task ReSendRegistrationEmail(string url, string email, string token)
        {
            throw new NotImplementedException();
        }

        public async Task SendRegistrationEmail(string email)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridGmailKey", EnvironmentVariableTarget.Machine);
            var client = new SendGridClient(apiKey);
            var subject = "Welcome to Life Mode";
            var from = new EmailAddress("lifemode2311@gmail.com", "Life Mode");
            var to = new EmailAddress(email);
            var plainTextContent = "Confirm your email";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendRegistrationEmail(string url, string email, string token)
        {
            throw new NotImplementedException();
        }
    }
}
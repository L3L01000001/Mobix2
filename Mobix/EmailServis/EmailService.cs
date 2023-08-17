using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using FluentEmail;
using FluentEmail.Mailgun;
using Microsoft.AspNetCore.Mvc;

namespace Mobix.EmailServis
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            FluentEmail.Core.Email.DefaultSender = new MailgunSender(
                _configuration["Mailgun:ApiKey"],
                _configuration["Mailgun:Domain"]);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
                var email = FluentEmail.Core.Email
                    .From("mobix.shop5@mailgun.org")
                    .To(toEmail)
                    .Subject(subject)
                    .Body(content)
                    .Send();
        }
    }
}

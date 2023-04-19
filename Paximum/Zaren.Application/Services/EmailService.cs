using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Zaren.Application.Models;
using Zaren.Application.Services.Interfaces;
using Zaren.Shared.SettingsModels;
using System.Threading.Tasks;

namespace Zaren.Application.Services
{
    public class EmailService : IEmailService
    {
        public readonly EmailSettings _mailsettings;
        public EmailService(IOptions<EmailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var builder = new BodyBuilder
            {
                HtmlBody = mailRequest.Body
            };

            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailsettings.Mail),
                Subject = mailRequest.Subject,
                Body = builder.ToMessageBody()
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.From.Add(MailboxAddress.Parse(_mailsettings.Mail));
            using var smtp = new SmtpClient();
            smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailsettings.Mail, _mailsettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

    }
}

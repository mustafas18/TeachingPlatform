using Core.Dtos;
using Core.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task<EmailDto> SendEmailAsync(EmailDto mailRequest)
        {
            var emailSettings = new EmailSettingsDto();
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(mailRequest.From),
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host,emailSettings.SMTPPort, SecureSocketOptions.None);
            smtp.Authenticate(emailSettings.UserName, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return mailRequest;
        }
    }
}


using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly Context _context;

        public EmailService(IOptions<SmtpSettings> smtpOptions, Context context)
        {
            _context = context;
        }

        public async Task<SmtpSettings> GetSmtpSettings()
        {
            return await _context.SmtpSettings.FirstOrDefaultAsync();
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var smtpSettings = await GetSmtpSettings() ?? throw new Exception("SMTP não configurado");

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}

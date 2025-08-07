
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;

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

        public async Task SendEmailAsync(EmailDto emailDto)
        {
            var smtpSettings = await GetSmtpSettings() ?? throw new Exception("SMTP não configurado");

            var destinario = await _context.Empresas.Where(a => a.Id == emailDto.EmpresaId).Select(a => a.Email).FirstOrDefaultAsync();

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(smtpSettings.Username));
            email.To.Add(MailboxAddress.Parse(destinario));
            email.Subject = emailDto.Assunto;

            var builder = new BodyBuilder { HtmlBody = emailDto.Mensagem };
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}

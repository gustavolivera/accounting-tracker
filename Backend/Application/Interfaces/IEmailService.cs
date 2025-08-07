using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}

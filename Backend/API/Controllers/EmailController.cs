using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> EnviarEmail([FromBody] EmailDto emailDto)
        {
            await _emailService.SendEmailAsync(emailDto);
            return Ok("Enviado");
        }
    }
}

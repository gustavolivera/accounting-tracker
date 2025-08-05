using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> EnviarEmail()
        {
            await _emailService.SendEmailAsync("social.gustavosilva@gmail.com", "TESTE", "<h1>Boa noiite favor enviar o extrato de julho</h1>");
            return Ok("Enviado");
        }
    }
}

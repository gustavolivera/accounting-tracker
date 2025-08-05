using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SituacaoExtratosController : BaseController<SituacaoExtratos>
    {
        private readonly ISituacaoExtratosService _service;
        public SituacaoExtratosController(ISituacaoExtratosService service) : base(service) { _service = service; }

        [Route("{ano}/{mes}")]
        [HttpGet]
        public async Task<IActionResult> GetByMonth(int ano, int mes)
        {
            return Ok(await _service.GetByMonth(ano, mes));
        }
        
    }
}

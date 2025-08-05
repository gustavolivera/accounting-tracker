using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SituacaoExtratosService : BaseService<SituacaoExtratos>, ISituacaoExtratosService
    {
        private readonly Context _context;

        public SituacaoExtratosService(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SituacaoExtratos>> GetByMonth(int ano, int mes)
        {
            return await _context.SituacaoExtratos.Where(a => a.Ano == ano && a.Mes == mes).ToListAsync();
        }

    }
}

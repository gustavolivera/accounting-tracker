using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISituacaoExtratosService : IBaseService<SituacaoExtratos>
    {
        Task<List<SituacaoExtratos>> GetByMonth(int ano, int mes);
    }
}

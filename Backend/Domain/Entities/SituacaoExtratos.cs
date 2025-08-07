using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.Entities
{
    public class SituacaoExtratos
    {
        public Guid Id { get; set; }
        
        public Guid EmpresaId { get; set; }
        
        [JsonIgnore] 
        public Empresa Empresa { get; private set; }
       
        public int Ano { get; set; }
        
        public int Mes { get; set; }
       
        public eStatusContabil Status { get; set; }
    }
}
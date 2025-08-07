using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Empresa
    {
        public Guid Id { get; set; }
        
        public string Nome { get; set; }
       
        public string Cnpj { get; set; }

        public string Email { get; set; }
       
        [JsonIgnore]
        public ICollection<SituacaoExtratos>? SituacaoExtratos { get; set; }

    }
}
using Domain.Enums;

namespace Domain.Entities
{
    public class StatusMensal
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public eStatusContabil Status { get; set; }
    }
}
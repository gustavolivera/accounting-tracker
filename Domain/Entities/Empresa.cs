namespace Domain.Entities
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public ICollection<StatusMensal>? StatusMensais { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmailDto
    {
        public Guid EmpresaId { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}

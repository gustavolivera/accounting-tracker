using Application.Interfaces;
using Domain.Entities;

namespace API.Controllers
{
    public class EmpresaController : BaseController<Empresa>
    {
        public EmpresaController(IBaseService<Empresa> service) : base(service) { }
    }
}

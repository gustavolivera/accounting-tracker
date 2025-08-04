using API.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpresaController : BaseController<Empresa>
    {
        public EmpresaController(IBaseService<Empresa> service) : base(service) { }
    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace API.Controllers
{
    public class SmtpSettingsController : BaseController<SmtpSettings>
    {
        public SmtpSettingsController(IBaseService<SmtpSettings> service) : base(service) { }
    }
}

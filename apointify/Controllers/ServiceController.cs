using apointify.Models;
using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class ServiceController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult service()
        {
           var service = DBEntities.Services.ToList();
            return View(service);
        }
    }
}

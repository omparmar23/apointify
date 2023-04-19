using apointify.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider = Microsoft.Extensions.DependencyInjection.ServiceProvider;

namespace apointify.Controllers
{
    public class ServiceProviderController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult Index(int serviceId)
        {
            //var sp = DBEntities.ServiceProviders.Where(m => m.ServiceId == serviceId).ToList();
            var sp = DBEntities.ServiceProviders.ToList();
            return View(sp);
        }

        [HttpGet]
        public IActionResult CreateFirm(int Id)
        {
            return View(Id);
        }

        

    }
}

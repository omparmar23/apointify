using apointify.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider = apointify.Models.ServiceProvider;

namespace apointify.Controllers
{
    public class ServiceController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult service()
        {
           return View(DBEntities.Services.ToList());
        }
        
        public IActionResult Index(int Id)
        {
            FirmDetail service = DBEntities.FirmDetails.Where(m => m.ServiceId == Id).FirstOrDefault();
            return RedirectToAction("Index","ServiceProvider",new {service.ServiceId });
        }

    }
}

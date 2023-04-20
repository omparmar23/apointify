using apointify.Models;
using Microsoft.AspNetCore.Mvc;


namespace apointify.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IHttpContextAccessor _contx;
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult Index(int serviceId)
        {
            //var sp = DBEntities.ServiceProviders.Where(m => m.ServiceId == serviceId).ToList();
            var sp = DBEntities.ServiceProviders.ToList();
            return View(sp);
        }
        
        public IActionResult CreateFirm()
        {
            
            return View();
        }


        public IActionResult Create(FirmDetail firm) 
        {



            return RedirectToAction("Index","Login");
        }

        

    }
}

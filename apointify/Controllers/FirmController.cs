using apointify.Models;
using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class FirmController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult service()
        {   
            return View(DBEntities.Services.ToList());
        }

        public IActionResult Index(int Id)
        {
            FirmDetail service = DBEntities.FirmDetails.Where(m => m.ServiceId == Id).FirstOrDefault();
            return RedirectToAction("Index", "ServiceProvider", new { service.ServiceId });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class ApointmentController : Controller
    {
        public IActionResult Index(int Id)
        {
            
            return View();
        }
        public IActionResult bookings()
        {


            return View();
        }
    }
}

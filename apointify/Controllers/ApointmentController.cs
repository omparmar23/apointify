using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class ApointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

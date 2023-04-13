using apointify.ExtentionMethods;
using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace apointify.Controllers
{
    public class OrderController : Controller
    {
        OmParmarContext dbEntities = new OmParmarContext();
        public IActionResult Index()
        {
            var order = dbEntities.Orders.ToList();
            return View(order);
        }
        public IActionResult Details(int Id)
        {
            Order orderD = dbEntities.Orders.Where(m => m.OrderId == Id).FirstOrDefault();
            return View(orderD);
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return  RedirectToAction("Index");
        }
    }
}

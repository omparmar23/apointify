using Microsoft.AspNetCore.Mvc;
using apointify.Models;
using apointify.VirtualModels;

using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
//using ServiceProvider = apointify.Models.ServiceProvider;
//using Microsoft.Extensions.DependencyInjection;
//using ServiceProvider = Microsoft.Extensions.DependencyInjection.ServiceProvider;

namespace apointify.Controllers
{
    public class ServiceProviderController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult Index()
        {
            var DbContext = DBEntities.ServiceProviders.Where(m => m.IsDeleted == false).ToList();
            return View(DbContext);
        }
        public IActionResult Edit(int Id)
        {
            var DbContext = DBEntities.ServiceProviders.Where(m => m.FirmId == Id).FirstOrDefault();
            return View(DbContext);
        }
        public IActionResult Delete(int Id)
        {
            
            var DbContext = DBEntities.ServiceProviders.Where(m => m.FirmId == Id).FirstOrDefault();
            DbContext.IsDeleted = true;
            DBEntities.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult EditData(ServiceProviderVM serviceProviderVM)
        {
            var DbContext = DBEntities.ServiceProviders.Where(m => m.FirmId == serviceProviderVM.FirmId).FirstOrDefault();
            if(serviceProviderVM.FirmId == 0)
            {
                ServiceProviderVM serviceProvider = new ServiceProviderVM();
                serviceProviderVM.FirmId = new int();
                serviceProviderVM.FirmName = serviceProvider.FirmName;
                serviceProviderVM.FirmOwnerName = serviceProvider.FirmOwnerName;
                serviceProviderVM.Address = serviceProvider.Address;    
                serviceProviderVM.Email = serviceProvider.Email;
                serviceProviderVM.City = serviceProvider.City;
                serviceProviderVM.UpdatedDate = serviceProvider.UpdatedDate;
                serviceProviderVM.MobileNumber = serviceProvider.MobileNumber;
                serviceProviderVM.Password = serviceProvider.Password;
                serviceProviderVM.ServiceType = serviceProvider.ServiceType;
                serviceProviderVM.Service = serviceProvider.Service;
                serviceProviderVM.Username  = serviceProvider.Username;
                DBEntities.SaveChanges();
                
            }
            else
            {

                DbContext.FirmName = serviceProviderVM.FirmName;
                DbContext.FirmOwnerName = serviceProviderVM.FirmOwnerName;
                DbContext.Address = serviceProviderVM.Address;
                DbContext.Email = serviceProviderVM.Email;
                DbContext.City = serviceProviderVM.City;
                DbContext.UpdatedDate = serviceProviderVM.UpdatedDate;
                DbContext.MobileNumber = serviceProviderVM.MobileNumber;
                DbContext.Password = serviceProviderVM.Password;
                DbContext.ServiceType = serviceProviderVM.ServiceType;
                DbContext.Service = serviceProviderVM.Service;
                DbContext.Username = serviceProviderVM.Username;
                DBEntities.SaveChanges();
            }
            
                
                
                return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            var DbContext = DBEntities.ServiceProviders.Where(m => m.FirmId == Id).FirstOrDefault();
            return View(DbContext);
        }

    }
}

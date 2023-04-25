using apointify.ExtentionMethods;
using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using ServiceProvider = apointify.Models.ServiceProvider;

namespace apointify.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IHttpContextAccessor _contx;
        OmParmarContext DBEntities = new OmParmarContext();




      
        public IActionResult Index(int  serviceId)
        {
            List<FirmDetail> sp = DBEntities.FirmDetails.Where(m => m.ServiceId == serviceId).ToList();
            return View(sp);
        }
        
        public IActionResult CreateFirm()
        {
            
            return View();
        }
		



		[HttpPost]
        public IActionResult Create(FirmDetailVM firm) 
        {
                HttpContext.Session.Clear();
                OmParmarContext DBEntities = new OmParmarContext();
                if (firm.FirmId == 0)
                {
                    if(firm.Image == null)
                    {
                        string path = "/Image/FirmImage/Default.jpg";

                        FirmDetail newfirm = new FirmDetail();
                        newfirm.FirmId =new int();
                        newfirm.Userid = firm.Userid;
                        newfirm.ServiceId = firm.ServiceId  ;
                        newfirm.ServiceType = firm.ServiceType;
                        newfirm.FirmName = firm.FirmName;
                        newfirm.FirmImage = path;
                        newfirm.Email = firm.Email;
                        newfirm.MobileNumber = firm.MobileNumber;
                        newfirm.Address = firm.Address;
                        newfirm.City = firm.City;
                        newfirm.IsDeleted = firm.IsDeleted;
                        newfirm.CreatedDate = DateTime.Now;
                        newfirm.UpdatedDate = DateTime.Now;
                        firm.FirmId = new int();
                        DBEntities.FirmDetails.Add(newfirm);
                        DBEntities.SaveChanges();
                    }
                    else
                    {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/FirmImage");
                    var path2 = "/Image/FirmImage";
                        
                        //get file extension
                        FileInfo fileInfo = new FileInfo(firm.Image.FileName);
                        string fileName = firm.Image.FileName;

                        string fileNameWithPath = Path.Combine(path, fileName);
                        string fileNameWithPath2 = Path.Combine(path2, fileName);

                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            firm.Image.CopyTo(stream);
                        }
                        FirmDetail newfirm = new FirmDetail();
                        newfirm.FirmId = new int();
                        newfirm.Userid = firm.Userid;
                        newfirm.ServiceId = firm.ServiceId;
                        newfirm.ServiceType = firm.ServiceType;
                        newfirm.FirmName = firm.FirmName;
                        newfirm.FirmImage = fileNameWithPath2;
                        newfirm.Email = firm.Email;
                        newfirm.MobileNumber = firm.MobileNumber;
                        newfirm.Address = firm.Address;
                        newfirm.City = firm.City;
                        newfirm.IsDeleted = firm.IsDeleted;
                        newfirm.CreatedDate = DateTime.Now;
                        newfirm.UpdatedDate = DateTime.Now;
                        firm.FirmId = new int();
                        DBEntities.FirmDetails.Add(newfirm);
                        DBEntities.SaveChanges();
                    }
                    return RedirectToAction("Index", "Login");
                }
                else if (firm.FirmId != null)
                {
                    FirmDetail updatefirm = DBEntities.FirmDetails.Where(m => m.FirmId == firm.FirmId).FirstOrDefault();
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/FirmImage/");
                    //create folder if not exist
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    //get file extension
                    FileInfo fileInfo = new FileInfo(firm.Image.FileName);
                    string fileName = firm.Image.FileName;
                    string fileNameWithPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        firm.Image.CopyTo(stream);
                    }
                    updatefirm.FirmImage = fileNameWithPath;
                    updatefirm.FirmName = firm.FirmName;
                    updatefirm.MobileNumber = firm.FirmName;
                    updatefirm.Address = firm.Address;
                    updatefirm.Email = firm.Email;
                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("Index", "Login");
        
            
        }

    }
}

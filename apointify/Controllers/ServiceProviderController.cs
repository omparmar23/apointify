using apointify.ExtentionMethods;
using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Helpers;


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



        


        public IActionResult Create(FirmDetailVM firm) 
        {
            try
            {
                HttpContext.Session.Clear();
                OmParmarContext DBEntities = new OmParmarContext();
                if (firm.FirmId == null)
                {
                    if(firm.Image == null)
                    {
                        string path = "/Image/FirmImage/Default.jpg";
                        FirmDetail newfirm = new FirmDetail();
                        newfirm.FirmId =new int();
                        newfirm.Userid = firm.Userid;
                        newfirm.ServiceName = firm.ServiceName;
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
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "/Image/FirmImage/");
                        
                        //get file extension
                        FileInfo fileInfo = new FileInfo(firm.Image.FileName);
                        string fileName = firm.Image.FileName;

                        string fileNameWithPath = Path.Combine(path, fileName);

                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            firm.Image.CopyTo(stream);
                        }
                        FirmDetail newfirm = firm.ToContext();
                        newfirm.FirmId = new int();
                        newfirm.Userid = firm.Userid;
                        newfirm.ServiceName = firm.ServiceName;
                        newfirm.ServiceType = firm.ServiceType;
                        newfirm.FirmName = firm.FirmName;
                        newfirm.FirmImage = fileNameWithPath;
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
            catch(Exception ex)
            {
                throw;
            }
            

        }



    }
}

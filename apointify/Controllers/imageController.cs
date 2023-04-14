using Microsoft.AspNetCore.Mvc;
using System.IO;
using apointify.Models;
namespace apointify.Controllers
{
    public class imageController : Controller
    {
        public object FileUpload1 { get; private set; }

        public IActionResult Index()
        {

            return View();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            //string filenam = FileUpload1.FileName.ToString();
            string path = @"D:\test\";
            //path = path + filenam;
            //FileUpload1.PostedFile.SaveAs(path);.
        }

    }
}

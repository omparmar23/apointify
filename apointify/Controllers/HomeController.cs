using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Optivem.Framework.Core.Common.WebAutomation;
using RestSharp;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using Method = RestSharp.Method;

namespace apointify.Controllers
{

    public static class Constants
    {
        [Flags]
        public enum Role
        {
            User = 1,
            SuperUser = 2,
            Admin = 4,
            SuperAdmin = 8
        }
    }
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        OmParmarContext _dbcontext = new OmParmarContext();

        HttpClient hc = new HttpClient();
        private static List<UsersTable> userdetail = new List<UsersTable>();
        private static List<Employee> EmployeeDetailList = new List<Employee>();
        RestClient restClient;

        private string apiBaseUrl = "https://localhost:7248/api";


        private readonly IHttpContextAccessor _contx;


        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _contx = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Index()
        {

            //if (user.Email == null && user.Password == null)
            //{
            //_contx.HttpContext.Session.SetString("User","none");
            //_contx.HttpContext.Session.SetInt32("UserId",0);

            //}
            //else
            //{
            //    _contx.HttpContext.Session.SetString("User", user.Email);
            //    _contx.HttpContext.Session.SetString("UserId", user.Password);
            //}

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }


        public IActionResult apiCall(int Id)
        {
            if (Id > 0)
            {
                OmParmarContext DBEntities = new OmParmarContext();
                Employee dbObject = DBEntities.Employees.Where(m => m.Id == Id).FirstOrDefault();
                return View(dbObject);

            }
            else
            {
                RestClient client = new RestClient(apiBaseUrl);
                var restRequest = new RestRequest("/AddEmployeeData", Method.Post);
                restRequest.AddHeader("Accept", "application/json");
                restRequest.RequestFormat = DataFormat.Json;
                RestResponse response = client.Execute(restRequest);
                var content = response.Content;
                if (content != null)
                {
                    var user = JsonConvert.DeserializeObject<ServiceResponse<List<Employee>>>(content);
                    EmployeeDetailList = user.data;

                }
                return View(EmployeeDetailList);
            }


        }
        public IActionResult EmployeeTable()
        {
            RestClient client = new RestClient(apiBaseUrl);
            var restRequest = new RestRequest("/EmployeeData", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            RestResponse response = client.Execute(restRequest);
            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<Employee>>>(content);
                EmployeeDetailList = user.data;

            }
            return View(EmployeeDetailList);
        }



        

        public IActionResult GetData(int Id)
        {
            OmParmarContext DBEntities = new OmParmarContext();
            ServiceResponse<List<Employee>> serviceReponse = new ServiceResponse<List<Employee>>();
            Employee dbObject = DBEntities.Employees.Where(m => m.Id == Id).FirstOrDefault();
            return View(dbObject);
        }


      







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult UpdateEmployee(EmployeeVM employee)
        {
            OmParmarContext DBEntities = new OmParmarContext();
            Employee dbObject = DBEntities.Employees.Where(m => m.Id == employee.Id).FirstOrDefault();
            dbObject.Salary = employee.Salary;
            dbObject.Age = employee.Age;
            dbObject.Name = employee.Name;
            dbObject.Department = employee.Department;
            DBEntities.SaveChanges();

            return RedirectToAction("EmployeeTable");

        }



        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
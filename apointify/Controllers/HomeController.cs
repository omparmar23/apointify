using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        OmParmarContext _dbcontext = new OmParmarContext();

        HttpClient hc = new HttpClient();
        private static List<UsersTable> userdetail = new List<UsersTable>();
        private static List<Employee> EmployeeDetailList = new List<Employee>();
        RestClient restClient;

        private string apiBaseUrl = "https://localhost:7248/api";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult GetOneEmplyoee()
        {
            return View();
        }

        public IActionResult GetData(int Id)
        {
            OmParmarContext DBEntities = new OmParmarContext();
            ServiceResponse<List<Employee>> serviceReponse = new ServiceResponse<List<Employee>>();
            Employee dbObject = DBEntities.Employees.Where(m => m.Id == Id).FirstOrDefault();
            return View(dbObject);
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
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
    }
}
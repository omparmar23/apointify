using apointify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Data;
using System.Diagnostics;
using System.Net;
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


        public IActionResult apiCall()
        {
            return View();
        }

        public IActionResult UserTable()
        {
            RestClient client = new RestClient(apiBaseUrl);
            var restRequest = new RestRequest("/GetUserDetails", Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            if (content != null)
            {
                var user = JsonConvert.DeserializeObject<ServiceResponse<List<UsersTable>>>(content);
                userdetail = user.data;
                
            }
            return View(userdetail);
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

        [HttpPost]
        public IActionResult GetIdWiseEmployeeData(int Id)
        {
            RestClient client = new RestClient(apiBaseUrl);
            var restRequest = new RestRequest("/EmployeeData/" + Id, Method.Get);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(restRequest);

            var content = response.Content;
            
            return View(content);
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


     
    }
}
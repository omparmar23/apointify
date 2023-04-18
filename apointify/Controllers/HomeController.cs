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
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
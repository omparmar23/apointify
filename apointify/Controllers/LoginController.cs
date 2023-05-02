﻿using apointify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using apointify.ExtentionMethods;
using apointify.VirtualModels;
using System.Collections.Generic;


namespace apointify.Controllers
{
    public class LoginController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();

        private readonly IHttpContextAccessor _contx;
        public interface ILoginValidation
        {
            public List<User> ValidateUserLogin(User user);
        }

        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public LoginController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _contx = httpContextAccessor;
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("Default");
            //Constr = "Server=192.168.0.33; Password=UlTCgZe6Zl; Encrypt=False; Database= DreadCoders; User Id=dread.coders;";
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult SignUp()
        {

            return View();
        }






        [HttpPost]
        public IActionResult ValidateCustomerLogin(User users)
        {
            User user = new User();
            try
            {

                using (con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("Proc_Login_authentication", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", users.Email);
                    cmd.Parameters.AddWithValue("@Password", users.Password);
                    SqlParameter outputPara = new SqlParameter();
                    outputPara.ParameterName = "@Email";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //var  userse = rdr.Read().ResultView();

                    while (rdr.Read())
                    {

                        //user.UserId = Convert.ToInt32(rdr["userId"]);
                        user.Email = rdr["Email"].ToString();
                        user.Password = rdr["Password"].ToString();
                        user.Role = Convert.ToInt32(rdr["Role"]);
                        user.UserId = Convert.ToInt32(rdr["UserId"]);
                        user.MobileNumber = rdr["MobileNumber"].ToString();
                        user.Name = rdr["Name"].ToString();


                    }
                }
                //_contx.HttpContext.Session.;
                if (user.UserId == 0)
                {
                    ViewBag.message = "Please Enter Valid Email and Password.";
                    return View("Index");
                }
                else
                {
                    _contx.HttpContext.Session.SetString("Email", user.Email);
                    _contx.HttpContext.Session.SetString("Password", user.Password);
                    _contx.HttpContext.Session.SetString("Name", user.Name);
                    _contx.HttpContext.Session.SetString("Role", Convert.ToString(user.Role));
                    _contx.HttpContext.Session.SetString("UserId", Convert.ToString(user.UserId));
                    _contx.HttpContext.Session.SetString("mobile", user.MobileNumber);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult newa()
        {
            return RedirectToAction("Index", "Login");
        }



        public IActionResult createUser(UserVM user)
        {
            OmParmarContext DBEntities = new OmParmarContext();
            if (user.Role == 1)
            {
                User users = DBEntities.Users.Where(m => m.UserId == user.UserId).FirstOrDefault();
                if (user.UserId == 0)
                {

                    User obj = user.ToContext();
                    // to avoid conflict of autogenerated id
                    obj.UserId = new int();
                    DBEntities.Users.Add(obj);
                    DBEntities.SaveChanges();
                    var id = obj.UserId;
                    _contx.HttpContext.Session.SetString("UserId", Convert.ToString(obj.UserId));
                    return RedirectToAction("CreateFirm", "ServiceProvider");
                }
                else
                {
                    var dbObject = DBEntities.Users.Where(m => m.UserId == user.UserId).FirstOrDefault();
                    dbObject.Role = user.Role;
                    dbObject.Username = user.Username;
                    dbObject.Name = user.Name;
                    dbObject.Email = user.Email;
                    dbObject.Password = user.Password;
                    dbObject.MobileNumber = user.MobileNumber;
                    dbObject.City = user.City;
                    dbObject.UpdatedDate = DateTime.Now;
                    DBEntities.SaveChanges();
                    return RedirectToAction("UserProfile", new { Id = user.UserId });
                }

            }
            else
            {
                User users = DBEntities.Users.Where(m => m.UserId == user.UserId).FirstOrDefault();
                if (user.UserId == 0)
                {

                    User obj = user.ToContext();
                    // to avoid conflict of autogenerated id
                    obj.UserId = new int();
                    DBEntities.Users.Add(obj);
                    DBEntities.SaveChanges();
                    var id = obj.UserId;
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    var dbObject = DBEntities.Users.Where(m => m.UserId == user.UserId).FirstOrDefault();
                    dbObject.Role = user.Role;
                    dbObject.Username = user.Username;
                    dbObject.Name = user.Name;
                    dbObject.Email = user.Email;
                    dbObject.Password = user.Password;
                    dbObject.MobileNumber = user.MobileNumber;
                    dbObject.City = user.City;
                    dbObject.UpdatedDate = DateTime.Now;
                    DBEntities.SaveChanges();
                    return RedirectToAction("UserProfile", "Apointment");
                }

            }




        }

        public IActionResult UserProfile(int Id)
        {

            var dbObject = DBEntities.Users.Where(m => m.UserId == Id).FirstOrDefault();

            return View(dbObject);

        }

    }
}

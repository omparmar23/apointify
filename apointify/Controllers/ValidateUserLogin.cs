using apointify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace apointify.Controllers
{
    public class ValidateUserLogin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public ValidateUserLogin(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("Default");
            //Constr = "Server=192.168.0.33; Password=UlTCgZe6Zl; Encrypt=False; Database= DreadCoders; User Id=dread.coders;";
        }
        public IActionResult ValidateCustomerLogin(User users)
        {
            List<User> UserList = new List<User>();
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
                    while (rdr.Read())
                    {
                        User user = new User();
                        //user.UserId = Convert.ToInt32(rdr["userId"]);
                        user.Email = rdr["Email"].ToString();
                        user.Password = rdr["Password"].ToString();
                        //user.Name = rdr["Name"].ToString();

                        UserList.Add(user);
                    }
                }
                if(UserList.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home",UserList); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        public interface ILoginValidation
        {
            public List<User> ValidateUserLogin(User user);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}

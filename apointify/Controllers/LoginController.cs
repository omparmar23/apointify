using apointify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace apointify.Controllers
{
    public class LoginController : Controller
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult demo()
        {
            return View();
        }


        public IActionResult create()
        {
            return View();
        }



        public IActionResult SignUp()
        {

            return View();
        }

        public List<User> ValidateUserLogin(User users)
        {
            List<User> customerList = new List<User>();
            try
            {
                using (con = new SqlConnection(Constr))
                {
                    con.Open();
                    var cmd = new SqlCommand("Proc_Login_authentication", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Email", users.Email);
                    cmd.Parameters.AddWithValue("@Password", users.Password);
                    //SqlParameter outputPara = new SqlParameter();
                    //outputPara.ParameterName = "@Email";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        User user = new User();
                        user.UserId = Convert.ToInt32(rdr["userId"]);
                        user.Name = rdr["Prefix"].ToString();
                        user.Password = rdr["FirstName"].ToString();
                        user.Email = rdr["Email"].ToString();
                        user.City = Convert.ToString(rdr["City"]);


                        customerList.Add(user);
                    }
                }
                return customerList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public interface ILoginValidation
        {
            public List<User> ValidateCustomerLogin(User user);
        }


    }
}

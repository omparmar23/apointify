using apointify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apointify.Controllers
{

    public class UserController : ControllerBase
    {

        OmParmarContext DBEntities = new OmParmarContext();
        [HttpGet, Route("api/User")]
        public List<User> Get()
        {
            List<User> serviceReponse = new List<User>();
            try
            {
            using (DBEntities = new OmParmarContext())
            {
                var data = DBEntities.Users.ToList();
                serviceReponse = data;
            }

            }

            catch (Exception ex)
             {
                 //serviceReponse.data = false;
                 Console.WriteLine(ex.Message);
             }
            return serviceReponse;
        }
    }
}
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
            
                using (DBEntities = new OmParmarContext())
                {
                    var data = DBEntities.Users.ToList();
                    serviceReponse = data ;
                    /*serviceReponse.status_code = "200";
                    serviceReponse.message = "Data Fetched successfully";*/
                }
            
           /* catch (Exception ex)
            {
                //serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();
            }*/
            return serviceReponse;
        }

        
    }
}

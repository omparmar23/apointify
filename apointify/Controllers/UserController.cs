using apointify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace apointify.Controllers
{
    
    public class UserController : ControllerBase
    {

        OmParmarContext DBEntities = new OmParmarContext();
        [HttpGet, Route("api/GetUserDetails")]
        public ServiceResponse<List<UsersTable>> Get()
        {
            ServiceResponse<List<UsersTable>> serviceReponse = new ServiceResponse<List<UsersTable>>();
            try
            {
                using (DBEntities = new OmParmarContext())
                {
                    var user = DBEntities.UsersTables.ToList();
                    serviceReponse.data = user;
                    serviceReponse.status_code = "200";
                    serviceReponse.message = "Data Fetched successfully";
                }
            }
            catch (Exception ex)
            {
                //serviceReponse.data = false;
                serviceReponse.status_code = "000";
                serviceReponse.message = "Exception: " + ex.Message.ToString();
            }
            return serviceReponse;
        }
    }
}

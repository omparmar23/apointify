using apointify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apointify.Controllers
{

    public class EmployeeController : ControllerBase
    {
        OmParmarContext DBEntities = new OmParmarContext();






        [HttpGet, Route("api/EmployeeData")]
        public ServiceResponse<List<Employee>> GetEmployeeData()
        {
            ServiceResponse<List<Employee>> serviceReponse = new ServiceResponse<List<Employee>>();
            try
            {
                using (DBEntities = new OmParmarContext())
                {
                    var user = DBEntities.Employees.ToList();
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


        [HttpPost, Route("api/UpateEmployeeData")]

         <List<Employee>> AddDetails = new <List<Employee>>








    }
}

using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class ApointmentController : Controller
    {
        OmParmarContext DBEntities = new OmParmarContext();
        public IActionResult Index(int Id)
        {
            
            return View();
        }

        public IActionResult Create(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public IActionResult bookings()
        {


            return View();
        }

        public IActionResult Book(AppointmentVM appointment)
        {

            
           
            if(appointment.AppointmentId == 0) 
            {
                Appointment newappointment = new Appointment();
                newappointment.AppointmentId = new int();
                newappointment.FirmId = appointment.FirmId;
                newappointment.UserId = appointment.UserId;
                newappointment.AppointmentDate = appointment.AppointmentDate;
                newappointment.TimeSlot = appointment.TimeSlot;
/*              
                newappointment.IsDeleted = appointment.IsDeleted;
                newappointment.InsertDate = DateTime.Now;
                newappointment.UpdatedDate = DateTime.Now;
*/
                appointment.FirmId = new int();
                DBEntities.Appointments.Add(newappointment);
                DBEntities.SaveChanges();
            }

            ViewBag.Timeslot =appointment.TimeSlot;
            ViewBag.FrimId = appointment.FirmId; 
           /* ViewBag.UserId = appointment.UserId;*/
            ViewBag.FirmId = appointment.FirmId;

            ViewBag.AppointmentDate = appointment.AppointmentDate.ToString("dd-MMM-yyyy"); ;

            return View();
        }

        [HttpGet, Route("api/Appointment")]
        public ServiceResponse<List<Appointment>> List()
        {
            ServiceResponse<List<Appointment>> serviceReponse = new ServiceResponse<List<Appointment>>();

            try
            {
                using (DBEntities = new OmParmarContext())
                {
                    var data = DBEntities.Appointments.ToList();
                    serviceReponse.data = data ;
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

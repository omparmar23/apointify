using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



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
                newappointment.BookingInstructions = appointment.BookingInstructions;
                appointment.FirmId = new int();
                DBEntities.Appointments.Add(newappointment);
                DBEntities.SaveChanges();
            }

            ViewBag.Timeslot =appointment.TimeSlot; 
            ViewBag.FirmId = appointment.FirmId;

            ViewBag.AppointmentDate = appointment.AppointmentDate.ToString("dd-MMM-yyyy"); 

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

        public IActionResult appointment()
        {

            var appointments = DBEntities.Allappointments.Where( m => m.UserId == Convert.ToInt32(HttpContext.Session.GetString("UserId")) && m.AppointmentDate >= DateTime.Now.Date);

            return View(appointments);
        }

        public IActionResult Cancle(int id)
        {
            var dbObject = DBEntities.Appointments.Where(m => m.AppointmentId == id).FirstOrDefault();
            dbObject.IsDeleted = true;
            DBEntities.SaveChanges();
            return RedirectToAction("appointment");
        }
    }
}

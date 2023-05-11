using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Text;

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
                DBEntities.Appointments.Add(newappointment);
                DBEntities.SaveChanges();
               

                

                var userEmail = DBEntities.Users.Where(m => m.UserId == appointment.UserId).FirstOrDefault();
                var firmEmail = DBEntities.FirmDetails.Where(m => m.FirmId ==  appointment.FirmId).FirstOrDefault();
                var service = DBEntities.Services.Where(m => m.ServiceId == firmEmail.ServiceId).FirstOrDefault();

                var subject = "Your Appointment Is Confirmed";
                StringBuilder userEmail_template = new StringBuilder();
                userEmail_template.AppendLine($"<h1>Hello {userEmail.Name}</h1>");
                userEmail_template.AppendLine($"<p>This email confirms your appointments for{service.ServiceName}) with{firmEmail.FirmName} at {firmEmail.Address} on{appointment.AppointmentDate} on{appointment.TimeSlot}<p> <br>");
                userEmail_template.AppendLine($"<br><b>You will get an individual reminder email before each scheduled appointment. If you have questions before your appointment, use the contact details below to get in touch with us.</b>");
                userEmail_template.AppendLine($"<b>Thanks for scheduling with Business Name!</b>");

                SendEmail(userEmail.Email, Convert.ToString(userEmail_template), subject);


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

        [HttpGet,Route("api/Allappointment")]
        public List<Allappointment>  Lsit()
        {
            List<Allappointment> user = new List<Allappointment>();
            using(DBEntities = new OmParmarContext())
            {
                var data = DBEntities.Allappointments.ToList();
                user = data;
            }
           
			return user;
		}






        public void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new System.Net.Mail.MailMessage("youremail@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new System.Net.NetworkCredential("tarwin1272@gmail.com", "fkhblvjiimwjfmmc");
                /*NetworkCred.Domain = ".com";
                */
                /*smtp.UseDefaultCredentials = true;*/
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }

        }
    }
}

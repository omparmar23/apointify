using apointify.Models;
using apointify.VirtualModels;
using Microsoft.AspNetCore.Mvc;

namespace apointify.Controllers
{
    public class ApointmentController : Controller
    {
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

            OmParmarContext DBEntities = new OmParmarContext();
           
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

           /* 
            ViewBag.UserId = appointment.UserId;
            ViewBag.FirmId = appointment.FirmId;
           */ 
            ViewBag.AppointmentDate = appointment.AppointmentDate;

            return View();
        }

        /*public IActionResult viewDetails()
        {

            return View();
        }*/
    }
}

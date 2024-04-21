using apointify.Models;
using System.ComponentModel.DataAnnotations;

namespace apointify.VirtualModels
{
    public class AppointmentVM
    {
        public int AppointmentId { get; set; }

        public int? FirmId { get; set; }

        public int? UserId { get; set; }

        [Display(Name = "Appointment Date*")]
        [DataType(DataType.Date)]
        
        public DateTime AppointmentDate { get; set; }

        /*[EnumDataType(typeof(TimeSlot))]*/

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-mm-ss}", ApplyFormatInEditMode = true)]

        [Display(Name = "Description*")]
        [Required(ErrorMessage = "Description is Required.")]
        public string? BookingInstructions { get; set; }

        public TimeSpan TimeSlot { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual FirmDetail? Firm { get; set; }

        public virtual User? User { get; set; }


    }
}
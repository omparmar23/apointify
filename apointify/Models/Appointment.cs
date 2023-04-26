using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apointify.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }


    [Display(Name = "Appointment Date*")]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }

    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH-mm-ss}", ApplyFormatInEditMode = true)]
    public TimeSpan TimeSlot { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual FirmDetail? Firm { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apointify.Models;

public partial class Allappointment
{
    public int UserId { get; set; }

    public string MobileNumber { get; set; } = null!;

    public int AppointmentId { get; set; }

    [Display(Name = "Appointment Date*")]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }

    public TimeSpan TimeSlot { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string FirmName { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}

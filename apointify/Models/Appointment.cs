using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan TimeSlot { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? BookingInstructions { get; set; }

    public virtual FirmDetail? Firm { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Appointment
{
    public int ApointmentId { get; set; }

    public int? FirmId { get; set; }

    public int? UserId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ServiceProvider? Firm { get; set; }

    public virtual User? User { get; set; }
}

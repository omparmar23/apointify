using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Appointment
{
    public int ApointmentId { get; set; }

    public int? Firm { get; set; }

    public int? User { get; set; }

    public DateTime AppointmentDate { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ServiceProvider? FirmNavigation { get; set; }

    public virtual User? UserNavigation { get; set; }
}

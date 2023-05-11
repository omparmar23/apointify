using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class FirmDetail
{
    public int FirmId { get; set; }

    public int Userid { get; set; }

    public int ServiceId { get; set; }

    public string ServiceType { get; set; } = null!;

    public string FirmName { get; set; } = null!;

    public string FirmImage { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Service Service { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

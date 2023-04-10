using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class NewAppointment
{
    public int ApointmentId { get; set; }

    public int? Firm { get; set; }

    public int? User { get; set; }

    public DateTime AppointmentDate { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? City { get; set; }

    public string? MobileNumber { get; set; }

    public int? ServiceId { get; set; }

    public string? ServiceType { get; set; }

    public string? ServiceProviderUsername { get; set; }

    public string? FirmName { get; set; }

    public string? FirmOwnerName { get; set; }

    public string? ServiceProviderEmail { get; set; }

    public string? Password { get; set; }

    public string? ServiceProviderMobileNumber { get; set; }

    public string? Address { get; set; }

    public string? ServiceProviderCity { get; set; }

    public string? ServiceName { get; set; }
}

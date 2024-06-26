﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apointify.Models;

public partial class Allappointment
{
    [Display(Name = "Appointment Date*")]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }

    public int AppointmentId { get; set; }

    public string? BookingInstructions { get; set; }

    public TimeSpan TimeSlot { get; set; }

    public bool? IsDeleted { get; set; }

    public string Usersname { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string? UserMobile { get; set; }

    public int UserId { get; set; }

    public string? City { get; set; }

    public string FirmName { get; set; } = null!;

    public int FirmId { get; set; }

    public string FirmAddress { get; set; } = null!;

    public string FirmMobile { get; set; } = null!;

    public string FirmEmail { get; set; } = null!;
}

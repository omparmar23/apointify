﻿using apointify.Models;

namespace apointify.VirtualModels
{
    public class ServiceProviderVM
    {
        public int FirmId { get; set; }

        public int? ServiceId { get; set; }

        public string ServiceType { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string FirmName { get; set; } = null!;

        public string FirmOwnerName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

        public virtual Service? Service { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class FirmService
{
    public string? ServiceName { get; set; }

    public int FirmId { get; set; }

    public int? Service { get; set; }

    public string ServiceType { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string FirmName { get; set; } = null!;

    public string FirmOwnerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }
}

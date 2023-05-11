using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<FirmDetail> FirmDetails { get; set; } = new List<FirmDetail>();

    public virtual ICollection<ServiceProvider> ServiceProviders { get; set; } = new List<ServiceProvider>();
}

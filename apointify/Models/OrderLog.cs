using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class OrderLog
{
    public int LogId { get; set; }

    public int? CustomerId { get; set; }

    public string? Store { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Action { get; set; }
}

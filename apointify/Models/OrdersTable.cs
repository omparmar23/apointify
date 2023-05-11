using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class OrdersTable
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? CustomerId { get; set; }

    public string? Store { get; set; }

    public int? EmployeeId { get; set; }

    public decimal? Amount { get; set; }
}

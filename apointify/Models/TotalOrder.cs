using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class TotalOrder
{
    public string? Firstname { get; set; }

    public int? HavingTotalOrder { get; set; }

    public decimal? TotalAmount { get; set; }
}

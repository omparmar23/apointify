using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Orderdetail
{
    public long OrderdetailsId { get; set; }

    public long? OrderId { get; set; }

    public string? ItemName { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Qty { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? DiscountRate { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? FinalAmount { get; set; }

    public DateTime? InsertedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Order? Order { get; set; }
}

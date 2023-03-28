using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Order
{
    public long OrderId { get; set; }

    public long? CustomerId { get; set; }

    public long? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? Shippingdate { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? InsertedDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee1? Employee { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; } = new List<Orderdetail>();
}

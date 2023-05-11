using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class NewCustomer
{
    public int CustomerId { get; set; }

    public string CustName { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Grade { get; set; }

    public int SalesmanId { get; set; }
}

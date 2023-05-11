using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class NewSalesman
{
    public int SalesmanId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public decimal Commission { get; set; }
}

using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class UserInfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public short? Age { get; set; }

    public decimal? Percentage { get; set; }

    public bool? PassFail { get; set; }

    public long? StudentId { get; set; }

    public decimal? Fees { get; set; }
}

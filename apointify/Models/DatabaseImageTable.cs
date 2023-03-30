using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class DatabaseImageTable
{
    public string? ImageName { get; set; }

    public byte[]? Image { get; set; }
}

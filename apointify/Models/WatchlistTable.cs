using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class WatchlistTable
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CompanyId { get; set; }

    public virtual CompanyTable? Company { get; set; }

    public virtual UsersTable? User { get; set; }
}

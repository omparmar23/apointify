using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class UsersTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<WatchlistTable> WatchlistTables { get; } = new List<WatchlistTable>();
}

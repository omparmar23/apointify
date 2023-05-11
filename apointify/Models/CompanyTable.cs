using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class CompanyTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string Exchange { get; set; } = null!;

    public string Industry { get; set; } = null!;

    public string Sector { get; set; } = null!;

    public virtual ICollection<StocksTable> StocksTables { get; set; } = new List<StocksTable>();

    public virtual ICollection<WatchlistTable> WatchlistTables { get; set; } = new List<WatchlistTable>();
}

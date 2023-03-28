using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class TransactionsTable
{
    public int Id { get; set; }

    public int? StockId { get; set; }

    public string? TransactionType { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Date { get; set; }

    public virtual StocksTable? Stock { get; set; }
}

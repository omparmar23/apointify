using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class StocksTable
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public DateTime? Date { get; set; }

    public virtual CompanyTable? Company { get; set; }

    public virtual ICollection<TransactionsTable> TransactionsTables { get; } = new List<TransactionsTable>();
}

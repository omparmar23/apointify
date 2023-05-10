using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MobileNo { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? UserName { get; set; }

    public string? UserEmailAddress { get; set; }

    public string? Password { get; set; }

    public string? HomeAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public DateTime? InsertedDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public int Role { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string? City { get; set; }

    public DateTime? InsertData { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string RoleName { get; set; } = null!;
}

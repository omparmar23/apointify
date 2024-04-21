using System;
using System.Collections.Generic;

namespace apointify.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string City { get; set; } = null!;

    public int? Role { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? RoleName { get; set; }
}

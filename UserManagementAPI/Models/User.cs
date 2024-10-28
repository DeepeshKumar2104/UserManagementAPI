using System;
using System.Collections.Generic;

namespace UserManagementAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Username { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Gender { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    public virtual ICollection<Employment> Employments { get; set; } = new List<Employment>();
}

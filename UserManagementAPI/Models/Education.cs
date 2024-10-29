using System;
using System.Collections.Generic;

namespace UserManagementAPI.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public int? UserId { get; set; }

    public string? Degree { get; set; }

    public string? Institution { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? Updated { get; set; }


    public virtual User? User { get; set; }
}

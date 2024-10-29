using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Models;

namespace UserManagementAPI.DTO
{
    public class EmploymentDTO
    {
        public int EmploymentId { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "Company name length cannot exceed 100 characters.")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(50, ErrorMessage = "Job title length cannot exceed 50 characters.")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for Start Date.")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format for End Date.")]
        public DateTime? EndDate { get; set; }

        public virtual User? User { get; set; }
    }
}

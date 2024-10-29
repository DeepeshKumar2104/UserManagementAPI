using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Models;

namespace UserManagementAPI.Models
{
    public class EducationDTO
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Degree is required.")]
        [StringLength(100, ErrorMessage = "Degree length cannot exceed 100 characters.")]
        public string? Degree { get; set; }

        [Required(ErrorMessage = "Institution is required.")]
        [StringLength(100, ErrorMessage = "Institution length cannot exceed 100 characters.")]
        public string? Institution { get; set; }

        
    }
}

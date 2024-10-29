using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.DTO
{
    public class AddressDTO
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(100, ErrorMessage = "Street length cannot exceed 100 characters.")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City length cannot exceed 50 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State length cannot exceed 50 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country length cannot exceed 50 characters.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        [StringLength(10, ErrorMessage = "ZipCode length cannot exceed 10 characters.")]
        public string? ZipCode { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

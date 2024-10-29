using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name length cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(100, ErrorMessage = "Email length cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password hash is required.")]
        [StringLength(256, ErrorMessage = "Password hash length cannot exceed 256 characters.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username length cannot exceed 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender length cannot exceed 10 characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "Bio length cannot exceed 500 characters.")]
        public string Bio { get; set; }
    }
}

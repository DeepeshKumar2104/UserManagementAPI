namespace UserManagementAPI.DTO
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace TestDauVaoXuong.DTO
{
    public class CreateStaffRequest
    {
        [Required]
        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountFe { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountFpt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string StaffCode { get; set; }
    }
}

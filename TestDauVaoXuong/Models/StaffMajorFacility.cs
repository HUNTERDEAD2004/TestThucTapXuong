using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDauVaoXuong.Models
{
    public class StaffMajorFacility
    {
        [Key]
        public Guid Id { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey("MajorFacility")]
        public Guid? MajorFacilityId { get; set; }

        [ForeignKey("Staff")]
        public Guid? StaffId { get; set; }

        public MajorFacility MajorFacility { get; set; }

        public Staff Staff { get; set; }
    }
}

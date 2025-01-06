using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDauVaoXuong.Models
{
    public class MajorFacility
    {
        [Key]
        public Guid Id { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey("DepartmentFacility")]
        public Guid? DepartmentFacilityId { get; set; }

        [ForeignKey("Major")]
        public Guid? MajorId { get; set; }

        public DepartmentFacility DepartmentFacility { get; set; }

        public Major Major { get; set; }

        public ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; }
    }
}

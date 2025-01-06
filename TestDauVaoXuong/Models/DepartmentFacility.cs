using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDauVaoXuong.Models
{
    public class DepartmentFacility
    {
        [Key]
        public Guid? Id { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [ForeignKey("Department")]
        public Guid? DepartmentId { get; set; }

        [ForeignKey("Facility")]
        public Guid? FacilityId { get; set; }

        [ForeignKey("Staff")]
        public Guid? StaffId { get; set; }

        public Department Department { get; set; }

        public Facility Facility { get; set; }

        public Staff Staff { get; set; }

        public ICollection<MajorFacility> MajorFacilities { get; set; }
    }
}

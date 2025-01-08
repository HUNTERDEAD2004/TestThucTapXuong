using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TestDauVaoXuong.Models
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }

        public byte? Status { get; set; } 

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string AccountFe { get; set; }

        public string AccountFpt { get; set; }

        public string Name { get; set; }

        public string StaffCode { get; set; }

        public ICollection<DepartmentFacility> DepartmentFacilities { get; set; }

        public ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; }
    }
}

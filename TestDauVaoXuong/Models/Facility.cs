using System.ComponentModel.DataAnnotations;

namespace TestDauVaoXuong.Models
{
    public class Facility
    {
        [Key]
        public Guid Id { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<DepartmentFacility> DepartmentFacilities { get; set; }
    }
}

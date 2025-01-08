using System.ComponentModel.DataAnnotations;
using TestDauVaoXuong.Models;

namespace TestDauVaoXuong.DTO.StaffMajorFacility
{
    public class BomonChuyennganhDto
    {
        public Guid Id { get; set; }

        public string AccountFe { get; set; }

        public string AccountFpt { get; set; }

        public string StaffName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public byte Status { get; set; }

        public string StaffCode { get; set; }

        public Guid FacilityId { get; set; }

        public string FacilityName { get; set; }

        public Guid MajorId { get; set; }

        public string MajorName { get; set; }

        public Guid DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}

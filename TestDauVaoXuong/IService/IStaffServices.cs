using TestDauVaoXuong.DTO;
using TestDauVaoXuong.DTO.Staff.Update;
using TestDauVaoXuong.Models;

namespace TestDauVaoXuong.IService
{
    public interface IStaffServices
    {
        List<Staff> GetAllStaff();

        Staff GetById(Guid id);

        bool CreateStaff(CreateStaffRequest request);

        bool UpdateStaff(UpdateStaffRequest request);

        bool DeleteStaff(Guid id);
    }
}

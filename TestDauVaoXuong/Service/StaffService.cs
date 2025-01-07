using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestDauVaoXuong.DTO;
using TestDauVaoXuong.DTO.Staff.Update;
using TestDauVaoXuong.IService;
using TestDauVaoXuong.Models;

namespace TestDauVaoXuong.Service
{
    public class StaffService : IStaffServices
    {
        private readonly AppDbcontext _dbcontext;

        public StaffService(AppDbcontext context)
        {
            _dbcontext = context;
        }

        public bool CreateStaff(CreateStaffRequest request)
        {
            try
            {
                if (request == null)
                {
                    return false;
                }

                var createStaff = new Staff
                {
                    Name = request.Name,
                    AccountFe = request.AccountFe,
                    AccountFpt = request.AccountFpt,
                    StaffCode = request.StaffCode,
                    CreatedDate = DateTime.Now, // Gán thời gian tao
                    LastModifiedDate = DateTime.Now, // Gán thời gian cap nhat
                    Status = 1
                };

                _dbcontext.Staff.Add(createStaff);
                _dbcontext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteStaff(Guid id)
        {
            try
            {
                var existingStaff = _dbcontext.Staff.Find(id);
                if (existingStaff != null)
                {
                    existingStaff.Status = 2;

                    _dbcontext.Staff.Update(existingStaff);
                    _dbcontext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Staff> GetAllStaff()
        {
            return _dbcontext.Staff.ToList();
        }

        public Staff GetById(Guid id)
        {
            var GetStaffById = _dbcontext.Staff.Find(id);

            return GetStaffById;
        }

        public bool UpdateStaff(UpdateStaffRequest request)
        {
            try
            {
                if (request == null)
                {
                    return false;
                }
                var existingStaff = _dbcontext.Staff.Find(request.Id);
                if (existingStaff != null)
                {
                    existingStaff.Name = request.Name;
                    existingStaff.AccountFe = request.AccountFe;
                    existingStaff.AccountFpt = request.AccountFpt;
                    existingStaff.StaffCode = request.StaffCode;
                    existingStaff.Status = request.Status;
                    existingStaff.LastModifiedDate = DateTime.Now;

                    _dbcontext.Staff.Update(existingStaff);
                    _dbcontext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
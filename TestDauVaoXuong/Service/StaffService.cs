using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OfficeOpenXml;
using System.Text.RegularExpressions;
using TestDauVaoXuong.DTO;
using TestDauVaoXuong.DTO.Staff.Update;
using TestDauVaoXuong.DTO.StaffMajorFacility;
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

        public List<BomonChuyennganhDto> GetMDSF(Guid id)
        {
            var MajorDepartmentStaffFacilty = (from staffs in _dbcontext.Staff
                                              join departmentFacility in _dbcontext.DepartmentFacilities on staffs.Id equals departmentFacility.Id
                                              join department in _dbcontext.Departments on departmentFacility.DepartmentId equals department.Id
                                              join facility in _dbcontext.Facilities on departmentFacility.FacilityId equals facility.Id
                                              join majorFacility in _dbcontext.MajorFacilities on departmentFacility.Id equals majorFacility.DepartmentFacilityId
                                              join major in _dbcontext.Majors on majorFacility.MajorId equals major.Id
                                              select new BomonChuyennganhDto
                                              {
                                                  Id = staffs.Id,
                                                  AccountFe = staffs.AccountFe,
                                                  AccountFpt = staffs.AccountFpt,
                                                  StaffCode = staffs.StaffCode,
                                                  StaffName = staffs.Name,
                                                  FacilityId = facility.Id,
                                                  FacilityName = facility.Name,
                                                  DepartmentId = department.Id,
                                                  DepartmentName = department.Name,
                                                  MajorId = major.Id,
                                                  MajorName = major.Name,
                                              }).ToList();

            var GetStaffById = _dbcontext.Staff.Find(id);
            if (GetStaffById != null)
            {
                return MajorDepartmentStaffFacilty.ToList();
            }
            return null;
        }

        public byte[] ExportToExcel()
        {
            var dataStaff = (from staff in _dbcontext.Staff
                             join
                            staffMajorFacility in _dbcontext.StaffMajorFacilities
                            on staff.Id equals staffMajorFacility.StaffId
                             join majorFacility in _dbcontext.MajorFacilities
                             on staffMajorFacility.MajorFacilityId equals majorFacility.Id
                             join major in _dbcontext.Majors
                             on majorFacility.MajorId equals major.Id
                             join departmentFacilities in _dbcontext.DepartmentFacilities
                             on staff.Id equals departmentFacilities.StaffId
                             join department in _dbcontext.Departments
                             on departmentFacilities.DepartmentId equals department.Id
                             join facility in _dbcontext.Facilities
                             on departmentFacilities.FacilityId equals facility.Id
                             select new
                             {
                                 staff.StaffCode,
                                 staff.Name,
                                 staff.AccountFpt,
                                 staff.AccountFe,
                                 major_department_facility = $"{major.Name} - {department.Name} - {facility.Name},"
                             }).ToList();

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Template Thông Tin Nhân Viên");
                workSheet.Cells[1, 1].Value = "STT";
                workSheet.Cells[1, 2].Value = "Mã Nhân Viên";
                workSheet.Cells[1, 3].Value = "Tên Nhân Viên";
                workSheet.Cells[1, 4].Value = "Tài Khoản FPT";
                workSheet.Cells[1, 5].Value = "Tài Khoản FE";
                workSheet.Cells[1, 6].Value = "Bộ môn chuyên ngành";
                for (int i = 0; i < dataStaff.Count; i++)
                {
                    workSheet.Cells[i + 2, 1].Value = i + 1;
                    workSheet.Cells[i + 2, 2].Value = dataStaff[i].StaffCode;
                    workSheet.Cells[i + 2, 3].Value = dataStaff[i].Name;
                    workSheet.Cells[i + 2, 4].Value = dataStaff[i].AccountFpt;
                    workSheet.Cells[i + 2, 5].Value = dataStaff[i].AccountFe;
                    var values = dataStaff[i].major_department_facility.Split(",").Select(x => x.Trim()).ToList();
                    workSheet.Cells[i + 2, 6].Value = values[0];
                    var validation = workSheet.DataValidations.AddListValidation(workSheet.Cells[i + 2, 6].Address);
                    foreach (var value in values)
                    {
                        validation.Formula.Values.Add(value);
                    }
                }
                return package.GetAsByteArray();
            }
        }

        public string ImportToExcel(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return "File không hợp lệ!";
            }

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (workSheet == null)
                    {
                        return "Không tìm thấy sheet dữ liệu!";
                    }

                    var rowCount = workSheet.Dimension.Rows;
                    var staffList = new List<Staff>();
                    var majorFacilityList = new List<MajorFacility>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var staffCode = workSheet.Cells[row, 2].Value?.ToString();
                            var name = workSheet.Cells[row, 3].Value?.ToString();
                            var accountFpt = workSheet.Cells[row, 4].Value?.ToString();
                            var accountFe = workSheet.Cells[row, 5].Value?.ToString();
                            var majorDepartmentFacility = workSheet.Cells[row, 6].Value?.ToString();

                            if (string.IsNullOrEmpty(staffCode) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(accountFe) || string.IsNullOrEmpty(accountFpt) || string.IsNullOrEmpty(majorDepartmentFacility))
                            {
                                return $"Dữ liệu không hợp lệ tại dòng {row}: Mã nhân viên hoặc Tên nhân viên bị thiếu.";
                            }

                            var staff = new Staff
                            {
                                StaffCode = staffCode,
                                Name = name,
                                Status = 1,
                                AccountFpt = accountFpt,
                                AccountFe = accountFe,
                                CreatedDate = DateTime.Now
                            };

                            // Tách Major, Department, Facility từ chuỗi
                            var parts = majorDepartmentFacility.Split("-").Select(x => x.Trim()).ToList();
                            if (parts.Count == 3)
                            {
                                var majorName = parts[0];
                                var departmentName = parts[1];
                                var facilityName = parts[2];
                                var major = _dbcontext.Majors.FirstOrDefault(x => x.Name == majorName);
                                var department = _dbcontext.Departments.FirstOrDefault(x => x.Name == departmentName);
                                var facility = _dbcontext.Facilities.FirstOrDefault(x => x.Name == facilityName);
                                var idDepartmentFacility = Guid.NewGuid();
                                var idMajorFacility = Guid.NewGuid();
                                if (major != null && department != null && facility != null)
                                {
                                    var majorFacility = new MajorFacility
                                    {
                                        Id = idMajorFacility,
                                        MajorId = major.Id,
                                        DepartmentFacilityId = idDepartmentFacility,
                                        Status = 1,
                                        CreatedDate = DateTime.Now
                                    };
                                    majorFacilityList.Add(majorFacility);
                                    staff.StaffMajorFacilities = new List<StaffMajorFacility>
                                    {
                                        new StaffMajorFacility
                                        {
                                            Id = Guid.NewGuid(),
                                            StaffId = staff.Id,
                                            MajorFacilityId = idMajorFacility,
                                            Status = 1,
                                            CreatedDate = DateTime.Now
                                        }
                                    };

                                    staff.DepartmentFacilities = new List<DepartmentFacility>
                                    {
                                        new DepartmentFacility
                                        {
                                            Id = idDepartmentFacility,
                                            Status = 1,
                                            DepartmentId = department.Id,
                                            FacilityId = facility.Id,
                                            StaffId = staff.Id,
                                            CreatedDate = DateTime.Now
                                        }
                                    };
                                }
                            }
                            staffList.Add(staff);
                        }
                        catch (Exception ex)
                        {
                            return $"Lỗi tại dòng {row}: {ex.Message}";
                        }
                    }

                    _dbcontext.Staff.AddRange(staffList);
                    _dbcontext.MajorFacilities.AddRange(majorFacilityList);
                    _dbcontext.SaveChanges();
                }
            }

            return "Import thành công!";
        }
    }
}
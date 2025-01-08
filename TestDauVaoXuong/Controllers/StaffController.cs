using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDauVaoXuong.DTO;
using TestDauVaoXuong.DTO.Staff.Update;
using TestDauVaoXuong.IService;
using TestDauVaoXuong.Models;
using TestDauVaoXuong.Service;

namespace TestDauVaoXuong.Controllers
{
    public class StaffController : Controller
    {
        private readonly AppDbcontext _dbcontext;

        private readonly IStaffServices _staffService;

        public StaffController(IStaffServices staffService, AppDbcontext context)
        {
            _staffService = staffService;
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            var staffList =  _staffService.GetAllStaff();

            return View(staffList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStaffRequest request)
        {
            var staffCreate = _staffService.CreateStaff(request);

            return RedirectToAction("Index", staffCreate);
        }


        public IActionResult Update(Guid id)
        {
            var staffById = _staffService.GetById(id);

            return View(staffById);
        }

        [HttpPost]
        public IActionResult Update(UpdateStaffRequest request)
        {
            var staffUpdate = _staffService.UpdateStaff(request);

            return RedirectToAction("Index", staffUpdate);
        }

        public IActionResult Delete(Guid id)
        {
            var staffDelete = _staffService.DeleteStaff(id);

            return RedirectToAction("Index", staffDelete);
        }
      
        public IActionResult GetMDSF(Guid id)
        {
            var staffData = _staffService.GetMDSF(id);

            return View(staffData);
        }

        //[HttpPost]
        //public IActionResult GetMDSFView(Guid id)
        //{
        //    var staffById = _staffService.GetById(id);

        //    return RedirectToAction("EditStaffMajorfacility", staffById);
        //}

        public async Task<IActionResult> Filter(string searchKeyword, int? status)
        {
            var query = _dbcontext.Staff.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                searchKeyword = searchKeyword.ToLower();
                query = query.Where(s =>
                    s.StaffCode.ToLower().Contains(searchKeyword) ||
                    s.Name.ToLower().Contains(searchKeyword) ||
                    s.AccountFpt.ToLower().Contains(searchKeyword) ||
                    s.AccountFe.ToLower().Contains(searchKeyword));
            }

            if (status.HasValue)
            {
                query = query.Where(s => s.Status == status.Value);
            }

            return PartialView("_StaffListPartial", await query.ToListAsync());
        }

        public IActionResult ExportToExcel()
        {
            var exportExcel = _staffService.ExportToExcel();
            return File(exportExcel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Template.xlsx");
        }

        public IActionResult ImportToExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ!");
            }

            var result = _staffService.ImportToExcel(file);

            if (result == "Import thành công!")
            {
                TempData["Success"] = result;
            }
            else
            {
                TempData["Error"] = result;
            }

            return RedirectToAction("Index");
        }

    }
}

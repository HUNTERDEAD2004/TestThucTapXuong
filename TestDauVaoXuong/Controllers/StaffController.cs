using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDauVaoXuong.DTO;
using TestDauVaoXuong.DTO.Staff.Update;
using TestDauVaoXuong.IService;
using TestDauVaoXuong.Models;
using TestDauVaoXuong.Service;

namespace TestDauVaoXuong.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffServices _staffService;

        public StaffController(IStaffServices staffService)
        {
            _staffService = staffService;
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

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var staffDelete = _staffService.DeleteStaff(id);

            return RedirectToAction("Index", staffDelete);
        }
    }
}

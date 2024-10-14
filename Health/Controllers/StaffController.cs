using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class StaffController : Controller
    {
        private StaffService service;
        public StaffController(StaffService staffService)
        {
            service = staffService;
        }
        public IActionResult Index()
        {
            List<Staff> staffs = service.GetStaffs();
            return View(staffs);
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Staff staff)
        {
           service.AddStaff(staff);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {

            Staff staff = service.GetStaff(id);
            return View(staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                service.EditStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);

    }   }
}

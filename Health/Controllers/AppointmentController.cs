using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentService service;
        public AppointmentController(AppointmentService appointmentService)
        {
            service = appointmentService;
        }
        public IActionResult Index()
        {
            List<Appointment> appointments = service.GetAppointments();
            return View(appointments);
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
        public IActionResult Add(Appointment appointment)
        {
            service.AddAppointment(appointment);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Appointment appointment = service.GetAppointment(id);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult EditAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                service.EditAppointment(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}


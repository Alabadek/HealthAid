using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class PrescriptionController : Controller
    {
        private PrescriptionService service;
        public PrescriptionController(PrescriptionService prescriptionService)
        {
            service = prescriptionService;
        }
        public IActionResult Index()
        {
            List<Prescription> prescriptions = service.GetPrescriptions();
            return View(prescriptions);
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
        public IActionResult Add(Prescription prescription)
        {
            service.AddPrescription(prescription);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Prescription prescription = service.GetPrescription(id);
            return View(prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                service.EditPrescription(prescription);
                return RedirectToAction("Index");
            }
            return View(prescription);
        }
    }
}

using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class ConsultationController : Controller
    {
        private ConsultationService service;
        public ConsultationController(ConsultationService consultationService)
        {
            service = consultationService;
        }
        public IActionResult Index()
        {
            List<Consultation> consultations = service.GetConsultations();
            return View(consultations);
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
        public IActionResult Add(Consultation consultation)
        {
            service.AddConsultation(consultation);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {

            Consultation consultation = service.GetConsultation(id);
            return View(consultation);
        }

        [HttpPost]
        public IActionResult Edit(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                service.EditConsultation(consultation);
                return RedirectToAction("Index");
            }
            return View(consultation);
        }
    }
}


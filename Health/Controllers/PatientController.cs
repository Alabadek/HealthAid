using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class PatientController : Controller
    {
        private PatientService service;
        public PatientController(PatientService patientService)
        {
            service = patientService;
        }
        public IActionResult Index()
        {
            PatientService patientService = new PatientService();
            List<Patient> patients = patientService.GetPatients();
            return View(patients);
        }



        public IActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
           service.AddPatient(patient);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            Patient patient = service.GetPatient(id);
            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            service.EditPatient(patient);
            return RedirectToAction("Index");
        }
    }
 


    
}

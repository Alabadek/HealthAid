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
        public IActionResult Index(string? id)
        {
            
              List<Patient> patients = service.GetPatients();

            if (string.IsNullOrEmpty(id))
            {
                return View(patients);
            }
            else
            {
                var patient = patients.Where(x => x.Id == Convert.ToInt32(id)).ToList();
                return View(patient);
            }
                
              
                      
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
            if (ModelState.IsValid)
            {
                service.EditPatient(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }
    }
 


    
}

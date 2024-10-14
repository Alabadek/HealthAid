using Health.Models;
using Health.Services;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    public class SinglePatientController : Controller
    {
       private readonly PatientService _patientService;
        public SinglePatientController(PatientService patientService)
        {
            _patientService = patientService;
        }
        public IActionResult Index(int id)
        {
            
            var patient = _patientService.GetPatient(id);
            return View(patient);



        }


                 
    }




}

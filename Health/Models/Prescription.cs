using System.Security.Principal;

namespace Health.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Medication { get; set; }
        public DateOnly Date { get; set; }
        public int PatientId { get; set; }
        public int StaffId {  get; set; }

    }
}

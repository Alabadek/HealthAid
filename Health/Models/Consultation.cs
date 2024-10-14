namespace Health.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateOnly Date { get; set; }
        public int PatientId { get; set; }
        public int StaffId {  get; set; }
        public string Remarks {  get; set; }
    }
}

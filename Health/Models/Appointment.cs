namespace Health.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public DateOnly Date { get; set; }
        public int StaffId { get; set; }
        public int PatientId { get; set; }


    }
}

namespace Health.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        public string EmergencyContact { get; set; }
        public string MaritalStatus { get; set; }

    }
}

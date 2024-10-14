namespace Health.Models
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public string UserType { get; set; } // "Patient" or "Staff"
    }
}

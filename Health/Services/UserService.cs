using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class UserService
    {
        public string ConnectionString { get; set; }

        public UserService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public bool ValidatePatient(string username, int PatientId) // Change parameter name for clarity
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(PatientId) FROM Patient WHERE FirstName = @FirstName AND PatientId = @PatientId"; // Use PatientId
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@FirstName", username);
                    command.Parameters.AddWithValue("@PatientId", PatientId); // Use parameter name that matches SQL
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        public bool ValidateStaff(string username, int StaffId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(StaffId) FROM Staff WHERE FirstName = @FirstName AND StaffId = @StaffId"; // Assuming 'Id' is still the correct column name for Staff
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@FirstName", username);
                    command.Parameters.AddWithValue("@StaffId", StaffId);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

    }
}

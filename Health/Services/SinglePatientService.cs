using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class SinglePatientService
    {
        public string ConnectionString { get; set; }
        public SinglePatientService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public Patient GetPatient(int id)
        {
            Patient patient = new Patient();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Patient where PatientId =@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            patient.Id = reader.GetInt32(0);
                            patient.FirstName = reader.GetString(1);
                            patient.LastName = reader.GetString(2);
                            patient.DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(3));
                            patient.Gender = reader.GetString(4);
                            patient.Contact = reader.GetString(5);
                            patient.EmergencyContact = reader.GetString(6);
                            patient.MaritalStatus = reader.GetString(7);
                        }
                    }
                }
                return patient;
            }
        }



        
            
        
    }
}

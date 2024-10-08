using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class PatientService
    {
       

        public string ConnectionString {  get; set; }
        public PatientService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Patient";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Patient patient;

                        while (reader.Read())
                        {
                            patient = new Patient();

                            patient.Id = reader.GetInt32(0);
                            patient.FirstName = reader.GetString(1);
                            patient.LastName = reader.GetString(2);
                            patient.DateOfBirth = reader.GetString(3);
                            patient.Gender = reader.GetString(4);
                            patient.Contact = reader.GetString(5);
                            patient.EmergencyContact = reader.GetString(6);
                            patient.MaritalStatus = reader.GetString(7);

                            patients.Add(patient);

                        }
                    }
                }
            }
            return patients;
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
                            patient.FirstName= reader.GetString(1);
                            patient.LastName= reader.GetString(2);
                            patient.DateOfBirth= reader.GetString(3);
                            patient.Gender= reader.GetString(4);
                            patient.Contact = reader.GetString(5);
                            patient.EmergencyContact  = reader.GetString(6);
                            patient.MaritalStatus = reader.GetString(7);
                        }
                    }
                }
                return patient;
            }
        }

        public void AddPatient(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Insert into Patient(FirstName,LastName,DateOfBirth,Gender,Contact,EmergencyContact,MaritalStatus)" +
                    "Values(@FirstName,@LastName,@DateOfBirth,@Gender,@Contact,@EmergencyContact,@MaritalStatus)";
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@Contact", patient.Contact);
                    command.Parameters.AddWithValue("@EmergencyContact", patient.EmergencyContact);
                    command.Parameters.AddWithValue("@MaritalStatus", patient.MaritalStatus);



                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditPatient(Patient patient)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Patient set FirstName=@Fn, LastName=@Ln,DateofBirth=@DoB,Gender=@Gen,Contact=@Contact,EmergencyContact=@EmerCon,MaritalStatus=@MaritalStatus";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Fn", patient.FirstName);
                    command.Parameters.AddWithValue("@Ln", patient.LastName);
                    command.Parameters.AddWithValue("@DoB", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gen", patient.Gender);
                    command.Parameters.AddWithValue("@Contact", patient.Contact);
                    command.Parameters.AddWithValue("@EmerCon", patient.EmergencyContact);
                    command.Parameters.AddWithValue("@MaritalStatus", patient.MaritalStatus);
                    command.Parameters.AddWithValue("@Id", patient.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePatient(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Delete * from Patient where Id = @id";
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery ();
                }
            }
        }


    }
}

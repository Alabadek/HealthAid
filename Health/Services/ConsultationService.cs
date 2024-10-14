using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class ConsultationService
    {
        public string ConnectionString { get; set; }
        public ConsultationService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public List<Consultation> GetConsultations()
        {
            List<Consultation> consultations = new List<Consultation>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Consultation";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Consultation consultation;

                        while (reader.Read())
                        {
                            consultation = new Consultation();

                            consultation.Id = reader.GetInt32(0);
                            consultation.Diagnosis = reader.GetString(1);
                            consultation.Date = DateOnly.FromDateTime(reader.GetDateTime(2));
                            consultation.PatientId = reader.GetInt32(3);
                            consultation.StaffId = reader.GetInt32(4);
                            consultation.Remarks = reader.GetString(5);

                            consultations.Add(consultation);

                        }
                    }
                }
            }
            return consultations;
        }


        public Consultation GetConsultation(int id)
        {
            Consultation consultation = new Consultation();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Consultation where Id = @Id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            consultation.Id = reader.GetInt32(0);
                            consultation.Diagnosis = reader.GetString(1);
                            consultation.Date = DateOnly.FromDateTime(reader.GetDateTime(2));
                            consultation.PatientId= reader.GetInt32(3);
                            consultation.StaffId= reader.GetInt32(4);
                            consultation.Remarks= reader.GetString(5);
                        }
                    }
                }
                return consultation;
            }
        }

        public void AddConsultation(Consultation consultation)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Insert into Consultation (Diagnosis,Date,PatientId,StaffId,Remarks)" +
                    "Values(@Diagnosis,@Date,@PatientId,@StaffId,@Remarks)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Diagnosis", consultation.Diagnosis);
                    command.Parameters.AddWithValue("@Date", consultation.Date);
                    command.Parameters.AddWithValue("@PatientId", consultation.PatientId);
                    command.Parameters.AddWithValue("@StaffId", consultation.StaffId);
                    command.Parameters.AddWithValue("@Remarks", consultation.Remarks);
     
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditConsultation(Consultation consultation)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Consultation set Diagnosis=@Diagnosis,Date=@Date,PatientId=@PatientId,StaffId=@StaffId,Remarks=@Remarks";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Diagnosis", consultation.Diagnosis);
                    command.Parameters.AddWithValue("@Date", consultation.Date);
                    command.Parameters.AddWithValue("@PatientId", consultation.PatientId);
                    command.Parameters.AddWithValue("@StaffId", consultation.StaffId);
                    command.Parameters.AddWithValue("@Remarks", consultation.Remarks);
                    command.Parameters.AddWithValue("@Id", consultation.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteConsultation(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Delete * from Consultation where Id = @id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

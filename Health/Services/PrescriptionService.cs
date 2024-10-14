using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class PrescriptionService
    {


        public string ConnectionString { get; set; }
        public PrescriptionService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public List<Prescription> GetPrescriptions()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Prescription";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Prescription prescription;

                        while (reader.Read())
                        {
                            prescription = new Prescription();

                            prescription.Id = reader.GetInt32(0);
                            prescription.Medication = reader.GetString(1);
                            prescription.Date = DateOnly.FromDateTime(reader.GetDateTime(2));
                            prescription.StaffId = reader.GetInt32(4);
                            prescription.PatientId = reader.GetInt32(3);

                            prescriptions.Add(prescription);

                        }
                    }
                }
            }
            return prescriptions;
        }


        public Prescription  GetPrescription(int id)
        {
            Prescription prescription = new Prescription();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from  Prescription where Id =@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prescription.Id = reader.GetInt32(0);
                            prescription.Medication = reader.GetString(1);
                            prescription.Date = DateOnly.FromDateTime(reader.GetDateTime(2));
                            prescription.StaffId = reader.GetInt32(4);
                            prescription.PatientId = reader.GetInt32(3);
                        }
                    }
                }
                return prescription;
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Insert into Prescription(Medication,Date,StaffId,PatientId)" +
                    "Values(@Medication,@Date,@StaffId,@PatientId)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Medication", prescription.Medication);
                    command.Parameters.AddWithValue("@Date", prescription.Date);
                    command.Parameters.AddWithValue("@StaffId", prescription.StaffId);
                    command.Parameters.AddWithValue("@PatientId", prescription.PatientId);
             
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditPrescription(Prescription prescription)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Prescription set Medication=@Medication,Date=@Date,StaffId=@StaffId,PatientId=@PatientId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Medication", prescription.Medication);
                    command.Parameters.AddWithValue("@Date", prescription.Date);
                    command.Parameters.AddWithValue("@StaffId", prescription.StaffId);
                    command.Parameters.AddWithValue("@PatientId", prescription.PatientId);
                    command.Parameters.AddWithValue("@Id", prescription.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePrescription(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Delete * from Prescription where Id = @id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

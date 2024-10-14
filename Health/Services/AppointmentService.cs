using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class AppointmentService
    {
        public string ConnectionString { get; set; }
        public AppointmentService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Appointment";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Appointment appointment;

                        while (reader.Read())
                        {
                            appointment = new Appointment();

                            appointment.Id = reader.GetInt32(0);
                            appointment.Purpose = reader.GetString(4);
                            appointment.Date = DateOnly.FromDateTime(reader.GetDateTime(1));
                            appointment.PatientId = reader.GetInt32(2);
                            appointment.StaffId = reader.GetInt32(3);

                            appointments.Add(appointment);

                        }
                    }
                }
            }
            return appointments;
        }


        public Appointment GetAppointment(int id)
        {
            Appointment appointment = new Appointment();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Appointment where  Id =@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment.Id = reader.GetInt32(0);
                            appointment.Purpose = reader.GetString(4);
                            appointment.Date = DateOnly.FromDateTime(reader.GetDateTime(1));
                            appointment.PatientId = reader.GetInt32(3);
                            appointment.StaffId = reader.GetInt32(2);
                        }
                    }
                }
                return appointment;
            }
        }

        public void AddAppointment(Appointment appointment)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Insert into Appointment (Date,StaffId,PatientId,Purpose)" +
                    "Values(@Date,@StaffId,@PatientId,@Purpose)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Date", appointment.Date);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@StaffId", appointment .StaffId);
                    command.Parameters.AddWithValue("@Purpose", appointment.Purpose);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditAppointment(Appointment appointment)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Appointment set Date=@Date,PatientId=@PatientId,StaffId=@StaffId,Purpose=@Purpose";

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    command.Parameters.AddWithValue("@Date", appointment.Date);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@StaffId", appointment.StaffId);
                    command.Parameters.AddWithValue("@Purpose", appointment.Purpose);
                    command.Parameters.AddWithValue("@Id", appointment.Id);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

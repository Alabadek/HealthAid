using Health.Models;
using Microsoft.Data.SqlClient;

namespace Health.Services
{
    public class StaffService
    {
        public string ConnectionString {  get; set; }
        public StaffService()
        {
            ConnectionString = "Server=JOCHEBED\\SQLEXPRESS;Database=MyHealthDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Staff";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Staff staff;

                        while (reader.Read())
                        {
                            staff = new Staff();

                            staff.Id = reader.GetInt32(0);
                            staff.FirstName = reader.GetString(1);
                            staff.LastName = reader.GetString(2);
                            staff.Contact = reader.GetString(3);

                            staffs.Add(staff);

                        }
                    }
                }
            }
            return staffs;
        }


        public Staff GetStaff(int id)
        {
            Staff staff = new Staff();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Select * from Staff where StaffId =@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            staff.Id = reader.GetInt32(0);
                            staff.FirstName = reader.GetString(1);
                            staff.LastName = reader.GetString(2);
                            staff.Contact = reader.GetString(3);              
                                         
                        }
                    }
                }
                return staff;
            }
        }

        public void AddStaff(Staff staff)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Insert into Staff(FirstName,LastName,Contact)" +
                    "Values(@FirstName,@LastName,@Contact)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@FirstName", staff.FirstName);
                    command.Parameters.AddWithValue("@LastName", staff.LastName);         
                    command.Parameters.AddWithValue("@Contact", staff.Contact);
 
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditStaff(Staff staff)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "Update Staff set FirstName=@Fn,LastName=@Ln,Contact=@Contact WHERE StaffId = @StaffId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Fn", staff.FirstName);
                    command.Parameters.AddWithValue("@Ln", staff.LastName);
                    command.Parameters.AddWithValue("@Contact", staff.Contact);
                    command.Parameters.AddWithValue("@StaffId", staff.Id);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

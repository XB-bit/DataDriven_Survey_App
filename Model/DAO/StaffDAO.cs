using System.Data.SqlClient;

namespace AIT_Research.Model.DAO
{
    public class StaffDAO
    {
        SurveyDatabaseDAO db = new SurveyDatabaseDAO();

        // check if the staff exsist with username and password
        public Staff StaffLogin(string username, string password)
        {
            Staff staff = null;
            db.connection.Open();
            string query = "SELECT * FROM Staff WHERE staff_username = @username AND staff_password = @password";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                staff = new Staff();
                staff.Id = (int)reader["staff_id"];
            }
            db.connection.Close();
            return staff;
        }
    }
}
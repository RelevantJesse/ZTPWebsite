using System.Configuration;
using System.Data.SqlClient;

namespace ZeroToProgrammer.Tables
{
    public class UsersTable
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static void Add(string username, string passwordHash, string firstName, string lastName, string email)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Users (username, password, firstname, lastname, email) " +
                                                              "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", 
                                                              username, passwordHash, firstName, lastName, email), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public static string GetUserPassword(string userName)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT password FROM Users " +
                                                "WHERE username = @username ", conn);
                cmd.Parameters.AddWithValue("@username", userName);

                return ((string)cmd.ExecuteScalar());
            }
        }

        public static bool UserExists(string userName)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM Users " +
                                                "WHERE username = @username ", conn);
                cmd.Parameters.AddWithValue("@username", userName);

                return ((int)cmd.ExecuteScalar() >= 1);
            }
        }

        public static bool EmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM Users " +
                                                "WHERE email = @email ", conn);
                cmd.Parameters.AddWithValue("@email", email);

                return ((int)cmd.ExecuteScalar() >= 1);
            }
        }
    }
}
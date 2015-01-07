using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ZeroToProgrammer.Tables
{
    public static class NewsTable
    {
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static void Add(string title, string content)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO News (Title, Content) VALUES ('{0}', '{1}')", title, content), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetNews()
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Title, Content, ModifiedDate FROM News ORDER BY CreatedDate DESC", conn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable news = new DataTable();

                news.Load(reader);
                reader.Close();

                return news;
            }
        }
    }
}
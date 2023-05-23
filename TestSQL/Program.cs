using MySql.Data.MySqlClient;
using System;

namespace TP8_winform
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello Giau");

            //CreateCommand("SELECT * FROM test;",GetConnectionString());
            try
            {
                Mymethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
        static void Mymethod()
        {
           
            string connStr = "server=localhost;user=root;database=test;password=;";
            MySqlConnection conn = new MySqlConnection(connStr);
            string sql = "SELECT * FROM teyst";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine("Donnée");
                }
            }
            
        }
        //private static void CreateCommand(string queryString, string connectionString)
        //{
        //    using (SqlConnection connection = new SqlConnection(
        //               connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
        //static private string GetConnectionString()
        //{
        //    return "server=localhost;database=test;uid=root;pwd=;";
        //}
    }
}

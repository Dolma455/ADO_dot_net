using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQL_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstring = @"server=localhost;userid=root;password=root;database=ecommerce";

            MySqlConnection conn = null;
            
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM login;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "login");
                DataTable dt = ds.Tables["login"];

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }

                    Console.Write("\n");                  
                }           
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
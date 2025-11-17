using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=mca;Integrated Security=True;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                con.Open();
                Console.WriteLine("Connection established successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}


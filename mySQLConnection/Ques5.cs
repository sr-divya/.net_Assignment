using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=mca;Integrated Security=True;";

        Console.Write("Enter Student ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        string query = "DELETE FROM Student WHERE StudentID = @id";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine("Record deleted successfully.");
                else
                    Console.WriteLine("No record found with that ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}


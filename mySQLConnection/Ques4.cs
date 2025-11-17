using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=mca;Integrated Security=True;";

        Console.Write("Enter Student ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());

        string query = "UPDATE Student SET Marks = @marks WHERE StudentID = @id";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@marks", marks);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    Console.WriteLine($"{rows} record(s) updated successfully.");
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


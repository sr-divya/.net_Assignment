using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=mca;Integrated Security=True;";
        string query = "SELECT StudentID, Name, Course, Marks FROM Student";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Student Records:");
                Console.WriteLine("ID\tName\tCourse\tMarks");

                // The Read() method moves the cursor to the next record.
                // It must be called before accessing column values.
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["StudentID"]}\t{reader["Name"]}\t{reader["Course"]}\t{reader["Marks"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}


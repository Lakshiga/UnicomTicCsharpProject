using System;
using System.Data;
using System.Data.SqlClient;
using UnicomTicManagementSystem.Models;

public static class StudentRepository
{
    // ✅ Replace this with your real connection string
    private static string connectionString = "Data Source=localhost;Initial Catalog=YourDatabaseName;Integrated Security=True;";

    public static Student GetStudentByUsername(string username)
    {
        Student student = null;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Student WHERE Username = @Username";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Address = reader["Address"].ToString(),
                        Stream = reader["Stream"].ToString()
                    };
                }

                reader.Close();
            }
        }

        return student;
    }
}

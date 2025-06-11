using System;
using System.Data;
using System.Data.SQLite;
using UnicomTicManagementSystem.Data;

public class SubjectController
{
    public DataTable GetSubjects()
    {
        using (var conn = DbCon.GetConnection())
        {
            string query = @"
            SELECT s.SubjectID, s.SubjectName, s.CourseID, c.CourseName
            FROM Subjects s
            JOIN Courses c ON s.CourseID = c.CourseID";

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }


    public DataTable GetSubjectsByCourse(int courseId)
    {
        using (var conn = DbCon.GetConnection())
        {
            string query = "SELECT * FROM Subjects WHERE CourseID = @CourseID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public void AddSubject(string name, int courseId)
    {
        using (var conn = DbCon.GetConnection())
        {
            string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@name, @courseId)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateSubject(int id, string name, int courseId)
    {
        using (var conn = DbCon.GetConnection())
        {
            string query = "UPDATE Subjects SET SubjectName = @name, CourseID = @courseId WHERE SubjectID = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteSubject(int id)
    {
        using (var conn = DbCon.GetConnection())
        {
            string query = "DELETE FROM Subjects WHERE SubjectID = @id";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

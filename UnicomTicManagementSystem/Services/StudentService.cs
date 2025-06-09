using UnicomTicManagementSystem.Data;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories; // For UserRepository
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Services
{
    public class StudentService
    {
        public void Add(Student student, string username, string password)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                // Check if user exists
                int userId = UserRepository.GetUserIdByUsername(username);
                if (userId == -1)
                {
                    // Add user first and get new user id
                    userId = UserRepository.AddUser(new User
                    {
                        Username = username,
                        Password = password,
                        Role = "student"
                    });
                }

                // Insert student with UserId FK
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Students (Name, Address, SectionId, SectionName, UserId) VALUES (@name, @address, @sectionId, @sectionName, @userId)";
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@sectionId", student.SectionId);
                cmd.Parameters.AddWithValue("@sectionName", student.SectionName ?? "");
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
            }
        }


        public List<Student> GetAll()
        {
            var students = new List<Student>();
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Address, SectionId, SectionName FROM Students";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            SectionId = reader.GetInt32(3),
                            SectionName = reader.GetString(4)
                        });
                    }
                }
            }
            return students;
        }

        public void Update(Student student, string username, string password)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                // Update user info
                UserRepository.UpdateUser(new User
                {
                    Id = student.UserId,
                    Username = username,
                    Password = password,
                    Role = "student"  // assuming role does not change here
                });

                // Update student info
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Students SET Name = @name, Address = @address, SectionId = @sectionId, SectionName = @sectionName WHERE Id = @id";
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@sectionId", student.SectionId);
                cmd.Parameters.AddWithValue("@sectionName", student.SectionName ?? "");
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbCon.GetConnection())
            {
                conn.Open();

                // Get UserId of student to delete
                int userId = -1;
                var cmdSelect = conn.CreateCommand();
                cmdSelect.CommandText = "SELECT UserId FROM Students WHERE Id = @id";
                cmdSelect.Parameters.AddWithValue("@id", id);
                var result = cmdSelect.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    userId = Convert.ToInt32(result);
                }

                // Delete student
                var cmdDeleteStudent = conn.CreateCommand();
                cmdDeleteStudent.CommandText = "DELETE FROM Students WHERE Id = @id";
                cmdDeleteStudent.Parameters.AddWithValue("@id", id);
                cmdDeleteStudent.ExecuteNonQuery();

                if (userId != -1)
                {
                    // Delete user
                    var cmdDeleteUser = conn.CreateCommand();
                    cmdDeleteUser.CommandText = "DELETE FROM Users WHERE Id = @userId";
                    cmdDeleteUser.Parameters.AddWithValue("@userId", userId);
                    cmdDeleteUser.ExecuteNonQuery();
                }
            }
        }

    }
}

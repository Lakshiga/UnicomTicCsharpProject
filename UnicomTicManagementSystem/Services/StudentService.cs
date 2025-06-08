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
    internal class StudentService
    {
        public void Add(Student student, string username, string password)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Students (Name, Address, SectionId, SectionName) VALUES (@name, @address, @sectionId, @sectionName)";
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@sectionId", student.SectionId);
                cmd.Parameters.AddWithValue("@sectionName", student.SectionName);
                cmd.ExecuteNonQuery();
            }

            // Add user to repository if username doesn't exist
            if (!UserRepository.UserExists(username))
            {
                UserRepository.AddUser(new User
                {
                    Username = username,
                    Password = password,
                    Role = "student"
                });
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

        public void Update(Student student)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Students SET Name = @name, Address = @address, SectionId = @sectionId, SectionName = @sectionName WHERE Id = @id";
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@sectionId", student.SectionId);
                cmd.Parameters.AddWithValue("@sectionName", student.SectionName);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Students WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

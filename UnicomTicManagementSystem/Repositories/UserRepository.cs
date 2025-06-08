using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using UnicomTicManagementSystem.Data;
using UnicomTicManagementSystem.Models;

namespace UnicomTicManagementSystem.Repositories
{
    public static class UserRepository
    {
        public static void AddUser(User user)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }

        public static User Authenticate(string username, string password)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public static bool UserExists(string username)
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                cmd.Parameters.AddWithValue("@username", username);
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool HasAnyUsers()
        {
            using (var conn = DbCon.GetConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Users";
                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

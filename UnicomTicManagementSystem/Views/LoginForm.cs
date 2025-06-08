using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;

namespace UnicomTicManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!UserRepository.HasAnyUsers())
            {
                lblMessage.Text = "First-time setup: Create Admin Account";
                btnLogin.Text = "Register Admin";
            }
            else
            {
                lblMessage.Text = "Login to your account";
                btnLogin.Text = "Login";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // First-time admin registration
            if (!UserRepository.HasAnyUsers())
            {
                var admin = new User
                {
                    Username = username,
                    Password = password,
                    Role = "Admin"
                };

                UserRepository.AddUser(admin);
                MessageBox.Show("Admin account created successfully.");
                return;
            }

            // Authenticate user
            var user = UserRepository.Authenticate(username, password);

            if (user != null)
            {
                // Store login session
                UserLogin.Username = user.Username;
                UserLogin.Role = user.Role;
                UserLogin.StudentId = user.StudentId;

                this.Hide(); // Hide login window

                switch (user.Role.ToLower())
                {
                    case "admin":
                        var adminDashboard = new MainForm(); // Admin: full control
                        adminDashboard.Show();
                        break;

                    case "staff":
                        var staffDashboard = new StaffDashboard(); // View timetables, add/edit exams and marks
                        staffDashboard.Show();
                        break;

                    case "student":
                        // 🔥 Load student info from repository
                        var student = StudentRepository.GetStudentById(user.StudentId);
                        if (student != null)
                        {
                            UserLogin.Id = student.Id;
                            UserLogin.Name = student.Name;
                            UserLogin.Username = student.Username;
                            UserLogin.Password = student.Password;
                            UserLogin.Address = student.Address;
                            UserLogin.Stream = student.Stream;
                        }

                        var studentDashboard = new StudentDashboard(); // View own marks + timetable
                        studentDashboard.Show();
                        break;

                    case "lecturer":
                        var lecturerDashboard = new LecturerDashboard(); // View timetable, add/edit marks
                        lecturerDashboard.Show();
                        break;

                    default:
                        MessageBox.Show("Unknown role. Access denied.");
                        this.Show(); // Show login again
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

    }
}
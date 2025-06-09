using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;

namespace UnicomTicManagementSystem.Views
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            int studentId = UserLogin.StudentId;

            if (studentId <= 0)
            {
                MessageBox.Show("Invalid student session.");
                this.Close();
                return;
            }

            var student = StudentRepository.GetStudentById(studentId);

            if (student != null)
            {
                lblName.Text = student.Name;
                lblUsername.Text = student.Username;
                lblPassword.Text = student.Password;
                lblAddress.Text = student.Address;
                lblStream.Text = student.Stream;
            }
            else
            {
                MessageBox.Show("Student details not found.");
                this.Close();
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {
        }

        private void lblStream_Click(object sender, EventArgs e)
        {

        }
    }
}

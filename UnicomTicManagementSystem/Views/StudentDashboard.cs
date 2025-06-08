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
            string studentId = UserLogin.StudentId;

            if (string.IsNullOrEmpty(studentId))
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
    }
}

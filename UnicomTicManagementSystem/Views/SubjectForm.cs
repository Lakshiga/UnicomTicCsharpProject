using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTicManagementSystem.Views
{
    public partial class SubjectForm : Form
    {
        SubjectController controller = new SubjectController();
        int selectedSubjectId = -1;

        public SubjectForm()
        {
            InitializeComponent();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            DataTable dt = controller.GetSubjects();

            // Bind to DataGridView
            dataGridView1.DataSource = dt;

            // Hide CourseID column
            if (dataGridView1.Columns.Contains("CourseID"))
            {
                dataGridView1.Columns["CourseID"].Visible = false;
            }

            // Show CourseName in ComboBox
            DataTable comboTable = dt.DefaultView.ToTable(true, "CourseID", "CourseName");
            comboBoxSearchCourse.DataSource = comboTable;
            comboBoxSearchCourse.DisplayMember = "CourseName";
            comboBoxSearchCourse.ValueMember = "CourseID";
            comboBoxSearchCourse.SelectedIndex = -1;
        }




        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string name = txtSubjectName.Text;
                int courseId = Convert.ToInt32(comboBoxSearchCourse.SelectedValue);
                controller.AddSubject(name, courseId);
                LoadSubjects();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            {
                if (selectedSubjectId == -1) return;

                controller.DeleteSubject(selectedSubjectId);
                LoadSubjects();
            }
        }

        private void comboBox_subject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            {
                if (selectedSubjectId == -1) return;

                string name = txtSubjectName.Text;
                int courseId = Convert.ToInt32(comboBoxSearchCourse.SelectedValue);
                controller.UpdateSubject(selectedSubjectId, name, courseId);
                LoadSubjects();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            {
                int courseId = Convert.ToInt32(comboBoxSearchCourse.SelectedValue);
                DataTable dt = controller.GetSubjectsByCourse(courseId);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSubjectId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SubjectID"].Value);
                txtSubjectName.Text = dataGridView1.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString();
            }
        }
    }
}

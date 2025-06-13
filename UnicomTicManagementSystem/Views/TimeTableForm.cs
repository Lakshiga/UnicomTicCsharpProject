using System;
using System.Data;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;

namespace UnicomTicManagementSystem.Views
{
    public partial class TimeTableForm : Form
    {
        private TimetableController controller = new TimetableController();
        private int selectedTimetableId = -1;

        public TimeTableForm()
        {
            InitializeComponent();
            LoadSubjects(); // Load comboSubject values from database
        }

        private void TimeTableForm_Load(object sender, EventArgs e)
        {
            LoadTimetableData();
        }

        private void LoadSubjects()
        {
            comboSubject.Items.Clear();
            DataTable dt = controller.GetSubjects(); // assume this method returns available subjects
            foreach (DataRow row in dt.Rows)
            {
                comboSubject.Items.Add(row["SubjectName"].ToString());
            }
        }

        private void LoadTimetableData()
        {
            dataGridView1.DataSource = controller.GetAllTimetables();
        }

        private void ClearForm()
        {
            comboSubject.SelectedIndex = -1;
            txtRoom.Clear();
            txtTimeSlot.Clear();
            selectedTimetableId = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (comboSubject.SelectedItem == null || string.IsNullOrWhiteSpace(txtTimeSlot.Text) || string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                MessageBox.Show("Please enter all fields: Subject, TimeSlot, and Room.");
                return;
            }

            controller.AddTimetable(
                comboSubject.SelectedItem.ToString(),
                txtTimeSlot.Text.Trim(),
                txtRoom.Text.Trim()
            );

            MessageBox.Show("Timetable entry added.");
            LoadTimetableData();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId == -1)
            {
                MessageBox.Show("Select a record to update.");
                return;
            }

            controller.UpdateTimetable(
                selectedTimetableId,
                comboSubject.SelectedItem.ToString(),
                txtTimeSlot.Text.Trim(),
                txtRoom.Text.Trim()
            );

            MessageBox.Show("Timetable updated.");
            LoadTimetableData();
            ClearForm();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["Id"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedTimetableId = Convert.ToInt32(row.Cells["Id"].Value);
                comboSubject.SelectedItem = row.Cells["Subject"].Value.ToString();
                txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();
                txtRoom.Text = row.Cells["Room"].Value.ToString();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            {
                if (selectedTimetableId == -1)
                {
                    MessageBox.Show("Select a record to delete.");
                    return;
                }

                controller.DeleteTimetable(selectedTimetableId);

                MessageBox.Show("Timetable deleted.");
                LoadTimetableData();
                ClearForm();
            }
        }
    }
}

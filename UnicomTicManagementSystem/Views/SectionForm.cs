using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManageSystem.Controllers;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;

namespace UnicomTicManagementSystem.Views
{

    public partial class SectionForm : Form
    {
        private SectionController sectionController = new SectionController();
        public SectionForm()
        {
            InitializeComponent();
            LoadSections();
        }


        private void LoadSections()
        {
            dgvSections.DataSource = null;
            dgvSections.DataSource = sectionController.GetAllSections();
            dgvSections.ClearSelection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var section = new Section
            {
                Name = secName.Text.Trim()
            };
            sectionController.AddSection(section);
            LoadSections();
            secName.Clear();
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {

        }

        private void secName_TextChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (dgvSections.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSections.SelectedRows[0].Cells["Id"].Value);
                sectionController.DeleteSection(id);
                LoadSections();
                secName.Clear();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (dgvSections.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSections.SelectedRows[0].Cells["Id"].Value);
                var section = new Section
                {
                    Id = id,
                    Name = secName.Text.Trim()
                };
                sectionController.UpdateSection(section);
                LoadSections();
                secName.Clear();
            }
        }


        private void dgvSections_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSections.SelectedRows.Count > 0)
            {
                secName.Text = dgvSections.SelectedRows[0].Cells["Name"].Value.ToString();
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            string keyword = secSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(keyword))
            {
                var filteredSections = sectionController.GetAllSections()
                                         .Where(s => s.Name.ToLower().Contains(keyword))
                                         .ToList();

                dgvSections.DataSource = null;
                dgvSections.DataSource = filteredSections;
                dgvSections.ClearSelection();
            }
            else
            {
                LoadSections(); // If search box is empty, reload all sections
            }
        }


        private void secSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }
    }
}
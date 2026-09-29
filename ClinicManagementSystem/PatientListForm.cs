using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class PatientListForm : Form
    {
        private readonly PatientService patientService = new PatientService();
        public PatientListForm()
        {
            InitializeComponent();
        }
        private void LoadPatients()
        {
            var patients = patientService.GetAll();
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                patients = patients.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            dgvPatients.Rows.Clear();

            foreach (var patient in patients)
            {
                dgvPatients.Rows.Add(patient.Id, patient.Name, patient.Phone, patient.Age, patient.Gender, "Edit", "Delete");
            }
        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new PatientAddEditForm();
            addForm.ShowDialog();
            LoadPatients();
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int patientId = Convert.ToInt32(dgvPatients.Rows[e.RowIndex].Cells["colId"].Value);

            if (dgvPatients.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var editForm = new PatientAddEditForm(patientId);
                editForm.ShowDialog();
                LoadPatients();
            }
            else if (dgvPatients.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    patientService.Delete(patientId);
                    LoadPatients();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadPatients();
        }
    }
}

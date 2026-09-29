using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class DoctorListForm : Form
    {
        private readonly DoctorService doctorService = new DoctorService();
        public DoctorListForm()
        {
            InitializeComponent();
        }
        private void LoadDoctors()
        {
            var doctors = doctorService.GetAll();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                doctors = doctors.Where(d => d.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            dgvDoctors.Rows.Clear();

            foreach (var doctor in doctors)
            {
                dgvDoctors.Rows.Add(doctor.Id, doctor.Name, doctor.Specialty, doctor.Phone, "Edit", "Delete");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new DoctorAddEditForm();
            addForm.ShowDialog();
            LoadDoctors();
        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int doctorId = Convert.ToInt32(dgvDoctors.Rows[e.RowIndex].Cells["colId"].Value);

            if (dgvDoctors.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var editForm = new DoctorAddEditForm(doctorId);
                editForm.ShowDialog();
                LoadDoctors();
            }
            else if (dgvDoctors.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    doctorService.Delete(doctorId);
                    LoadDoctors();
                }
            }
        }

        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDoctors();
        }
    }
}

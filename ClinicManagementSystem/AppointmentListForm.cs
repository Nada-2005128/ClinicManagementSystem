using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class AppointmentListForm : Form
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        public AppointmentListForm()
        {
            InitializeComponent();
        }
        private void LoadAppointments()
        {
            var appointments = appointmentService.GetAll();

            dgvAppointments.Rows.Clear();

            foreach (var appointment in appointments)
            {
                dgvAppointments.Rows.Add(appointment.Id, appointment.Doctor.Name, appointment.Patient.Name, appointment.Date, "Edit", "Delete");
            }
        }

        private void AppointmentListForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AppointmentAddEditForm();
            addForm.ShowDialog();
            LoadAppointments();
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int appointmentId = Convert.ToInt32(dgvAppointments.Rows[e.RowIndex].Cells["colId"].Value);

            if (dgvAppointments.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var editForm = new AppointmentAddEditForm(appointmentId);
                editForm.ShowDialog();
                LoadAppointments();
            }
            else if (dgvAppointments.Columns[e.ColumnIndex].Name == "colDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    appointmentService.Delete(appointmentId);
                    LoadAppointments();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class AppointmentAddEditForm : Form
    {
        private readonly AppointmentService appointmentService = new AppointmentService();
        private readonly DoctorService doctorService = new DoctorService();
        private readonly PatientService patientService = new PatientService();
        private readonly int? appointmentId;
        public AppointmentAddEditForm()
        {
            InitializeComponent();
        }
        public AppointmentAddEditForm(int id)
        {
            InitializeComponent();
            appointmentId = id;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AppointmentAddEditForm_Load(object sender, EventArgs e)
        {
            cmbDoctor.DataSource = doctorService.GetAll();
            cmbDoctor.DisplayMember = "Name";
            cmbDoctor.ValueMember = "Id";

            cmbPatient.DataSource = patientService.GetAll();
            cmbPatient.DisplayMember = "Name";
            cmbPatient.ValueMember = "Id";

            if (appointmentId.HasValue)
            {
                this.Text = "Edit Appointments Form";
                var appointment = appointmentService.GetById(appointmentId.Value);

                if (appointment != null)
                {
                    cmbDoctor.SelectedValue = appointment.DoctorId;
                    cmbPatient.SelectedValue = appointment.PatientId;
                    dtpDate.Value = appointment.Date;
                }
            }
            else
            {
                this.Text = "Add Appointments Form";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDoctor.SelectedValue == null || cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a doctor and a patient");
                return;
            }
            if (dtpDate.Value < DateTime.Now)
            {
                MessageBox.Show("Appointment date is wrong! ");
                return;
            }

            int doctorId = Convert.ToInt32(cmbDoctor.SelectedValue);
            int patientId = Convert.ToInt32(cmbPatient.SelectedValue);
            DateTime date = dtpDate.Value;

            if (appointmentId.HasValue)
            {
                appointmentService.Update(appointmentId.Value, date, doctorId, patientId);
            }
            else
            {
                appointmentService.Add(date, doctorId, patientId);
            }

            MessageBox.Show("Saved successfully!");
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

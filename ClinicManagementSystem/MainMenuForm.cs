using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class MainMenuForm : Form
    {
        private readonly DoctorService doctorService = new DoctorService();
        private readonly PatientService patientService = new PatientService();
        private readonly AppointmentService appointmentService = new AppointmentService();
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            var doctorListForm = new DoctorListForm();
            doctorListForm.ShowDialog();
            RefreshDashboard();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            var patientListForm = new PatientListForm();
            patientListForm.ShowDialog();
            RefreshDashboard();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            var appointmentListForm = new AppointmentListForm();
            appointmentListForm.ShowDialog();
            RefreshDashboard();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            lblDate.Text = "Today: " + DateTime.Now.ToString("dddd, dd MMMM yyyy");
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            lblTotalDoctors.Text = "Total Doctors: " + doctorService.GetAll().Count;
            lblTotalPatients.Text = "Total Patients: " + patientService.GetAll().Count;

            var todayCount = appointmentService.GetAll().Count(a => a.Date.Date == DateTime.Today);
            lblTodayAppointments.Text = "Today's Appointments: " + todayCount;
        }
    }
}

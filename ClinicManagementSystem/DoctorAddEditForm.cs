using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class DoctorAddEditForm : Form
    {
        private readonly DoctorService doctorService = new DoctorService();
        private readonly int? doctorId;

        public DoctorAddEditForm()
        {
            InitializeComponent();
        }

        public DoctorAddEditForm(int id)
        {
            InitializeComponent();
            doctorId = id;
        }

        private void DoctorAddEditForm_Load(object sender, EventArgs e)
        {
            if (doctorId.HasValue)
            {
                this.Text = "Edit Doctors Form";

                var doctor = doctorService.GetById(doctorId.Value);
                if (doctor != null)
                {
                    txtName.Text = doctor.Name;
                    cmbSpecialty.Text = doctor.Specialty;
                    txtPhone.Text = doctor.Phone;
                }
            }
            else
            {
                this.Text = "Add Doctors Form";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbSpecialty.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please write your data ");
                return;
            }
            if (doctorId.HasValue)
            {
                doctorService.Update(doctorId.Value, txtName.Text, cmbSpecialty.Text, txtPhone.Text);
            }
            else
            {
                doctorService.Add(txtName.Text, cmbSpecialty.Text, txtPhone.Text);
            }
            MessageBox.Show("Saved successfully!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void cmbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

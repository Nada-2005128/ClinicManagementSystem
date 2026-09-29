using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class PatientAddEditForm : Form
    {
        private readonly PatientService patientService = new PatientService();
        private readonly int? patientId;
        public PatientAddEditForm()
        {
            InitializeComponent();
        }
        public PatientAddEditForm(int id)
        {
            InitializeComponent();
            patientId = id;
        }

        private void PatientAddEditForm_Load(object sender, EventArgs e)
        {
            if (patientId.HasValue)
            {
                this.Text = "Edit Patients Form";
                var patient = patientService.GetById(patientId.Value);

                if (patient != null)
                {
                    txtName.Text = patient.Name;
                    txtPhone.Text = patient.Phone;
                    txtAge.Text = patient.Age.ToString();
                    cmbGender.Text = patient.Gender;
                    txtAddress.Text = patient.Address;
                }
            }
            else
            {
                this.Text = "Add Patients Form";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(cmbGender.Text))
            {
                MessageBox.Show("Please write all the data");
                return;
            }

            int age = Convert.ToInt32(txtAge.Text);

            if (patientId.HasValue)
            {
                patientService.Update(patientId.Value, txtName.Text, txtPhone.Text, txtAddress.Text, age, cmbGender.Text);
            }
            else
            {
                patientService.Add(txtName.Text, txtPhone.Text, txtAddress.Text, age, cmbGender.Text);
            }

            MessageBox.Show("Saved successfully!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}

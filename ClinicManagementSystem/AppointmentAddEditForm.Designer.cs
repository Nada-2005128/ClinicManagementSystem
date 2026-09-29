namespace ClinicManagementSystem
{
    partial class AppointmentAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbDoctor = new ComboBox();
            cmbPatient = new ComboBox();
            dtpDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 26);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Doctor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 61);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Patient";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 101);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 2;
            label3.Text = "Date";
            label3.Click += label3_Click;
            // 
            // cmbDoctor
            // 
            cmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new Point(88, 26);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new Size(250, 28);
            cmbDoctor.TabIndex = 3;
            // 
            // cmbPatient
            // 
            cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(88, 61);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(250, 28);
            cmbPatient.TabIndex = 4;
            // 
            // dtpDate
            // 
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(88, 101);
            dtpDate.Name = "dtpDate";
            dtpDate.ShowUpDown = true;
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 5;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(276, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(16, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AppointmentAddEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 253);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpDate);
            Controls.Add(cmbPatient);
            Controls.Add(cmbDoctor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AppointmentAddEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add / Edit Appointment";
            Load += AppointmentAddEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbDoctor;
        private ComboBox cmbPatient;
        private DateTimePicker dtpDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
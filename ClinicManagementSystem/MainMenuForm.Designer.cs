namespace ClinicManagementSystem
{
    partial class MainMenuForm
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
            btnDoctors = new Button();
            btnPatients = new Button();
            btnAppointments = new Button();
            textBox1 = new TextBox();
            lblDate = new Label();
            lblTotalDoctors = new Label();
            lblTotalPatients = new Label();
            lblTodayAppointments = new Label();
            SuspendLayout();
            // 
            // btnDoctors
            // 
            btnDoctors.BackColor = SystemColors.ButtonHighlight;
            btnDoctors.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDoctors.Location = new Point(12, 174);
            btnDoctors.Name = "btnDoctors";
            btnDoctors.Size = new Size(180, 160);
            btnDoctors.TabIndex = 0;
            btnDoctors.Text = "Doctors";
            btnDoctors.UseVisualStyleBackColor = true;
            btnDoctors.Click += btnDoctors_Click;
            // 
            // btnPatients
            // 
            btnPatients.BackColor = SystemColors.ButtonHighlight;
            btnPatients.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPatients.Location = new Point(206, 174);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(180, 160);
            btnPatients.TabIndex = 1;
            btnPatients.Text = "Patients";
            btnPatients.UseVisualStyleBackColor = true;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Font = new Font("Cooper Black", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAppointments.Location = new Point(401, 174);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(250, 160);
            btnAppointments.TabIndex = 2;
            btnAppointments.Text = "Appointments";
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Cooper Black", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(55, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(550, 46);
            textBox1.TabIndex = 3;
            textBox1.Text = "Clinic management system";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(222, 105);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(41, 20);
            lblDate.TabIndex = 4;
            lblDate.Text = "Date";
            // 
            // lblTotalDoctors
            // 
            lblTotalDoctors.AutoSize = true;
            lblTotalDoctors.Location = new Point(41, 348);
            lblTotalDoctors.Name = "lblTotalDoctors";
            lblTotalDoctors.Size = new Size(94, 20);
            lblTotalDoctors.TabIndex = 5;
            lblTotalDoctors.Text = "TotalDoctors";
            // 
            // lblTotalPatients
            // 
            lblTotalPatients.AutoSize = true;
            lblTotalPatients.Location = new Point(243, 348);
            lblTotalPatients.Name = "lblTotalPatients";
            lblTotalPatients.Size = new Size(93, 20);
            lblTotalPatients.TabIndex = 6;
            lblTotalPatients.Text = "TotalPatients";
            lblTotalPatients.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTodayAppointments
            // 
            lblTodayAppointments.AutoSize = true;
            lblTodayAppointments.Location = new Point(436, 348);
            lblTodayAppointments.Name = "lblTodayAppointments";
            lblTodayAppointments.Size = new Size(143, 20);
            lblTodayAppointments.TabIndex = 7;
            lblTodayAppointments.Text = "TodayAppointments";
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(663, 453);
            Controls.Add(lblTodayAppointments);
            Controls.Add(lblTotalPatients);
            Controls.Add(lblTotalDoctors);
            Controls.Add(lblDate);
            Controls.Add(textBox1);
            Controls.Add(btnAppointments);
            Controls.Add(btnPatients);
            Controls.Add(btnDoctors);
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clinic Management System";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDoctors;
        private Button btnPatients;
        private Button btnAppointments;
        private TextBox textBox1;
        private Label lblDate;
        private Label lblTotalDoctors;
        private Label lblTotalPatients;
        private Label lblTodayAppointments;
    }
}
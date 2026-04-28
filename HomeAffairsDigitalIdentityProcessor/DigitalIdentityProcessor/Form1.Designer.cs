namespace DigitalIdentityProcessor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxLogo = new PictureBox();
            lblTitle = new Label();
            lblName = new Label();
            lblId = new Label();
            lblCitizenship = new Label();
            txtFullName = new TextBox();
            txtIdNumber = new TextBox();
            cmbCitizenship = new ComboBox();
            btnValidateId = new Button();
            lblValidationResult = new Label();
            txtSummary = new TextBox();
            btnGenerateProfile = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(12, 90);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(300, 500);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Green;
            lblTitle.Location = new Point(351, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(509, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Home Affairs Digital Identity Processor";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.Location = new Point(350, 100);
            lblName.Name = "lblName";
            lblName.Size = new Size(140, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Enter your Name:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblId.Location = new Point(367, 150);
            lblId.Name = "lblId";
            lblId.Size = new Size(123, 23);
            lblId.TabIndex = 3;
            lblId.Text = "Enter your ID:";
            // 
            // lblCitizenship
            // 
            lblCitizenship.AutoSize = true;
            lblCitizenship.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCitizenship.Location = new Point(325, 202);
            lblCitizenship.Name = "lblCitizenship";
            lblCitizenship.Size = new Size(165, 23);
            lblCitizenship.TabIndex = 4;
            lblCitizenship.Text = "Choose your Citizen:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(517, 98);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(302, 27);
            txtFullName.TabIndex = 5;
            // 
            // txtIdNumber
            // 
            txtIdNumber.Location = new Point(517, 148);
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(302, 27);
            txtIdNumber.TabIndex = 6;
            // 
            // cmbCitizenship
            // 
            cmbCitizenship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCitizenship.FormattingEnabled = true;
            cmbCitizenship.Location = new Point(517, 200);
            cmbCitizenship.Name = "cmbCitizenship";
            cmbCitizenship.Size = new Size(302, 28);
            cmbCitizenship.TabIndex = 7;
            // 
            // btnValidateId
            // 
            btnValidateId.BackColor = Color.LimeGreen;
            btnValidateId.FlatStyle = FlatStyle.Popup;
            btnValidateId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnValidateId.Location = new Point(595, 255);
            btnValidateId.Name = "btnValidateId";
            btnValidateId.Size = new Size(162, 40);
            btnValidateId.TabIndex = 8;
            btnValidateId.Text = "Validate ID";
            btnValidateId.UseVisualStyleBackColor = false;
            btnValidateId.Click += btnValidateId_Click;
            // 
            // lblValidationResult
            // 
            lblValidationResult.AutoSize = true;
            lblValidationResult.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblValidationResult.Location = new Point(517, 314);
            lblValidationResult.Name = "lblValidationResult";
            lblValidationResult.Size = new Size(157, 23);
            lblValidationResult.TabIndex = 9;
            lblValidationResult.Text = "Validation pending...";
            // 
            // txtSummary
            // 
            txtSummary.Location = new Point(517, 353);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ReadOnly = true;
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(393, 175);
            txtSummary.TabIndex = 10;
            // 
            // btnGenerateProfile
            // 
            btnGenerateProfile.BackColor = Color.LimeGreen;
            btnGenerateProfile.FlatStyle = FlatStyle.Popup;
            btnGenerateProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateProfile.Location = new Point(595, 546);
            btnGenerateProfile.Name = "btnGenerateProfile";
            btnGenerateProfile.Size = new Size(162, 40);
            btnGenerateProfile.TabIndex = 11;
            btnGenerateProfile.Text = "Generate Profile";
            btnGenerateProfile.UseVisualStyleBackColor = false;
            btnGenerateProfile.Click += btnGenerateProfile_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 161, 124);
            ClientSize = new Size(940, 620);
            Controls.Add(pictureBoxLogo);
            Controls.Add(btnGenerateProfile);
            Controls.Add(txtSummary);
            Controls.Add(lblValidationResult);
            Controls.Add(btnValidateId);
            Controls.Add(cmbCitizenship);
            Controls.Add(txtIdNumber);
            Controls.Add(txtFullName);
            Controls.Add(lblCitizenship);
            Controls.Add(lblId);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Affairs Digital Identity Processor";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private Label lblTitle;
        private Label lblName;
        private Label lblId;
        private Label lblCitizenship;
        private TextBox txtFullName;
        private TextBox txtIdNumber;
        private ComboBox cmbCitizenship;
        private Button btnValidateId;
        private Label lblValidationResult;
        private TextBox txtSummary;
        private Button btnGenerateProfile;
    }
}

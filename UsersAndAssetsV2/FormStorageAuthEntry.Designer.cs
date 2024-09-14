namespace UsersAndAssetsV2
{
    partial class FormStorageAuthEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStorageAuthEntry));
            this.lblBadgeNumber = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblCompletedBy = new System.Windows.Forms.Label();
            this.lblCompletedDate = new System.Windows.Forms.Label();
            this.lblSignedDate = new System.Windows.Forms.Label();
            this.lblInitial = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtBadgeNumber = new System.Windows.Forms.TextBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtInitial = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dteSignedDate = new System.Windows.Forms.DateTimePicker();
            this.dteCompletedDate = new System.Windows.Forms.DateTimePicker();
            this.cboCompletedBy = new System.Windows.Forms.ComboBox();
            this.lblCharacters = new System.Windows.Forms.Label();
            this.chkCompletedDate = new System.Windows.Forms.CheckBox();
            this.chkUSB = new System.Windows.Forms.CheckBox();
            this.chkDVD = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblBadgeNumber
            // 
            this.lblBadgeNumber.AutoSize = true;
            this.lblBadgeNumber.Location = new System.Drawing.Point(12, 9);
            this.lblBadgeNumber.Name = "lblBadgeNumber";
            this.lblBadgeNumber.Size = new System.Drawing.Size(81, 13);
            this.lblBadgeNumber.TabIndex = 0;
            this.lblBadgeNumber.Text = "Badge Number:";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(12, 239);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(47, 13);
            this.lblReason.TabIndex = 1;
            this.lblReason.Text = "Reason:";
            // 
            // lblCompletedBy
            // 
            this.lblCompletedBy.AutoSize = true;
            this.lblCompletedBy.Location = new System.Drawing.Point(12, 183);
            this.lblCompletedBy.Name = "lblCompletedBy";
            this.lblCompletedBy.Size = new System.Drawing.Size(75, 13);
            this.lblCompletedBy.TabIndex = 2;
            this.lblCompletedBy.Text = "Completed By:";
            // 
            // lblCompletedDate
            // 
            this.lblCompletedDate.AutoSize = true;
            this.lblCompletedDate.Location = new System.Drawing.Point(12, 154);
            this.lblCompletedDate.Name = "lblCompletedDate";
            this.lblCompletedDate.Size = new System.Drawing.Size(86, 13);
            this.lblCompletedDate.TabIndex = 10;
            this.lblCompletedDate.Text = "Completed Date:";
            // 
            // lblSignedDate
            // 
            this.lblSignedDate.AutoSize = true;
            this.lblSignedDate.Location = new System.Drawing.Point(12, 125);
            this.lblSignedDate.Name = "lblSignedDate";
            this.lblSignedDate.Size = new System.Drawing.Size(69, 13);
            this.lblSignedDate.TabIndex = 8;
            this.lblSignedDate.Text = "Signed Date:";
            // 
            // lblInitial
            // 
            this.lblInitial.AutoSize = true;
            this.lblInitial.Location = new System.Drawing.Point(12, 67);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(34, 13);
            this.lblInitial.TabIndex = 4;
            this.lblInitial.Text = "Initial:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 96);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 38);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtBadgeNumber
            // 
            this.txtBadgeNumber.Location = new System.Drawing.Point(108, 6);
            this.txtBadgeNumber.Name = "txtBadgeNumber";
            this.txtBadgeNumber.Size = new System.Drawing.Size(57, 20);
            this.txtBadgeNumber.TabIndex = 1;
            this.txtBadgeNumber.TabStop = false;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(12, 255);
            this.txtReason.MaxLength = 200;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(234, 97);
            this.txtReason.TabIndex = 16;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(108, 93);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(138, 20);
            this.txtLastName.TabIndex = 7;
            this.txtLastName.TabStop = false;
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(108, 64);
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(31, 20);
            this.txtInitial.TabIndex = 5;
            this.txtInitial.TabStop = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(138, 20);
            this.txtFirstName.TabIndex = 3;
            this.txtFirstName.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(90, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(171, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dteSignedDate
            // 
            this.dteSignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteSignedDate.Location = new System.Drawing.Point(108, 122);
            this.dteSignedDate.Name = "dteSignedDate";
            this.dteSignedDate.Size = new System.Drawing.Size(103, 20);
            this.dteSignedDate.TabIndex = 9;
            // 
            // dteCompletedDate
            // 
            this.dteCompletedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteCompletedDate.Location = new System.Drawing.Point(108, 151);
            this.dteCompletedDate.Name = "dteCompletedDate";
            this.dteCompletedDate.Size = new System.Drawing.Size(103, 20);
            this.dteCompletedDate.TabIndex = 12;
            // 
            // cboCompletedBy
            // 
            this.cboCompletedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCompletedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompletedBy.FormattingEnabled = true;
            this.cboCompletedBy.Location = new System.Drawing.Point(108, 180);
            this.cboCompletedBy.Name = "cboCompletedBy";
            this.cboCompletedBy.Size = new System.Drawing.Size(138, 21);
            this.cboCompletedBy.TabIndex = 13;
            // 
            // lblCharacters
            // 
            this.lblCharacters.Location = new System.Drawing.Point(211, 239);
            this.lblCharacters.Name = "lblCharacters";
            this.lblCharacters.Size = new System.Drawing.Size(35, 13);
            this.lblCharacters.TabIndex = 19;
            this.lblCharacters.Text = "200";
            this.lblCharacters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCompletedDate
            // 
            this.chkCompletedDate.AutoSize = true;
            this.chkCompletedDate.Location = new System.Drawing.Point(217, 154);
            this.chkCompletedDate.Name = "chkCompletedDate";
            this.chkCompletedDate.Size = new System.Drawing.Size(22, 21);
            this.chkCompletedDate.TabIndex = 11;
            this.chkCompletedDate.UseVisualStyleBackColor = true;
            this.chkCompletedDate.CheckedChanged += new System.EventHandler(this.chkCompletedDate_CheckedChanged);
            // 
            // chkUSB
            // 
            this.chkUSB.AutoSize = true;
            this.chkUSB.Location = new System.Drawing.Point(55, 213);
            this.chkUSB.Name = "chkUSB";
            this.chkUSB.Size = new System.Drawing.Size(55, 21);
            this.chkUSB.TabIndex = 14;
            this.chkUSB.Text = "USB";
            this.chkUSB.UseVisualStyleBackColor = true;
            // 
            // chkDVD
            // 
            this.chkDVD.AutoSize = true;
            this.chkDVD.Location = new System.Drawing.Point(135, 213);
            this.chkDVD.Name = "chkDVD";
            this.chkDVD.Size = new System.Drawing.Size(76, 21);
            this.chkDVD.TabIndex = 15;
            this.chkDVD.Text = "CD/DVD";
            this.chkDVD.UseVisualStyleBackColor = true;
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 401);
            this.Controls.Add(this.chkDVD);
            this.Controls.Add(this.chkUSB);
            this.Controls.Add(this.chkCompletedDate);
            this.Controls.Add(this.lblCharacters);
            this.Controls.Add(this.cboCompletedBy);
            this.Controls.Add(this.dteCompletedDate);
            this.Controls.Add(this.dteSignedDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.txtBadgeNumber);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.lblSignedDate);
            this.Controls.Add(this.lblCompletedDate);
            this.Controls.Add(this.lblCompletedBy);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblBadgeNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryForm";
            this.Text = "Record Entry";
            this.Load += new System.EventHandler(this.FormStorageAuthEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBadgeNumber;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblCompletedBy;
        private System.Windows.Forms.Label lblCompletedDate;
        private System.Windows.Forms.Label lblSignedDate;
        private System.Windows.Forms.Label lblInitial;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtBadgeNumber;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtInitial;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dteSignedDate;
        private System.Windows.Forms.DateTimePicker dteCompletedDate;
        private System.Windows.Forms.ComboBox cboCompletedBy;
        private System.Windows.Forms.Label lblCharacters;
        private System.Windows.Forms.CheckBox chkCompletedDate;
        private System.Windows.Forms.CheckBox chkUSB;
        private System.Windows.Forms.CheckBox chkDVD;
    }
}
namespace UsersAndAssetsV2
{
    partial class FormReports
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
            this.grpAssets = new System.Windows.Forms.GroupBox();
            this.btnAssetsRun = new System.Windows.Forms.Button();
            this.cboAssetsByStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboAssetsByType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpEmployeesActive = new System.Windows.Forms.GroupBox();
            this.grpEmployeeStatus = new System.Windows.Forms.GroupBox();
            this.rdoEmployeeAll = new System.Windows.Forms.RadioButton();
            this.rdoEmployeeInactive = new System.Windows.Forms.RadioButton();
            this.rdoEmployeeActive = new System.Windows.Forms.RadioButton();
            this.btnActiveEmpEmail = new System.Windows.Forms.Button();
            this.btnActiveEmpPatron = new System.Windows.Forms.Button();
            this.btnActiveEmpMachAcct = new System.Windows.Forms.Button();
            this.btnActiveEmpEzpay = new System.Windows.Forms.Button();
            this.btnActiveEmpPermissions = new System.Windows.Forms.Button();
            this.btnActiveEmpDatabase = new System.Windows.Forms.Button();
            this.btnActiveEmpAD = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStorageAuthorizations = new System.Windows.Forms.Button();
            this.grpAssets.SuspendLayout();
            this.grpEmployeesActive.SuspendLayout();
            this.grpEmployeeStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAssets
            // 
            this.grpAssets.Controls.Add(this.btnAssetsRun);
            this.grpAssets.Controls.Add(this.cboAssetsByStatus);
            this.grpAssets.Controls.Add(this.lblStatus);
            this.grpAssets.Controls.Add(this.cboAssetsByType);
            this.grpAssets.Controls.Add(this.label1);
            this.grpAssets.Location = new System.Drawing.Point(313, 9);
            this.grpAssets.Name = "grpAssets";
            this.grpAssets.Size = new System.Drawing.Size(203, 103);
            this.grpAssets.TabIndex = 6;
            this.grpAssets.TabStop = false;
            this.grpAssets.Text = "Assets";
            // 
            // btnAssetsRun
            // 
            this.btnAssetsRun.Location = new System.Drawing.Point(113, 70);
            this.btnAssetsRun.Name = "btnAssetsRun";
            this.btnAssetsRun.Size = new System.Drawing.Size(75, 23);
            this.btnAssetsRun.TabIndex = 11;
            this.btnAssetsRun.Text = "Run";
            this.btnAssetsRun.UseVisualStyleBackColor = true;
            this.btnAssetsRun.Click += new System.EventHandler(this.btnAssetsRun_Click);
            // 
            // cboAssetsByStatus
            // 
            this.cboAssetsByStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetsByStatus.FormattingEnabled = true;
            this.cboAssetsByStatus.Location = new System.Drawing.Point(67, 16);
            this.cboAssetsByStatus.Name = "cboAssetsByStatus";
            this.cboAssetsByStatus.Size = new System.Drawing.Size(121, 21);
            this.cboAssetsByStatus.TabIndex = 10;
            this.cboAssetsByStatus.DropDown += new System.EventHandler(this.cboAssetsByStatus_DropDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "By Status:";
            // 
            // cboAssetsByType
            // 
            this.cboAssetsByType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetsByType.FormattingEnabled = true;
            this.cboAssetsByType.Location = new System.Drawing.Point(67, 43);
            this.cboAssetsByType.Name = "cboAssetsByType";
            this.cboAssetsByType.Size = new System.Drawing.Size(121, 21);
            this.cboAssetsByType.TabIndex = 8;
            this.cboAssetsByType.DropDown += new System.EventHandler(this.cboAssetsByType_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "By Type:";
            // 
            // grpEmployeesActive
            // 
            this.grpEmployeesActive.Controls.Add(this.grpEmployeeStatus);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpEmail);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpPatron);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpMachAcct);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpEzpay);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpPermissions);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpDatabase);
            this.grpEmployeesActive.Controls.Add(this.btnActiveEmpAD);
            this.grpEmployeesActive.Location = new System.Drawing.Point(9, 9);
            this.grpEmployeesActive.Name = "grpEmployeesActive";
            this.grpEmployeesActive.Size = new System.Drawing.Size(274, 251);
            this.grpEmployeesActive.TabIndex = 7;
            this.grpEmployeesActive.TabStop = false;
            this.grpEmployeesActive.Text = "Employees";
            // 
            // grpEmployeeStatus
            // 
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeAll);
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeInactive);
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeActive);
            this.grpEmployeeStatus.Location = new System.Drawing.Point(17, 16);
            this.grpEmployeeStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEmployeeStatus.Name = "grpEmployeeStatus";
            this.grpEmployeeStatus.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpEmployeeStatus.Size = new System.Drawing.Size(237, 39);
            this.grpEmployeeStatus.TabIndex = 7;
            this.grpEmployeeStatus.TabStop = false;
            // 
            // rdoEmployeeAll
            // 
            this.rdoEmployeeAll.AutoSize = true;
            this.rdoEmployeeAll.Location = new System.Drawing.Point(189, 13);
            this.rdoEmployeeAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoEmployeeAll.Name = "rdoEmployeeAll";
            this.rdoEmployeeAll.Size = new System.Drawing.Size(43, 20);
            this.rdoEmployeeAll.TabIndex = 15;
            this.rdoEmployeeAll.TabStop = true;
            this.rdoEmployeeAll.Text = "All";
            this.rdoEmployeeAll.UseVisualStyleBackColor = true;
            // 
            // rdoEmployeeInactive
            // 
            this.rdoEmployeeInactive.AutoSize = true;
            this.rdoEmployeeInactive.Location = new System.Drawing.Point(92, 13);
            this.rdoEmployeeInactive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoEmployeeInactive.Name = "rdoEmployeeInactive";
            this.rdoEmployeeInactive.Size = new System.Drawing.Size(70, 20);
            this.rdoEmployeeInactive.TabIndex = 14;
            this.rdoEmployeeInactive.TabStop = true;
            this.rdoEmployeeInactive.Text = "Inactive";
            this.rdoEmployeeInactive.UseVisualStyleBackColor = true;
            // 
            // rdoEmployeeActive
            // 
            this.rdoEmployeeActive.AutoSize = true;
            this.rdoEmployeeActive.Location = new System.Drawing.Point(4, 13);
            this.rdoEmployeeActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoEmployeeActive.Name = "rdoEmployeeActive";
            this.rdoEmployeeActive.Size = new System.Drawing.Size(62, 20);
            this.rdoEmployeeActive.TabIndex = 13;
            this.rdoEmployeeActive.TabStop = true;
            this.rdoEmployeeActive.Text = "Active";
            this.rdoEmployeeActive.UseVisualStyleBackColor = true;
            // 
            // btnActiveEmpEmail
            // 
            this.btnActiveEmpEmail.Location = new System.Drawing.Point(17, 162);
            this.btnActiveEmpEmail.Name = "btnActiveEmpEmail";
            this.btnActiveEmpEmail.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpEmail.TabIndex = 6;
            this.btnActiveEmpEmail.Text = "Email Accounts";
            this.btnActiveEmpEmail.UseVisualStyleBackColor = true;
            this.btnActiveEmpEmail.Click += new System.EventHandler(this.btnEmpEmail_Click);
            // 
            // btnActiveEmpPatron
            // 
            this.btnActiveEmpPatron.Location = new System.Drawing.Point(142, 113);
            this.btnActiveEmpPatron.Name = "btnActiveEmpPatron";
            this.btnActiveEmpPatron.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpPatron.TabIndex = 5;
            this.btnActiveEmpPatron.Text = "Patron Mgmt";
            this.btnActiveEmpPatron.UseVisualStyleBackColor = true;
            this.btnActiveEmpPatron.Click += new System.EventHandler(this.btnEmpPatron_Click);
            // 
            // btnActiveEmpMachAcct
            // 
            this.btnActiveEmpMachAcct.Location = new System.Drawing.Point(142, 64);
            this.btnActiveEmpMachAcct.Name = "btnActiveEmpMachAcct";
            this.btnActiveEmpMachAcct.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpMachAcct.TabIndex = 4;
            this.btnActiveEmpMachAcct.Text = "Machine Acct";
            this.btnActiveEmpMachAcct.UseVisualStyleBackColor = true;
            this.btnActiveEmpMachAcct.Click += new System.EventHandler(this.btnEmpMachAcct_Click);
            // 
            // btnActiveEmpEzpay
            // 
            this.btnActiveEmpEzpay.Location = new System.Drawing.Point(17, 211);
            this.btnActiveEmpEzpay.Name = "btnActiveEmpEzpay";
            this.btnActiveEmpEzpay.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpEzpay.TabIndex = 3;
            this.btnActiveEmpEzpay.Text = "EZPay";
            this.btnActiveEmpEzpay.UseVisualStyleBackColor = true;
            this.btnActiveEmpEzpay.Click += new System.EventHandler(this.btnEmpEzpay_Click);
            // 
            // btnActiveEmpPermissions
            // 
            this.btnActiveEmpPermissions.Location = new System.Drawing.Point(142, 162);
            this.btnActiveEmpPermissions.Name = "btnActiveEmpPermissions";
            this.btnActiveEmpPermissions.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpPermissions.TabIndex = 2;
            this.btnActiveEmpPermissions.Text = "Permissions";
            this.btnActiveEmpPermissions.UseVisualStyleBackColor = true;
            this.btnActiveEmpPermissions.Click += new System.EventHandler(this.btnEmpPermissions_Click);
            // 
            // btnActiveEmpDatabase
            // 
            this.btnActiveEmpDatabase.Location = new System.Drawing.Point(17, 113);
            this.btnActiveEmpDatabase.Name = "btnActiveEmpDatabase";
            this.btnActiveEmpDatabase.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpDatabase.TabIndex = 1;
            this.btnActiveEmpDatabase.Text = "Database";
            this.btnActiveEmpDatabase.UseVisualStyleBackColor = true;
            this.btnActiveEmpDatabase.Click += new System.EventHandler(this.btnEmpDatabase_Click);
            // 
            // btnActiveEmpAD
            // 
            this.btnActiveEmpAD.Location = new System.Drawing.Point(17, 64);
            this.btnActiveEmpAD.Name = "btnActiveEmpAD";
            this.btnActiveEmpAD.Size = new System.Drawing.Size(112, 34);
            this.btnActiveEmpAD.TabIndex = 0;
            this.btnActiveEmpAD.Text = "Active Directory";
            this.btnActiveEmpAD.UseVisualStyleBackColor = true;
            this.btnActiveEmpAD.Click += new System.EventHandler(this.btnEmpAD_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(404, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 34);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStorageAuthorizations
            // 
            this.btnStorageAuthorizations.Location = new System.Drawing.Point(404, 144);
            this.btnStorageAuthorizations.Name = "btnStorageAuthorizations";
            this.btnStorageAuthorizations.Size = new System.Drawing.Size(112, 34);
            this.btnStorageAuthorizations.TabIndex = 12;
            this.btnStorageAuthorizations.Text = "Storage Authorizations";
            this.btnStorageAuthorizations.UseVisualStyleBackColor = true;
            this.btnStorageAuthorizations.Click += new System.EventHandler(this.btnStorageAuthorizations_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 269);
            this.Controls.Add(this.btnStorageAuthorizations);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpEmployeesActive);
            this.Controls.Add(this.grpAssets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Users and Assets - Reports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.grpAssets.ResumeLayout(false);
            this.grpAssets.PerformLayout();
            this.grpEmployeesActive.ResumeLayout(false);
            this.grpEmployeeStatus.ResumeLayout(false);
            this.grpEmployeeStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAssets;
        private System.Windows.Forms.ComboBox cboAssetsByStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboAssetsByType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpEmployeesActive;
        private System.Windows.Forms.Button btnActiveEmpPermissions;
        private System.Windows.Forms.Button btnActiveEmpDatabase;
        private System.Windows.Forms.Button btnActiveEmpAD;
        private System.Windows.Forms.Button btnActiveEmpEzpay;
        private System.Windows.Forms.Button btnActiveEmpPatron;
        private System.Windows.Forms.Button btnActiveEmpMachAcct;
        private System.Windows.Forms.Button btnActiveEmpEmail;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAssetsRun;
        private System.Windows.Forms.GroupBox grpEmployeeStatus;
        private System.Windows.Forms.RadioButton rdoEmployeeAll;
        private System.Windows.Forms.RadioButton rdoEmployeeInactive;
        private System.Windows.Forms.RadioButton rdoEmployeeActive;
        private System.Windows.Forms.Button btnStorageAuthorizations;
    }
}


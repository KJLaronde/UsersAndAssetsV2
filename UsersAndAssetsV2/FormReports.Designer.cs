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
            this.grpOther = new System.Windows.Forms.GroupBox();
            this.btnWebFiltering = new System.Windows.Forms.Button();
            this.btnStorageAuthorizations = new System.Windows.Forms.Button();
            this.btnMonthlyReports = new System.Windows.Forms.Button();
            this.btnYubiKeys = new System.Windows.Forms.Button();
            this.grpAssets.SuspendLayout();
            this.grpEmployeesActive.SuspendLayout();
            this.grpEmployeeStatus.SuspendLayout();
            this.grpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAssets
            // 
            this.grpAssets.Controls.Add(this.btnAssetsRun);
            this.grpAssets.Controls.Add(this.cboAssetsByStatus);
            this.grpAssets.Controls.Add(this.lblStatus);
            this.grpAssets.Controls.Add(this.cboAssetsByType);
            this.grpAssets.Controls.Add(this.label1);
            this.grpAssets.Location = new System.Drawing.Point(434, 14);
            this.grpAssets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAssets.Name = "grpAssets";
            this.grpAssets.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAssets.Size = new System.Drawing.Size(394, 183);
            this.grpAssets.TabIndex = 6;
            this.grpAssets.TabStop = false;
            this.grpAssets.Text = "Assets";
            // 
            // btnAssetsRun
            // 
            this.btnAssetsRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssetsRun.Location = new System.Drawing.Point(273, 128);
            this.btnAssetsRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAssetsRun.Name = "btnAssetsRun";
            this.btnAssetsRun.Size = new System.Drawing.Size(112, 40);
            this.btnAssetsRun.TabIndex = 11;
            this.btnAssetsRun.Text = "Run";
            this.btnAssetsRun.UseVisualStyleBackColor = true;
            this.btnAssetsRun.Click += new System.EventHandler(this.btnAssetsRun_Click);
            // 
            // cboAssetsByStatus
            // 
            this.cboAssetsByStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetsByStatus.FormattingEnabled = true;
            this.cboAssetsByStatus.Location = new System.Drawing.Point(183, 29);
            this.cboAssetsByStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboAssetsByStatus.Name = "cboAssetsByStatus";
            this.cboAssetsByStatus.Size = new System.Drawing.Size(200, 28);
            this.cboAssetsByStatus.TabIndex = 10;
            this.cboAssetsByStatus.DropDown += new System.EventHandler(this.cboAssetsByStatus_DropDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(9, 31);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 25);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "By Status:";
            // 
            // cboAssetsByType
            // 
            this.cboAssetsByType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssetsByType.FormattingEnabled = true;
            this.cboAssetsByType.Location = new System.Drawing.Point(183, 77);
            this.cboAssetsByType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboAssetsByType.Name = "cboAssetsByType";
            this.cboAssetsByType.Size = new System.Drawing.Size(200, 28);
            this.cboAssetsByType.TabIndex = 8;
            this.cboAssetsByType.DropDown += new System.EventHandler(this.cboAssetsByType_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
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
            this.grpEmployeesActive.Location = new System.Drawing.Point(14, 14);
            this.grpEmployeesActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEmployeesActive.Name = "grpEmployeesActive";
            this.grpEmployeesActive.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpEmployeesActive.Size = new System.Drawing.Size(412, 503);
            this.grpEmployeesActive.TabIndex = 7;
            this.grpEmployeesActive.TabStop = false;
            this.grpEmployeesActive.Text = "Employees";
            // 
            // grpEmployeeStatus
            // 
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeAll);
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeInactive);
            this.grpEmployeeStatus.Controls.Add(this.rdoEmployeeActive);
            this.grpEmployeeStatus.Location = new System.Drawing.Point(8, 22);
            this.grpEmployeeStatus.Name = "grpEmployeeStatus";
            this.grpEmployeeStatus.Size = new System.Drawing.Size(388, 60);
            this.grpEmployeeStatus.TabIndex = 7;
            this.grpEmployeeStatus.TabStop = false;
            // 
            // rdoEmployeeAll
            // 
            this.rdoEmployeeAll.AutoSize = true;
            this.rdoEmployeeAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEmployeeAll.Location = new System.Drawing.Point(321, 20);
            this.rdoEmployeeAll.Name = "rdoEmployeeAll";
            this.rdoEmployeeAll.Size = new System.Drawing.Size(59, 29);
            this.rdoEmployeeAll.TabIndex = 15;
            this.rdoEmployeeAll.TabStop = true;
            this.rdoEmployeeAll.Text = "All";
            this.rdoEmployeeAll.UseVisualStyleBackColor = true;
            // 
            // rdoEmployeeInactive
            // 
            this.rdoEmployeeInactive.AutoSize = true;
            this.rdoEmployeeInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEmployeeInactive.Location = new System.Drawing.Point(162, 20);
            this.rdoEmployeeInactive.Name = "rdoEmployeeInactive";
            this.rdoEmployeeInactive.Size = new System.Drawing.Size(104, 29);
            this.rdoEmployeeInactive.TabIndex = 14;
            this.rdoEmployeeInactive.TabStop = true;
            this.rdoEmployeeInactive.Text = "Inactive";
            this.rdoEmployeeInactive.UseVisualStyleBackColor = true;
            // 
            // rdoEmployeeActive
            // 
            this.rdoEmployeeActive.AutoSize = true;
            this.rdoEmployeeActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoEmployeeActive.Location = new System.Drawing.Point(6, 20);
            this.rdoEmployeeActive.Name = "rdoEmployeeActive";
            this.rdoEmployeeActive.Size = new System.Drawing.Size(91, 29);
            this.rdoEmployeeActive.TabIndex = 13;
            this.rdoEmployeeActive.TabStop = true;
            this.rdoEmployeeActive.Text = "Active";
            this.rdoEmployeeActive.UseVisualStyleBackColor = true;
            // 
            // btnActiveEmpEmail
            // 
            this.btnActiveEmpEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpEmail.Location = new System.Drawing.Point(8, 293);
            this.btnActiveEmpEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpEmail.Name = "btnActiveEmpEmail";
            this.btnActiveEmpEmail.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpEmail.TabIndex = 6;
            this.btnActiveEmpEmail.Text = "Email \r\nAccounts";
            this.btnActiveEmpEmail.UseVisualStyleBackColor = true;
            this.btnActiveEmpEmail.Click += new System.EventHandler(this.btnEmpEmail_Click);
            // 
            // btnActiveEmpPatron
            // 
            this.btnActiveEmpPatron.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpPatron.Location = new System.Drawing.Point(207, 191);
            this.btnActiveEmpPatron.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpPatron.Name = "btnActiveEmpPatron";
            this.btnActiveEmpPatron.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpPatron.TabIndex = 5;
            this.btnActiveEmpPatron.Text = "Patron\r\nManagement";
            this.btnActiveEmpPatron.UseVisualStyleBackColor = true;
            this.btnActiveEmpPatron.Click += new System.EventHandler(this.btnEmpPatron_Click);
            // 
            // btnActiveEmpMachAcct
            // 
            this.btnActiveEmpMachAcct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpMachAcct.Location = new System.Drawing.Point(207, 89);
            this.btnActiveEmpMachAcct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpMachAcct.Name = "btnActiveEmpMachAcct";
            this.btnActiveEmpMachAcct.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpMachAcct.TabIndex = 4;
            this.btnActiveEmpMachAcct.Text = "Machine\r\nAccounting";
            this.btnActiveEmpMachAcct.UseVisualStyleBackColor = true;
            this.btnActiveEmpMachAcct.Click += new System.EventHandler(this.btnEmpMachAcct_Click);
            // 
            // btnActiveEmpEzpay
            // 
            this.btnActiveEmpEzpay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpEzpay.Location = new System.Drawing.Point(9, 395);
            this.btnActiveEmpEzpay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpEzpay.Name = "btnActiveEmpEzpay";
            this.btnActiveEmpEzpay.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpEzpay.TabIndex = 3;
            this.btnActiveEmpEzpay.Text = "EZPay";
            this.btnActiveEmpEzpay.UseVisualStyleBackColor = true;
            this.btnActiveEmpEzpay.Click += new System.EventHandler(this.btnEmpEzpay_Click);
            // 
            // btnActiveEmpPermissions
            // 
            this.btnActiveEmpPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpPermissions.Location = new System.Drawing.Point(207, 293);
            this.btnActiveEmpPermissions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpPermissions.Name = "btnActiveEmpPermissions";
            this.btnActiveEmpPermissions.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpPermissions.TabIndex = 2;
            this.btnActiveEmpPermissions.Text = "Permissions";
            this.btnActiveEmpPermissions.UseVisualStyleBackColor = true;
            this.btnActiveEmpPermissions.Click += new System.EventHandler(this.btnEmpPermissions_Click);
            // 
            // btnActiveEmpDatabase
            // 
            this.btnActiveEmpDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpDatabase.Location = new System.Drawing.Point(9, 191);
            this.btnActiveEmpDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpDatabase.Name = "btnActiveEmpDatabase";
            this.btnActiveEmpDatabase.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpDatabase.TabIndex = 1;
            this.btnActiveEmpDatabase.Text = "Database";
            this.btnActiveEmpDatabase.UseVisualStyleBackColor = true;
            this.btnActiveEmpDatabase.Click += new System.EventHandler(this.btnEmpDatabase_Click);
            // 
            // btnActiveEmpAD
            // 
            this.btnActiveEmpAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveEmpAD.Location = new System.Drawing.Point(9, 89);
            this.btnActiveEmpAD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActiveEmpAD.Name = "btnActiveEmpAD";
            this.btnActiveEmpAD.Size = new System.Drawing.Size(189, 92);
            this.btnActiveEmpAD.TabIndex = 0;
            this.btnActiveEmpAD.Text = "Active \r\nDirectory";
            this.btnActiveEmpAD.UseVisualStyleBackColor = true;
            this.btnActiveEmpAD.Click += new System.EventHandler(this.btnEmpAD_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(718, 459);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 58);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpOther
            // 
            this.grpOther.Controls.Add(this.btnWebFiltering);
            this.grpOther.Controls.Add(this.btnStorageAuthorizations);
            this.grpOther.Controls.Add(this.btnMonthlyReports);
            this.grpOther.Controls.Add(this.btnYubiKeys);
            this.grpOther.Location = new System.Drawing.Point(434, 205);
            this.grpOther.Name = "grpOther";
            this.grpOther.Size = new System.Drawing.Size(404, 238);
            this.grpOther.TabIndex = 15;
            this.grpOther.TabStop = false;
            this.grpOther.Text = "Other";
            // 
            // btnWebFiltering
            // 
            this.btnWebFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebFiltering.Location = new System.Drawing.Point(208, 27);
            this.btnWebFiltering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWebFiltering.Name = "btnWebFiltering";
            this.btnWebFiltering.Size = new System.Drawing.Size(189, 92);
            this.btnWebFiltering.TabIndex = 19;
            this.btnWebFiltering.Text = "Web\r\nFiltering";
            this.btnWebFiltering.UseVisualStyleBackColor = true;
            this.btnWebFiltering.Click += new System.EventHandler(this.btnWebFiltering_Click);
            // 
            // btnStorageAuthorizations
            // 
            this.btnStorageAuthorizations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageAuthorizations.Location = new System.Drawing.Point(7, 129);
            this.btnStorageAuthorizations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStorageAuthorizations.Name = "btnStorageAuthorizations";
            this.btnStorageAuthorizations.Size = new System.Drawing.Size(189, 92);
            this.btnStorageAuthorizations.TabIndex = 18;
            this.btnStorageAuthorizations.Text = "Storage Authorizations";
            this.btnStorageAuthorizations.UseVisualStyleBackColor = true;
            this.btnStorageAuthorizations.Click += new System.EventHandler(this.btnStorageAuthorizations_Click);
            // 
            // btnMonthlyReports
            // 
            this.btnMonthlyReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthlyReports.Location = new System.Drawing.Point(7, 27);
            this.btnMonthlyReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMonthlyReports.Name = "btnMonthlyReports";
            this.btnMonthlyReports.Size = new System.Drawing.Size(189, 92);
            this.btnMonthlyReports.TabIndex = 17;
            this.btnMonthlyReports.Text = "Monthly\r\nReports";
            this.btnMonthlyReports.UseVisualStyleBackColor = true;
            this.btnMonthlyReports.Click += new System.EventHandler(this.btnMonthlyReports_Click);
            // 
            // btnYubiKeys
            // 
            this.btnYubiKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYubiKeys.Location = new System.Drawing.Point(208, 129);
            this.btnYubiKeys.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnYubiKeys.Name = "btnYubiKeys";
            this.btnYubiKeys.Size = new System.Drawing.Size(189, 92);
            this.btnYubiKeys.TabIndex = 16;
            this.btnYubiKeys.Text = "YubiKeys";
            this.btnYubiKeys.UseVisualStyleBackColor = true;
            this.btnYubiKeys.Click += new System.EventHandler(this.btnYubiKeys_Click);
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 532);
            this.Controls.Add(this.grpOther);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpEmployeesActive);
            this.Controls.Add(this.grpAssets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.grpAssets.ResumeLayout(false);
            this.grpAssets.PerformLayout();
            this.grpEmployeesActive.ResumeLayout(false);
            this.grpEmployeeStatus.ResumeLayout(false);
            this.grpEmployeeStatus.PerformLayout();
            this.grpOther.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpOther;
        private System.Windows.Forms.Button btnYubiKeys;
        private System.Windows.Forms.Button btnWebFiltering;
        private System.Windows.Forms.Button btnStorageAuthorizations;
        private System.Windows.Forms.Button btnMonthlyReports;
    }
}


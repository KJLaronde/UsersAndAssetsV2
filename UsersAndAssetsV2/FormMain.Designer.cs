namespace UsersAndAssetsV2
{
    partial class FormMain
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
            this.lblSiteLocation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboToolStripSiteLocation = new System.Windows.Forms.ToolStripComboBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnStorageAuth = new System.Windows.Forms.Button();
            this.btnExtensionLists = new System.Windows.Forms.Button();
            this.btnAssets = new System.Windows.Forms.Button();
            this.mnuMenuStrip = new System.Windows.Forms.MenuStrip();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.btnYubiKeys = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnWebFilteringChanges = new System.Windows.Forms.Button();
            this.grpButtons.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSiteLocation
            // 
            this.lblSiteLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSiteLocation.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiteLocation.Location = new System.Drawing.Point(117, -55);
            this.lblSiteLocation.Name = "lblSiteLocation";
            this.lblSiteLocation.Size = new System.Drawing.Size(209, 25);
            this.lblSiteLocation.TabIndex = 9;
            this.lblSiteLocation.Text = "HCG-Madison";
            this.lblSiteLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "Users and Assets";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // siteToolStripMenuItem
            // 
            this.siteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboToolStripSiteLocation});
            this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
            this.siteToolStripMenuItem.Size = new System.Drawing.Size(48, 26);
            this.siteToolStripMenuItem.Text = "Site";
            // 
            // cboToolStripSiteLocation
            // 
            this.cboToolStripSiteLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToolStripSiteLocation.DropDownWidth = 300;
            this.cboToolStripSiteLocation.Name = "cboToolStripSiteLocation";
            this.cboToolStripSiteLocation.Size = new System.Drawing.Size(121, 33);
            this.cboToolStripSiteLocation.DropDown += new System.EventHandler(this.cboToolStripSiteLocation_DropDown);
            this.cboToolStripSiteLocation.DropDownClosed += new System.EventHandler(this.cboToolStripSiteLocation_DropDownClosed);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnReports);
            this.grpButtons.Controls.Add(this.btnEmployees);
            this.grpButtons.Location = new System.Drawing.Point(12, 71);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(417, 80);
            this.grpButtons.TabIndex = 13;
            this.grpButtons.TabStop = false;
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(5, 19);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(197, 43);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnStorageAuth
            // 
            this.btnStorageAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageAuth.Location = new System.Drawing.Point(5, 116);
            this.btnStorageAuth.Name = "btnStorageAuth";
            this.btnStorageAuth.Size = new System.Drawing.Size(197, 43);
            this.btnStorageAuth.TabIndex = 11;
            this.btnStorageAuth.Text = "Storage Auth";
            this.btnStorageAuth.UseVisualStyleBackColor = true;
            this.btnStorageAuth.Click += new System.EventHandler(this.btnStorageAuth_Click);
            // 
            // btnExtensionLists
            // 
            this.btnExtensionLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtensionLists.Location = new System.Drawing.Point(5, 67);
            this.btnExtensionLists.Name = "btnExtensionLists";
            this.btnExtensionLists.Size = new System.Drawing.Size(197, 43);
            this.btnExtensionLists.TabIndex = 10;
            this.btnExtensionLists.Text = "Extension List";
            this.btnExtensionLists.UseVisualStyleBackColor = true;
            this.btnExtensionLists.Click += new System.EventHandler(this.btnExtensionLists_Click);
            // 
            // btnAssets
            // 
            this.btnAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssets.Location = new System.Drawing.Point(5, 18);
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Size = new System.Drawing.Size(197, 43);
            this.btnAssets.TabIndex = 2;
            this.btnAssets.Text = "Assets";
            this.btnAssets.UseVisualStyleBackColor = true;
            this.btnAssets.Click += new System.EventHandler(this.btnAssets_Click);
            // 
            // mnuMenuStrip
            // 
            this.mnuMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuStrip.Name = "mnuMenuStrip";
            this.mnuMenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.mnuMenuStrip.Size = new System.Drawing.Size(443, 24);
            this.mnuMenuStrip.TabIndex = 14;
            this.mnuMenuStrip.Text = "menuStrip1";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.btnWebFilteringChanges);
            this.grpGeneral.Controls.Add(this.btnYubiKeys);
            this.grpGeneral.Controls.Add(this.btnAssets);
            this.grpGeneral.Controls.Add(this.btnExtensionLists);
            this.grpGeneral.Controls.Add(this.btnStorageAuth);
            this.grpGeneral.Location = new System.Drawing.Point(12, 156);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(2);
            this.grpGeneral.Size = new System.Drawing.Size(417, 172);
            this.grpGeneral.TabIndex = 15;
            this.grpGeneral.TabStop = false;
            // 
            // btnYubiKeys
            // 
            this.btnYubiKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYubiKeys.Location = new System.Drawing.Point(215, 67);
            this.btnYubiKeys.Name = "btnYubiKeys";
            this.btnYubiKeys.Size = new System.Drawing.Size(197, 43);
            this.btnYubiKeys.TabIndex = 12;
            this.btnYubiKeys.Text = "YubiKeys";
            this.btnYubiKeys.UseVisualStyleBackColor = true;
            this.btnYubiKeys.Click += new System.EventHandler(this.btnYubiKeys_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(215, 19);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(197, 43);
            this.btnReports.TabIndex = 13;
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnWebFilteringChanges
            // 
            this.btnWebFilteringChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebFilteringChanges.Location = new System.Drawing.Point(215, 18);
            this.btnWebFilteringChanges.Name = "btnWebFilteringChanges";
            this.btnWebFilteringChanges.Size = new System.Drawing.Size(197, 43);
            this.btnWebFilteringChanges.TabIndex = 13;
            this.btnWebFilteringChanges.Text = "Web Filtering";
            this.btnWebFilteringChanges.UseVisualStyleBackColor = true;
            this.btnWebFilteringChanges.Click += new System.EventHandler(this.btnWebFilteringChanges_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 336);
            this.Controls.Add(this.grpGeneral);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSiteLocation);
            this.Controls.Add(this.mnuMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grpButtons.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSiteLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cboToolStripSiteLocation;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnExtensionLists;
        private System.Windows.Forms.Button btnAssets;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.MenuStrip mnuMenuStrip;
        private System.Windows.Forms.Button btnStorageAuth;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Button btnYubiKeys;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnWebFilteringChanges;
    }
}
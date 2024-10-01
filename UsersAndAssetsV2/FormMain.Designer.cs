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
            this.btnReports = new System.Windows.Forms.Button();
            this.btnStorageAuth = new System.Windows.Forms.Button();
            this.btnExtensionLists = new System.Windows.Forms.Button();
            this.btnAssets = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.mnuMenuStrip = new System.Windows.Forms.MenuStrip();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSiteLocation
            // 
            this.lblSiteLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSiteLocation.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiteLocation.Location = new System.Drawing.Point(0, 194);
            this.lblSiteLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiteLocation.Name = "lblSiteLocation";
            this.lblSiteLocation.Size = new System.Drawing.Size(426, 39);
            this.lblSiteLocation.TabIndex = 9;
            this.lblSiteLocation.Text = "Ho-Chunk Nation";
            this.lblSiteLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 31);
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
            this.grpButtons.Controls.Add(this.btnStorageAuth);
            this.grpButtons.Controls.Add(this.btnExtensionLists);
            this.grpButtons.Controls.Add(this.btnAssets);
            this.grpButtons.Controls.Add(this.btnEmployees);
            this.grpButtons.Location = new System.Drawing.Point(18, 121);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Size = new System.Drawing.Size(390, 750);
            this.grpButtons.TabIndex = 13;
            this.grpButtons.TabStop = false;
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(38, 625);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(328, 94);
            this.btnReports.TabIndex = 12;
            this.btnReports.Text = "&Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStorageAuth
            // 
            this.btnStorageAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageAuth.Location = new System.Drawing.Point(38, 476);
            this.btnStorageAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStorageAuth.Name = "btnStorageAuth";
            this.btnStorageAuth.Size = new System.Drawing.Size(328, 94);
            this.btnStorageAuth.TabIndex = 11;
            this.btnStorageAuth.Text = "Storage Authorization";
            this.btnStorageAuth.UseVisualStyleBackColor = true;
            this.btnStorageAuth.Click += new System.EventHandler(this.btnStorageAuth_Click);
            // 
            // btnExtensionLists
            // 
            this.btnExtensionLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtensionLists.Location = new System.Drawing.Point(38, 327);
            this.btnExtensionLists.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtensionLists.Name = "btnExtensionLists";
            this.btnExtensionLists.Size = new System.Drawing.Size(328, 94);
            this.btnExtensionLists.TabIndex = 10;
            this.btnExtensionLists.Text = "Extension List";
            this.btnExtensionLists.UseVisualStyleBackColor = true;
            this.btnExtensionLists.Click += new System.EventHandler(this.btnExtensionLists_Click);
            // 
            // btnAssets
            // 
            this.btnAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssets.Location = new System.Drawing.Point(38, 178);
            this.btnAssets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Size = new System.Drawing.Size(328, 94);
            this.btnAssets.TabIndex = 2;
            this.btnAssets.Text = "Assets";
            this.btnAssets.UseVisualStyleBackColor = true;
            this.btnAssets.Click += new System.EventHandler(this.btnAssets_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(38, 29);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(328, 94);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // mnuMenuStrip
            // 
            this.mnuMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMenuStrip.Name = "mnuMenuStrip";
            this.mnuMenuStrip.Size = new System.Drawing.Size(426, 24);
            this.mnuMenuStrip.TabIndex = 14;
            this.mnuMenuStrip.Text = "menuStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 886);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSiteLocation);
            this.Controls.Add(this.mnuMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets v2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grpButtons.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnReports;
    }
}
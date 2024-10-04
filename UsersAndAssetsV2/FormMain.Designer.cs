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
            this.label2 = new System.Windows.Forms.Label();
            this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboToolStripSiteLocation = new System.Windows.Forms.ToolStripComboBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnWebFiltering = new System.Windows.Forms.Button();
            this.btnYubiKeys = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnStorageAuth = new System.Windows.Forms.Button();
            this.btnExtensionLists = new System.Windows.Forms.Button();
            this.btnAssets = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 24);
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
            this.grpButtons.Controls.Add(this.btnWebFiltering);
            this.grpButtons.Controls.Add(this.btnYubiKeys);
            this.grpButtons.Controls.Add(this.btnReports);
            this.grpButtons.Controls.Add(this.btnStorageAuth);
            this.grpButtons.Controls.Add(this.btnExtensionLists);
            this.grpButtons.Controls.Add(this.btnAssets);
            this.grpButtons.Controls.Add(this.btnEmployees);
            this.grpButtons.Location = new System.Drawing.Point(13, 60);
            this.grpButtons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpButtons.Size = new System.Drawing.Size(528, 387);
            this.grpButtons.TabIndex = 13;
            this.grpButtons.TabStop = false;
            // 
            // btnWebFiltering
            // 
            this.btnWebFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebFiltering.Location = new System.Drawing.Point(268, 207);
            this.btnWebFiltering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWebFiltering.Name = "btnWebFiltering";
            this.btnWebFiltering.Size = new System.Drawing.Size(252, 79);
            this.btnWebFiltering.TabIndex = 14;
            this.btnWebFiltering.Text = "Web Filtering";
            this.btnWebFiltering.UseVisualStyleBackColor = true;
            this.btnWebFiltering.Click += new System.EventHandler(this.btnWebFiltering_Click);
            // 
            // btnYubiKeys
            // 
            this.btnYubiKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYubiKeys.Location = new System.Drawing.Point(8, 296);
            this.btnYubiKeys.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnYubiKeys.Name = "btnYubiKeys";
            this.btnYubiKeys.Size = new System.Drawing.Size(252, 79);
            this.btnYubiKeys.TabIndex = 13;
            this.btnYubiKeys.Text = "YubiKeys";
            this.btnYubiKeys.UseVisualStyleBackColor = true;
            this.btnYubiKeys.Click += new System.EventHandler(this.btnYubiKeys_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(268, 118);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(252, 79);
            this.btnReports.TabIndex = 12;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStorageAuth
            // 
            this.btnStorageAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageAuth.Location = new System.Drawing.Point(8, 207);
            this.btnStorageAuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStorageAuth.Name = "btnStorageAuth";
            this.btnStorageAuth.Size = new System.Drawing.Size(252, 79);
            this.btnStorageAuth.TabIndex = 11;
            this.btnStorageAuth.Text = "Storage Authorization";
            this.btnStorageAuth.UseVisualStyleBackColor = true;
            this.btnStorageAuth.Click += new System.EventHandler(this.btnStorageAuth_Click);
            // 
            // btnExtensionLists
            // 
            this.btnExtensionLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtensionLists.Location = new System.Drawing.Point(8, 118);
            this.btnExtensionLists.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtensionLists.Name = "btnExtensionLists";
            this.btnExtensionLists.Size = new System.Drawing.Size(252, 79);
            this.btnExtensionLists.TabIndex = 10;
            this.btnExtensionLists.Text = "Extension List";
            this.btnExtensionLists.UseVisualStyleBackColor = true;
            this.btnExtensionLists.Click += new System.EventHandler(this.btnExtensionLists_Click);
            // 
            // btnAssets
            // 
            this.btnAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssets.Location = new System.Drawing.Point(8, 29);
            this.btnAssets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Size = new System.Drawing.Size(252, 79);
            this.btnAssets.TabIndex = 2;
            this.btnAssets.Text = "Assets";
            this.btnAssets.UseVisualStyleBackColor = true;
            this.btnAssets.Click += new System.EventHandler(this.btnAssets_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(268, 29);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(252, 79);
            this.btnEmployees.TabIndex = 0;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(393, 458);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 64);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(558, 534);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cboToolStripSiteLocation;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnExtensionLists;
        private System.Windows.Forms.Button btnAssets;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnStorageAuth;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnWebFiltering;
        private System.Windows.Forms.Button btnYubiKeys;
        private System.Windows.Forms.Button btnExit;
    }
}
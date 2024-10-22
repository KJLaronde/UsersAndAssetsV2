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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
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
            this.picAbout = new System.Windows.Forms.PictureBox();
            this.grpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 1;
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
            this.cboToolStripSiteLocation.Size = new System.Drawing.Size(121, 23);
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
            this.grpButtons.Location = new System.Drawing.Point(9, 39);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(352, 295);
            this.grpButtons.TabIndex = 2;
            this.grpButtons.TabStop = false;
            // 
            // btnWebFiltering
            // 
            this.btnWebFiltering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebFiltering.Location = new System.Drawing.Point(178, 155);
            this.btnWebFiltering.Name = "btnWebFiltering";
            this.btnWebFiltering.Size = new System.Drawing.Size(168, 61);
            this.btnWebFiltering.TabIndex = 8;
            this.btnWebFiltering.Text = "Web Filtering";
            this.btnWebFiltering.UseVisualStyleBackColor = true;
            this.btnWebFiltering.Click += new System.EventHandler(this.btnWebFiltering_Click);
            // 
            // btnYubiKeys
            // 
            this.btnYubiKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYubiKeys.Location = new System.Drawing.Point(6, 223);
            this.btnYubiKeys.Name = "btnYubiKeys";
            this.btnYubiKeys.Size = new System.Drawing.Size(168, 61);
            this.btnYubiKeys.TabIndex = 9;
            this.btnYubiKeys.Text = "YubiKeys";
            this.btnYubiKeys.UseVisualStyleBackColor = true;
            this.btnYubiKeys.Click += new System.EventHandler(this.btnYubiKeys_Click);
            // 
            // btnReports
            // 
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(178, 87);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(168, 61);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnStorageAuth
            // 
            this.btnStorageAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorageAuth.Location = new System.Drawing.Point(6, 155);
            this.btnStorageAuth.Name = "btnStorageAuth";
            this.btnStorageAuth.Size = new System.Drawing.Size(168, 61);
            this.btnStorageAuth.TabIndex = 7;
            this.btnStorageAuth.Text = "Storage Authorization";
            this.btnStorageAuth.UseVisualStyleBackColor = true;
            this.btnStorageAuth.Click += new System.EventHandler(this.btnStorageAuth_Click);
            // 
            // btnExtensionLists
            // 
            this.btnExtensionLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtensionLists.Location = new System.Drawing.Point(6, 87);
            this.btnExtensionLists.Name = "btnExtensionLists";
            this.btnExtensionLists.Size = new System.Drawing.Size(168, 61);
            this.btnExtensionLists.TabIndex = 5;
            this.btnExtensionLists.Text = "Extension List";
            this.btnExtensionLists.UseVisualStyleBackColor = true;
            this.btnExtensionLists.Click += new System.EventHandler(this.btnExtensionLists_Click);
            // 
            // btnAssets
            // 
            this.btnAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssets.Location = new System.Drawing.Point(6, 19);
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Size = new System.Drawing.Size(168, 61);
            this.btnAssets.TabIndex = 3;
            this.btnAssets.Text = "Assets";
            this.btnAssets.UseVisualStyleBackColor = true;
            this.btnAssets.Click += new System.EventHandler(this.btnAssets_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(178, 19);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(168, 61);
            this.btnEmployees.TabIndex = 4;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(270, 339);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 42);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picAbout
            // 
            this.picAbout.Image = ((System.Drawing.Image)(resources.GetObject("picAbout.Image")));
            this.picAbout.Location = new System.Drawing.Point(344, 16);
            this.picAbout.Margin = new System.Windows.Forms.Padding(2);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(17, 16);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAbout.TabIndex = 11;
            this.picAbout.TabStop = false;
            this.picAbout.Click += new System.EventHandler(this.picAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(369, 392);
            this.Controls.Add(this.picAbout);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets v2";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.grpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox picAbout;
    }
}
namespace UsersAndAssetsV2
{
    partial class FormStorageAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStorageAuth));
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.grpButtons = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.grdHistory = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpButtons.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmployee
            // 
            this.cboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(12, 33);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(278, 33);
            this.cboEmployee.TabIndex = 1;
            this.cboEmployee.DropDown += new System.EventHandler(this.cboEmployee_DropDown);
            this.cboEmployee.DropDownClosed += new System.EventHandler(this.cboEmployee_DropDownClosed);
            this.cboEmployee.Enter += new System.EventHandler(this.cboEmployee_Enter);
            this.cboEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboEmployee_KeyDown);
            this.cboEmployee.Leave += new System.EventHandler(this.cboEmployee_Leave);
            // 
            // grpButtons
            // 
            this.grpButtons.Controls.Add(this.btnClear);
            this.grpButtons.Controls.Add(this.btnNew);
            this.grpButtons.Location = new System.Drawing.Point(399, 12);
            this.grpButtons.Name = "grpButtons";
            this.grpButtons.Size = new System.Drawing.Size(253, 56);
            this.grpButtons.TabIndex = 2;
            this.grpButtons.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(130, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 31);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(9, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(115, 31);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New Entry";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(9, 9);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(56, 13);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Employee:";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.grdHistory);
            this.pnlSearch.Location = new System.Drawing.Point(12, 74);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(885, 327);
            this.pnlSearch.TabIndex = 99;
            // 
            // grdHistory
            // 
            this.grdHistory.AllowUserToAddRows = false;
            this.grdHistory.AllowUserToDeleteRows = false;
            this.grdHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHistory.Location = new System.Drawing.Point(0, 0);
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.ReadOnly = true;
            this.grdHistory.RowHeadersWidth = 62;
            this.grdHistory.Size = new System.Drawing.Size(885, 327);
            this.grdHistory.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(782, 29);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(115, 31);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormStorageAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 413);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.grpButtons);
            this.Controls.Add(this.cboEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStorageAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets - Storage Authorization";
            this.Load += new System.EventHandler(this.FormStorageAuth_Load);
            this.grpButtons.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.GroupBox grpButtons;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView grdHistory;
    }
}


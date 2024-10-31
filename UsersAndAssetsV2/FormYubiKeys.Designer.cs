namespace UsersAndAssetsV2
{
    partial class FormYubiKeys
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlYubikeys = new System.Windows.Forms.Panel();
            this.grdYubiKeys = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlYubikeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYubiKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(357, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlYubikeys
            // 
            this.pnlYubikeys.Controls.Add(this.grdYubiKeys);
            this.pnlYubikeys.Location = new System.Drawing.Point(8, 59);
            this.pnlYubikeys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlYubikeys.Name = "pnlYubikeys";
            this.pnlYubikeys.Size = new System.Drawing.Size(435, 486);
            this.pnlYubikeys.TabIndex = 1;
            // 
            // grdYubiKeys
            // 
            this.grdYubiKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdYubiKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdYubiKeys.Location = new System.Drawing.Point(0, 0);
            this.grdYubiKeys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grdYubiKeys.Name = "grdYubiKeys";
            this.grdYubiKeys.RowHeadersWidth = 62;
            this.grdYubiKeys.RowTemplate.Height = 28;
            this.grdYubiKeys.Size = new System.Drawing.Size(435, 486);
            this.grdYubiKeys.TabIndex = 0;
            this.grdYubiKeys.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdYubiKeys_CellDoubleClick);
            this.grdYubiKeys.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdYubiKeys_CellDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(261, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New Entry";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FormYubiKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 552);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pnlYubikeys);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormYubiKeys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets - YubiKeys";
            this.Load += new System.EventHandler(this.FormYubiKeys_Load);
            this.pnlYubikeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdYubiKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlYubikeys;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView grdYubiKeys;
    }
}
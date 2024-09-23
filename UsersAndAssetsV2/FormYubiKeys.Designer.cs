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
            this.btnClose.Location = new System.Drawing.Point(563, 777);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 61);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlYubikeys
            // 
            this.pnlYubikeys.Controls.Add(this.grdYubiKeys);
            this.pnlYubikeys.Location = new System.Drawing.Point(12, 12);
            this.pnlYubikeys.Name = "pnlYubikeys";
            this.pnlYubikeys.Size = new System.Drawing.Size(653, 759);
            this.pnlYubikeys.TabIndex = 1;
            // 
            // grdYubiKeys
            // 
            this.grdYubiKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdYubiKeys.Location = new System.Drawing.Point(3, 3);
            this.grdYubiKeys.Name = "grdYubiKeys";
            this.grdYubiKeys.RowHeadersWidth = 62;
            this.grdYubiKeys.RowTemplate.Height = 28;
            this.grdYubiKeys.Size = new System.Drawing.Size(647, 756);
            this.grdYubiKeys.TabIndex = 1;
            this.grdYubiKeys.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdYubiKeys_CellDoubleClick);
            this.grdYubiKeys.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdYubiKeys_CellDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 777);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(102, 61);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New Entry";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FormYubiKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 850);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pnlYubikeys);
            this.Controls.Add(this.btnClose);
            this.Name = "FormYubiKeys";
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
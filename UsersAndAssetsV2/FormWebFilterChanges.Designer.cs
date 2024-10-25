namespace UsersAndAssetsV2
{
    partial class FormWebFilterChanges
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
            this.pnlRecords = new System.Windows.Forms.Panel();
            this.grdRecords = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1344, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(166, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlRecords
            // 
            this.pnlRecords.Controls.Add(this.grdRecords);
            this.pnlRecords.Location = new System.Drawing.Point(18, 83);
            this.pnlRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlRecords.Name = "pnlRecords";
            this.pnlRecords.Size = new System.Drawing.Size(1492, 598);
            this.pnlRecords.TabIndex = 1;
            // 
            // grdRecords
            // 
            this.grdRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecords.Location = new System.Drawing.Point(0, 0);
            this.grdRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grdRecords.Name = "grdRecords";
            this.grdRecords.RowHeadersWidth = 62;
            this.grdRecords.Size = new System.Drawing.Size(1488, 594);
            this.grdRecords.TabIndex = 0;
            this.grdRecords.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRecords_CellDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(1140, 18);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(166, 55);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New Entry";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // FormWebFilterChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 703);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pnlRecords);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormWebFilterChanges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Users and Assets - Web Filtering";
            this.Load += new System.EventHandler(this.FormWebFilterChanges_Load);
            this.pnlRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlRecords;
        private System.Windows.Forms.DataGridView grdRecords;
        private System.Windows.Forms.Button btnNew;
    }
}
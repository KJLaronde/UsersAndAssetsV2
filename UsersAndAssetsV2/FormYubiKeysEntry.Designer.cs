namespace UsersAndAssetsV2
{
    partial class FormYubiKeysEntry
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSerial = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPublicId = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtPublicId = new System.Windows.Forms.TextBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboAssetType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(170, 256);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 256);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(8, 67);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(76, 13);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.Text = "Serial Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 157);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Department:";
            // 
            // lblPublicId
            // 
            this.lblPublicId.AutoSize = true;
            this.lblPublicId.Location = new System.Drawing.Point(8, 112);
            this.lblPublicId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPublicId.Name = "lblPublicId";
            this.lblPublicId.Size = new System.Drawing.Size(53, 13);
            this.lblPublicId.TabIndex = 4;
            this.lblPublicId.Text = "Public ID:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNumber.Location = new System.Drawing.Point(119, 64);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(130, 30);
            this.txtSerialNumber.TabIndex = 3;
            // 
            // txtPublicId
            // 
            this.txtPublicId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicId.Location = new System.Drawing.Point(119, 108);
            this.txtPublicId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPublicId.Name = "txtPublicId";
            this.txtPublicId.Size = new System.Drawing.Size(130, 30);
            this.txtPublicId.TabIndex = 5;
            // 
            // cboDepartment
            // 
            this.cboDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(87, 152);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(162, 33);
            this.cboDepartment.TabIndex = 7;
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(8, 22);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // cboAssetType
            // 
            this.cboAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssetType.FormattingEnabled = true;
            this.cboAssetType.Location = new System.Drawing.Point(119, 18);
            this.cboAssetType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboAssetType.Name = "cboAssetType";
            this.cboAssetType.Size = new System.Drawing.Size(130, 33);
            this.cboAssetType.TabIndex = 1;
            // 
            // FormYubiKeysEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 292);
            this.Controls.Add(this.cboAssetType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.txtPublicId);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.lblPublicId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FormYubiKeysEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YubiKey";
            this.Load += new System.EventHandler(this.FormYubiKeysEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPublicId;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtPublicId;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboAssetType;
    }
}
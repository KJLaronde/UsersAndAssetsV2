namespace UsersAndAssetsV2
{
    partial class ModalFormPermission
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
            this.cboDocument = new System.Windows.Forms.ComboBox();
            this.cboRequestor = new System.Windows.Forms.ComboBox();
            this.cboApplication = new System.Windows.Forms.ComboBox();
            this.picAttachment = new System.Windows.Forms.PictureBox();
            this.btnAttachmentView = new System.Windows.Forms.Button();
            this.btnAttachmentRemove = new System.Windows.Forms.Button();
            this.btnAttachmentAdd = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimestamp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdName = new System.Windows.Forms.TextBox();
            this.lblDateFormat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAttachment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(527, 420);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 48);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboDocument
            // 
            this.cboDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDocument.FormattingEnabled = true;
            this.cboDocument.Location = new System.Drawing.Point(128, 124);
            this.cboDocument.Margin = new System.Windows.Forms.Padding(4);
            this.cboDocument.Name = "cboDocument";
            this.cboDocument.Size = new System.Drawing.Size(287, 28);
            this.cboDocument.TabIndex = 0;
            this.cboDocument.DropDown += new System.EventHandler(this.cboDocument_DropDown);
            // 
            // cboRequestor
            // 
            this.cboRequestor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRequestor.FormattingEnabled = true;
            this.cboRequestor.Location = new System.Drawing.Point(128, 176);
            this.cboRequestor.Margin = new System.Windows.Forms.Padding(4);
            this.cboRequestor.Name = "cboRequestor";
            this.cboRequestor.Size = new System.Drawing.Size(287, 28);
            this.cboRequestor.TabIndex = 5;
            this.cboRequestor.DropDown += new System.EventHandler(this.cboRequestor_DropDown);
            // 
            // cboApplication
            // 
            this.cboApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboApplication.FormattingEnabled = true;
            this.cboApplication.Location = new System.Drawing.Point(128, 228);
            this.cboApplication.Margin = new System.Windows.Forms.Padding(4);
            this.cboApplication.Name = "cboApplication";
            this.cboApplication.Size = new System.Drawing.Size(287, 28);
            this.cboApplication.TabIndex = 10;
            this.cboApplication.DropDown += new System.EventHandler(this.cboApplication_DropDown);
            // 
            // picAttachment
            // 
            this.picAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAttachment.Location = new System.Drawing.Point(121, 382);
            this.picAttachment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAttachment.Name = "picAttachment";
            this.picAttachment.Size = new System.Drawing.Size(78, 70);
            this.picAttachment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttachment.TabIndex = 53;
            this.picAttachment.TabStop = false;
            // 
            // btnAttachmentView
            // 
            this.btnAttachmentView.Location = new System.Drawing.Point(216, 439);
            this.btnAttachmentView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentView.Name = "btnAttachmentView";
            this.btnAttachmentView.Size = new System.Drawing.Size(75, 23);
            this.btnAttachmentView.TabIndex = 30;
            this.btnAttachmentView.Text = "View";
            this.btnAttachmentView.UseVisualStyleBackColor = true;
            this.btnAttachmentView.Click += new System.EventHandler(this.btnAttachmentView_Click);
            // 
            // btnAttachmentRemove
            // 
            this.btnAttachmentRemove.Location = new System.Drawing.Point(216, 405);
            this.btnAttachmentRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentRemove.Name = "btnAttachmentRemove";
            this.btnAttachmentRemove.Size = new System.Drawing.Size(75, 23);
            this.btnAttachmentRemove.TabIndex = 25;
            this.btnAttachmentRemove.Text = "Remove";
            this.btnAttachmentRemove.UseVisualStyleBackColor = true;
            this.btnAttachmentRemove.Click += new System.EventHandler(this.btnAttachmentRemove_Click);
            // 
            // btnAttachmentAdd
            // 
            this.btnAttachmentAdd.Location = new System.Drawing.Point(216, 372);
            this.btnAttachmentAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentAdd.Name = "btnAttachmentAdd";
            this.btnAttachmentAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAttachmentAdd.TabIndex = 20;
            this.btnAttachmentAdd.Text = "Add";
            this.btnAttachmentAdd.UseVisualStyleBackColor = true;
            this.btnAttachmentAdd.Click += new System.EventHandler(this.btnAttachmentAdd_Click);
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(128, 284);
            this.txtComments.Margin = new System.Windows.Forms.Padding(4);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(504, 66);
            this.txtComments.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 284);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Comments:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Application:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Requestor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "Document:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 406);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 59;
            this.label5.Text = "Attachment:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 420);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 48);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 63;
            this.label6.Text = "Timestamp:";
            // 
            // txtTimestamp
            // 
            this.txtTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimestamp.Location = new System.Drawing.Point(132, 22);
            this.txtTimestamp.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimestamp.Name = "txtTimestamp";
            this.txtTimestamp.Size = new System.Drawing.Size(159, 26);
            this.txtTimestamp.TabIndex = 64;
            this.txtTimestamp.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 65;
            this.label7.Text = "Entered by:";
            // 
            // txtAdName
            // 
            this.txtAdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdName.Location = new System.Drawing.Point(132, 74);
            this.txtAdName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdName.Name = "txtAdName";
            this.txtAdName.ReadOnly = true;
            this.txtAdName.Size = new System.Drawing.Size(159, 26);
            this.txtAdName.TabIndex = 66;
            this.txtAdName.TabStop = false;
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.Location = new System.Drawing.Point(298, 28);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(82, 17);
            this.lblDateFormat.TabIndex = 67;
            this.lblDateFormat.Text = "mm/dd/yyyy";
            // 
            // ModalFormPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 482);
            this.Controls.Add(this.lblDateFormat);
            this.Controls.Add(this.txtAdName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTimestamp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.picAttachment);
            this.Controls.Add(this.btnAttachmentView);
            this.Controls.Add(this.btnAttachmentRemove);
            this.Controls.Add(this.btnAttachmentAdd);
            this.Controls.Add(this.cboApplication);
            this.Controls.Add(this.cboRequestor);
            this.Controls.Add(this.cboDocument);
            this.Controls.Add(this.btnClose);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModalFormPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users and Assets";
            this.Load += new System.EventHandler(this.ModalFormPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAttachment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboDocument;
        private System.Windows.Forms.ComboBox cboRequestor;
        private System.Windows.Forms.ComboBox cboApplication;
        private System.Windows.Forms.PictureBox picAttachment;
        private System.Windows.Forms.Button btnAttachmentView;
        private System.Windows.Forms.Button btnAttachmentRemove;
        private System.Windows.Forms.Button btnAttachmentAdd;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimestamp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAdName;
        private System.Windows.Forms.Label lblDateFormat;
    }
}
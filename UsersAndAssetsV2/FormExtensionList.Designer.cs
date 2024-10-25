namespace UsersAndAssetsV2
{
    partial class FormExtensionList
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnEditFlatFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(222, 404);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 58);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublish.Location = new System.Drawing.Point(57, 153);
            this.btnPublish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(258, 66);
            this.btnPublish.TabIndex = 1;
            this.btnPublish.Text = "Publish List";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplay.Location = new System.Drawing.Point(57, 41);
            this.btnDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(258, 66);
            this.btnDisplay.TabIndex = 0;
            this.btnDisplay.Text = "View List";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnEditFlatFile
            // 
            this.btnEditFlatFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditFlatFile.Location = new System.Drawing.Point(57, 265);
            this.btnEditFlatFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditFlatFile.Name = "btnEditFlatFile";
            this.btnEditFlatFile.Size = new System.Drawing.Size(258, 66);
            this.btnEditFlatFile.TabIndex = 2;
            this.btnEditFlatFile.Text = "Edit Flat File";
            this.btnEditFlatFile.UseVisualStyleBackColor = true;
            this.btnEditFlatFile.Click += new System.EventHandler(this.btnEditFlatFile_Click);
            // 
            // FormExtensionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 476);
            this.Controls.Add(this.btnEditFlatFile);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormExtensionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Extensions List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnEditFlatFile;
    }
}
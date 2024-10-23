namespace UsersAndAssetsV2
{
    partial class FormExtensionListReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ViewPhoneExtensionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ViewPhoneExtensionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewPhoneExtensionsBindingSource
            // 
            this.ViewPhoneExtensionsBindingSource.DataMember = "ViewPhoneExtensions";
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ViewPhoneExtensionsBindingSource;
            this.rptViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewer.LocalReport.ReportEmbeddedResource = "UsersAndAssets.ReportExtensionList.rdlc";
            this.rptViewer.LocalReport.ReportPath = "";
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.rptViewer.Size = new System.Drawing.Size(1200, 1410);
            this.rptViewer.TabIndex = 0;
            // 
            // FormExtensionListReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1410);
            this.Controls.Add(this.rptViewer);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormExtensionListReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extension List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportExtensionList_FormClosed);
            this.Load += new System.EventHandler(this.ReportExtensionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewPhoneExtensionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.BindingSource ViewPhoneExtensionsBindingSource;
        //private UsersAndAssetsDataSet UsersAndAssetsDataSet;
        //private UsersAndAssetsDataSetTableAdapters.ViewPhoneExtensionsTableAdapter ViewPhoneExtensionsTableAdapter;
    }
}
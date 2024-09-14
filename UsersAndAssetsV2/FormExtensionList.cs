using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormExtensionList : Form
    {
        private readonly FormMain _parentForm;
        public readonly SqlConnection SqlConn;

        /// <summary>
        /// Initializes a new instance of the FormExtensionList class.
        /// Sets the parent form and SQL connection, and initializes form components.
        /// </summary>
        /// <param name="parentForm">The parent form that invoked this extension list form.</param>
        /// <exception cref="ArgumentNullException">Thrown when parentForm is null.</exception>
        public FormExtensionList(FormMain parentForm)
        {
            _parentForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));
            SqlConn = parentForm.SqlConn;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeComponent();
        }

        #region Control Methods

        /// <summary>
        /// Event handler for the Back button. Closes this form and shows the parent form (FormMain).
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }

        /// <summary>
        /// Event handler for the Display button. Opens the extension list in view-only mode.
        /// </summary>
        private void btnDisplay_Click(object sender, EventArgs e) => OpenExtensionList(true);

        /// <summary>
        /// Event handler for the Publish button. Opens the extension list in publish mode, exporting the report to a PDF.
        /// </summary>
        private void btnPublish_Click(object sender, EventArgs e) => OpenExtensionList(false);

        /// <summary>
        /// Event handler for the Edit Flat File button. Opens the "PhoneList_Other.txt" flat file for editing if it exists.
        /// </summary>
        private void btnEditFlatFile_Click(object sender, EventArgs e)
        {
            var filePath = GetFilePath("PhoneList_Other.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show("Error opening file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath);
            }
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Gets the full file path of the given file name based on the current application's directory.
        /// </summary>
        /// <param name="fileName">The name of the file to get the path for.</param>
        /// <returns>The full file path of the specified file.</returns>
        private string GetFilePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        /// <summary>
        /// Opens the extension list form. Depending on the viewOnly parameter, it either shows the report or publishes it as a PDF.
        /// Hides the current form while the report form is open, and shows the parent form when the report form is closed.
        /// </summary>
        /// <param name="viewOnly">Specifies whether the report should be opened in view-only mode or publish mode (PDF export).</param>
        private void OpenExtensionList(bool viewOnly)
        {
            var report = new ReportExtensionList(this, viewOnly);
            report.FormClosed += (s, e) => this.Show(); // Show the parent form when the report form is closed
            this.Hide(); // Hide the current form while the report is open
            report.Show();
        }

        #endregion
    }
}

using Microsoft.Reporting.WinForms;
using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormExtensionListReport : Form
    {
        private new readonly FormExtensionList Parent;
        private readonly bool IsViewOnly;
        private readonly int SiteLocationID;
        private readonly SqlConnection SqlConnection;
        // Path where the report will be saved (production path)
        private readonly string ExtensionListSavePath = @"\\HCGM-FandP4\public\Extension Listings\HCG-Madison Ext List.pdf";
        // Flat file containing additional extension data
        private readonly string ExtensionListFlatFile = "PhoneList_Other.txt";
        private FormPleaseWaitBox pleaseWaitBox = null;

        /// <summary>
        /// Constructor for the ReportExtensionList form.
        /// Initializes form properties and stores the parent form reference and connection details.
        /// </summary>
        /// <param name="parentForm">The parent form that invoked this report.</param>
        /// <param name="isViewOnly">Specifies whether the report is in view-only mode or needs to export as a PDF.</param>
        public FormExtensionListReport(FormExtensionList parentForm, bool isViewOnly)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Parent = parentForm;
            IsViewOnly = isViewOnly;
            SiteLocationID = 1; // Parent.SiteLocationID;
            SqlConnection = Parent.SqlConn;

            InitializeComponent();
        }

        /// <summary>
        /// Event handler for when the ReportExtensionList form is closed.
        /// Displays the parent form upon closure.
        /// </summary>
        private void ReportExtensionList_FormClosed(object sender, FormClosedEventArgs e) => Parent.Show();

        /// <summary>
        /// Loads the report extension list when the form is opened. 
        /// Depending on the value of IsViewOnly, it either displays the report or exports it to a PDF.
        /// </summary>
        private async void ReportExtensionList_Load(object sender, EventArgs e)
        {
            // Start the 'Please wait' dialog in a separate non-blocking task
            Task showWaitBoxTask = Task.Run(() => ShowPleaseWaitBox());

            try
            {
                // 1. Update the PhoneList table with new data
                await Task.Run(() => UpdateExtensionListData());

                // 2. Set the RDLC file path for the report
                rptViewer.LocalReport.ReportPath = "ReportExtensionList.rdlc";

                // 3. Fetch updated data from the database
                DataTable extensionListData = await Task.Run(() => FetchExtensionListData());

                // 4. Clear existing report data sources
                rptViewer.LocalReport.DataSources.Clear();

                // 5. Add the new data to the report viewer
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", extensionListData));

                if (IsViewOnly)
                {
                    // If viewing only, display the report in the form
                    rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    rptViewer.RefreshReport();
                    this.Show();
                    ClosePleaseWaitBox();
                }
                else
                {
                    // Otherwise, export the report directly to a PDF file
                    await ExportExtensionList();
                    this.Close();  // Close the form after export
                }
            }
            catch (Exception err)
            {
                // Display any errors that occur during the process
                CommonMethods.DisplayError(err.Message);
                ClosePleaseWaitBox();  // Ensure the 'Please wait' box is closed on error
            }
        }

        /// <summary>
        /// Closes the "Please wait" box if it is open.
        /// Ensures this is done on the UI thread to avoid cross-threading issues.
        /// </summary>
        private void ClosePleaseWaitBox()
        {
            if (pleaseWaitBox != null && pleaseWaitBox.IsHandleCreated)
            {
                // Close the Please Wait box on the UI thread
                pleaseWaitBox.Invoke(new Action(() => pleaseWaitBox.Close()));
                pleaseWaitBox = null;
            }
        }

        /// <summary>
        /// Exports the report to a PDF file and saves it at the specified path.
        /// Displays the 'Please wait' box while exporting and closes it upon completion.
        /// </summary>
        /// <returns>A task representing the asynchronous export operation.</returns>
        private async Task ExportExtensionList()
        {
            // Show the 'Please wait' box while exporting
            Task showWaitBoxTask = Task.Run(() => ShowPleaseWaitBox());

            try
            {
                // Render the report as a PDF asynchronously
                byte[] bytes = await Task.Run(() => rptViewer.LocalReport.Render(
                    "PDF", null, out string mimeType, out string encoding,
                    out string filenameExtension, out string[] streamids, out Warning[] warnings));

                // Save the rendered PDF to the specified path
                await Task.Run(() =>
                {
                    using (FileStream fs = new FileStream(ExtensionListSavePath, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                });

                // Close the 'Please wait' box after the export is complete
                ClosePleaseWaitBox();
            }
            catch (Exception err)
            {
                // Display any errors that occur during the export process
                CommonMethods.DisplayError("Unable to render the Extension List: " + err.Message, "ReportExtensionList");

                // Ensure the 'Please wait' box is closed on error
                ClosePleaseWaitBox();
            }
        }

        /// <summary>
        /// Fetches the phone extension list data from the database.
        /// </summary>
        /// <returns>A DataTable containing the extension list data.</returns>
        private DataTable FetchExtensionListData()
        {
            DataTable extensionListData = new DataTable();

            string dataQuery = @"
                SELECT * 
                FROM PhoneList
                ORDER BY [Department], [Phone Rank], [Position], [Full Name], [Extension]";

            try
            {
                // Execute the SQL query and fill the DataTable
                using (SqlCommand cmd = new SqlCommand(dataQuery, SqlConnection))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DatabaseMethods.CheckSqlConnectionState(SqlConnection);
                    dataAdapter.Fill(extensionListData);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection?.Close();
            }

            return extensionListData;
        }

        /// <summary>
        /// Shows the "Please wait" box as a modal dialog to indicate that processing is occurring.
        /// </summary>
        private void ShowPleaseWaitBox()
        {
            if (pleaseWaitBox == null)
            {
                pleaseWaitBox = new FormPleaseWaitBox();
                pleaseWaitBox.ShowDialog();  // Show the "Please wait" box
            }
        }

        /// <summary>
        /// Updates the PhoneList table by truncating it and refilling it with data from the Employee table.
        /// Reads additional phone list data from a flat file and inserts it into the PhoneList table.
        /// </summary>
        public void UpdateExtensionListData()
        {
            // Clear the existing PhoneList table data
            string tableQuery = "TRUNCATE TABLE [PhoneList];";

            // SQL query to fetch employee data for phone list
            string dataQuery = $@" 
                SELECT d.Name AS 'Department', j.Title AS 'Position', 
                    CONCAT(e.FirstName, ' ', e.LastName) AS 'Full Name', 
                    e.PhoneExtension AS 'Extension',  e.PhoneRank AS 'Phone Rank' 
                FROM Employee AS e 
                INNER JOIN Job AS j ON e.Job_ID = j.ID 
                INNER JOIN Department AS d ON j.Department_ID = d.ID 
                WHERE e.Active = 1 AND e.PhoneExtension IS NOT NULL 
                      AND e.PhoneRank IS NOT NULL AND e.SiteLocation_ID = {SiteLocationID}
                ORDER BY [Department], [Phone Rank], [Position], [Full Name], [Extension];";

            // Clear the PhoneList table
            DatabaseMethods.ExecuteNonQuery(tableQuery, SqlConnection);

            // Fetch data from Employee table
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(dataQuery, SqlConnection);

            // Insert the data into the PhoneList table
            foreach (DataRow row in dataTable.Rows)
            {
                string insertQuery = $@"
                    INSERT INTO [dbo].[PhoneList] 
                    ([Department], [Position], [Full Name], [Extension], [Phone Rank], [SiteLocation_ID]) 
                    VALUES ('{row["Department"]}', '{row["Position"]}', '{row["Full Name"]}', 
                            {row["Extension"]}, {row["Phone Rank"]}, {SiteLocationID})";

                DatabaseMethods.ExecuteNonQuery(insertQuery, SqlConnection);
            }
            dataTable.Dispose();

            // Read additional entries from a flat file and insert them into the PhoneList table
            using (StreamReader file = new StreamReader(ExtensionListFlatFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    string insertQuery = $@"
                        INSERT INTO [dbo].[PhoneList] 
                        ([Department], [Position], [Full Name], [Extension], [Phone Rank], [SiteLocation_ID]) 
                        VALUES ('{fields[0]}', '{fields[1]}', '{fields[2]}', {fields[3]}, {fields[4]}, {fields[5]})";

                    DatabaseMethods.ExecuteNonQuery(insertQuery, SqlConnection);
                }
            }
        }
    }
}

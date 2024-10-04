using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class ModalFormPermission : Form
    {
        private FormMain parent { get; }
        private SqlConnection SqlConn { get; }
        private int SiteLocationID { get; }
        private string SiteName { get; }

        private byte[] attachment = null;
        private DateTime timestamp;
        private int employeeID = 0;
        private int requestorID = 0;
        private int documentID = 0;
        private int applicationID = 0;
        private long recordNumber = 0;
        private string actionType;
        private string attachmentName;
        private string attachmentPath;
        private string comments;

        /// <summary>
        /// Constructor for ModalFormPermission form.
        /// Initializes fields and sets up the form based on the provided action type, employee ID, and optional record ID.
        /// </summary>
        /// <param name="_actionType">Specifies whether the form is for creating or editing a permission record.</param>
        /// <param name="formMain">Reference to the parent FormMain instance.</param>
        /// <param name="_employeeID">The ID of the employee involved in the permission change.</param>
        /// <param name="_recordID">Optional record number for editing an existing permission change record.</param>
        public ModalFormPermission(string _actionType, FormMain formMain, int _employeeID, long _recordID = 0)
        {
            actionType = _actionType;
            employeeID = _employeeID;
            recordNumber = _recordID;
            parent = formMain;
            SiteLocationID = parent.SiteLocationID;
            SiteName = parent.SiteName;
            SqlConn = parent.SqlConn;
            InitializeComponent();
        }

        /// <summary>
        /// Loads the form and sets up initial values based on the action type (edit/new).
        /// Initializes comboboxes, date fields, and sets up the current user.
        /// </summary>
        /// <param name="sender">The sender object (form load event).</param>
        /// <param name="e">Event arguments for the form load event.</param>
        private void ModalFormPermission_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Text = $"Permission Records - {SiteName}";
            txtTimestamp.ReadOnly = false;

            PopulateCboApplication();
            PopulateCboDocument();
            PopulateCboRequestor();

            if (actionType == "edit")
            {
                PopulateExistingData();
            }
            else
            {
                timestamp = DateTime.Now;
                txtTimestamp.Text = timestamp.ToString("MM/dd/yyyy");
                string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                currentUser = currentUser.Remove(0, @"NATION\".Length);
                txtAdName.Text = currentUser;
            }

            ToggleAttachmentButtons();
        }

        #region Control Methods

        private void btnAttachmentAdd_Click(object sender, EventArgs e)
        {
            AttachFileFromDialog();
        }

        private void btnAttachmentRemove_Click(object sender, EventArgs e)
        {
            // Clear out the attachment
            picAttachment.Image = null;
            attachment = null;
            ToggleAttachmentButtons();
        }

        private void btnAttachmentView_Click(object sender, EventArgs e)
        {
            OpenAttachment();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            VerifyAndWriteData();
        }

        private void cboApplication_DropDown(object sender, EventArgs e)
        {
            cboApplication.SelectedIndex = -1;
        }

        private void cboDocument_DropDown(object sender, EventArgs e)
        {
            cboDocument.SelectedIndex = -1;
        }

        private void cboRequestor_DropDown(object sender, EventArgs e)
        {
            cboRequestor.SelectedIndex = -1;
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Opens a file dialog to select a PDF file and attaches it by reading it into a byte array.
        /// Updates the attachment-related buttons after the file is selected.
        /// </summary>
        private void AttachFileFromDialog()
        {
            OpenFileDialog openAttachment = new OpenFileDialog
            {
                Filter = "Adobe PDF files (*.pdf)|*.pdf",
                Title = "Please select a PDF file to attach."
            };

            DialogResult result = openAttachment.ShowDialog();
            if (result == DialogResult.OK)
            {
                attachmentName = openAttachment.FileName;

                try
                {
                    // Read the PDF into a byte[] variable
                    using (var stream = new FileStream(attachmentName, FileMode.Open, FileAccess.Read))
                    using (var reader = new BinaryReader(stream))
                    {
                        attachment = reader.ReadBytes((int)stream.Length);
                    }


                    // Display the PDF icon
                    //picAttachment.Image = Properties.Resources.PDF_32;

                    ToggleAttachmentButtons();
                }
                catch (IOException ex)
                {
                    CommonMethods.DisplayError("Failed to load the attachment: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Inserts a new permission change record into the database with details like employee, document, and attachment.
        /// </summary>
        private void CreateRecordInDatabase()
        {
            bool attachmentBit = attachment != null;

            string insertQuery = @"
                INSERT INTO [PermissionChange] 
                  ([Employee_ID], [DateOfChange], [ADName], [Document_ID], [Requestor_ID], [Application_ID], [Attachment], [AttachmentBit], [Comments] 
                ) VALUES ( 
                  @EmployeeID, @DateOfChange, @ADName, @DocumentID, @RequestorID, @ApplicationID, @Attachment, @AttachmentBit, @Comments)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, SqlConn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@DateOfChange", timestamp);
                    cmd.Parameters.AddWithValue("@ADName", txtAdName.Text);
                    cmd.Parameters.AddWithValue("@DocumentID", documentID);
                    cmd.Parameters.AddWithValue("@RequestorID", requestorID);
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmd.Parameters.AddWithValue("@Attachment", (object)attachment ?? DBNull.Value); // Save attachment as byte array
                    cmd.Parameters.AddWithValue("@AttachmentBit", attachmentBit);
                    cmd.Parameters.AddWithValue("@Comments", (object)comments ?? DBNull.Value);

                    DatabaseMethods.CheckSqlConnectionState(SqlConn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "Creating Record");
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Deletes an attachment file from the file share for an existing permission change record.
        /// Only applicable when the record is being edited.
        /// </summary>
        private void DeleteAttachmentFromShare()
        {
            // Only occurs when an existing record has been loaded and is being updated
            string query = "SELECT [Attachment] FROM [PermissionChange] WHERE [ID] = " + recordNumber;
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            var tempFile = dataTable.Rows[0]["Attachment"];
            if (tempFile != DBNull.Value)
            {
                string filePath = Convert.ToString(tempFile);
                File.Delete(filePath);
            }
        }

        /// <summary>
        /// Retrieves the attachment from the database and loads it as a byte array into memory for viewing or further operations.
        /// </summary>
        private void GetAttachmentFromDatabase()
        {
            string query = "SELECT [Attachment] FROM [PermissionChange] WHERE [ID] = @RecordNumber";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, SqlConn))
                {
                    cmd.Parameters.AddWithValue("@RecordNumber", recordNumber);
                    DatabaseMethods.CheckSqlConnectionState(SqlConn);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        attachment = (byte[])result; // Store the attachment as a byte array
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "Getting Attachment");
            }
        }

        /// <summary>
        /// Opens the attached file by saving the byte array to a temporary file on disk and launching it with the default application.
        /// </summary>
        private void OpenAttachment()
        {
            if (attachment == null)
            {
                CommonMethods.DisplayError("No attachment available to view.");
                return;
            }

            try
            {
                // Save the byte array to a temporary file and open it
                string tempPath = Path.Combine(Path.GetTempPath(), attachmentName);
                File.WriteAllBytes(tempPath, attachment);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true // Opens with the default PDF viewer
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError("Failed to open the attachment: " + ex.Message);
            }
        }

        /// <summary>
        /// Populates the Application combobox with data from the database.
        /// </summary>
        private void PopulateCboApplication()
        {
            string query = " SELECT [ID], [Name] FROM [Application] ORDER BY [Name] ";
            PopulateComboBox(cboApplication, query, "ID", "Name");
        }

        /// <summary>
        /// Populates the Document combobox with data from the database.
        /// </summary>
        private void PopulateCboDocument()
        {
            string query = " SELECT [ID], [Name] FROM [Document] ORDER BY [Name] ";
            PopulateComboBox(cboDocument, query, "ID", "Name");
        }

        /// <summary>
        /// Populates the Requestor combobox with data from the database.
        /// Retrieves employees from the active employees for the current site location.
        /// </summary>
        private void PopulateCboRequestor()
        {
            string query = @"SELECT [ID], CONCAT([FirstName], ' ', [LastName]) AS 'Requestor' 
                             FROM [Employee] 
                             WHERE ([Active] = 1 AND [SiteLocation_ID] = 1) 
                             ORDER BY 'Requestor' ";
            PopulateComboBox(cboRequestor, query, "ID", "Requestor");
        }

        /// <summary>
        /// Populates the provided combobox with data from the database.
        /// Configures autocomplete for the combobox for better user experience.
        /// </summary>
        /// <param name="comboBox">The combobox to be populated with data.</param>
        /// <param name="query">SQL query to fetch data for the combobox.</param>
        /// <param name="valueMember">The column name to use as the value member.</param>
        /// <param name="displayMember">The column name to use as the display member.</param>
        private void PopulateComboBox(ComboBox comboBox, string query, string valueMember, string displayMember)
        {
            DatabaseMethods.PopulateComboBoxUsingObjectFields(comboBox, query, valueMember, displayMember, SqlConn);
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Populates the form fields with data from an existing permission change record, including attachments and combobox selections.
        /// </summary>
        private void PopulateExistingData()
        {
            string query = $@"
                SELECT [P].[ID], [P].[DateOfChange] AS 'Date', [P].[ADName] AS 'AD Name', [D].[Name] AS 'Document', 
                  CONCAT([E].[FirstName], ' ', [E].[LastName]) AS 'Requestor', [A].[Name] AS 'Application', 
                  [P].[Attachment], [P].[Comments] 
                FROM [PermissionChange] AS P INNER JOIN 
                  [Application] AS A ON [P].[Application_ID] = [A].[ID] INNER JOIN 
                  [Document]    AS D ON [P].[Document_ID]    = [D].[ID] INNER JOIN 
                  [Employee]    AS E ON [P].[Employee_ID]    = [E].[ID] 
                WHERE [P].[ID] = {recordNumber};";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);

            cboApplication.SelectedIndex = cboApplication.FindStringExact(Convert.ToString(dataTable.Rows[0]["Application"]));
            cboDocument.SelectedIndex = cboDocument.FindStringExact(Convert.ToString(dataTable.Rows[0]["Document"]));
            cboRequestor.SelectedIndex = cboRequestor.FindStringExact(Convert.ToString(dataTable.Rows[0]["Requestor"]));
            txtAdName.Text = Convert.ToString(dataTable.Rows[0]["AD Name"]);
            txtComments.Text = Convert.ToString(dataTable.Rows[0]["Comments"]);
            timestamp = Convert.ToDateTime(dataTable.Rows[0]["Date"]);
            txtTimestamp.Text = timestamp.ToString("MM/dd/yyyy");

            var tempAttachment = dataTable.Rows[0]["Attachment"];
            if (tempAttachment != DBNull.Value)
            {
                GetAttachmentFromDatabase();
                attachmentPath = Convert.ToString(tempAttachment);
            }
            else
                attachment = null;

            ToggleAttachmentButtons();
        }

        /// <summary>
        /// Saves the attachment to a network share folder.
        /// The folder structure is organized by employee name and document type.
        /// </summary>
        /// <returns>Returns the full path of the saved attachment file.</returns>
        private string SaveAttachmentToShare()
        {
            try
            {
                string docQuery = $"SELECT [Name] FROM [Document] WHERE [ID] = {documentID};";
                string empQuery = $"SELECT CONCAT([LastName], ' ', [FirstName]) AS 'Employee' FROM [Employee] WHERE [ID] = {employeeID};";

                DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(docQuery, SqlConn);
                string documentType = Convert.ToString(dataTable.Rows[0]["Name"]);
                string fileName = timestamp.ToString("yyyyMMdd ") + documentType + ".pdf";

                dataTable = DatabaseMethods.QueryDatabaseForDataTable(empQuery, SqlConn);

                string username = Convert.ToString(dataTable.Rows[0]["Employee"]);
                string outputPath = @"\\hcgm-it\share\Applications\UsersAndAssets\Permissions\" + username;
                string fullPath = outputPath + @"\" + fileName;

                Directory.CreateDirectory(outputPath);
                File.WriteAllBytes(fullPath, attachment);

                return fullPath;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "Saving Attachment");
                return null;
            }
        }

        /// <summary>
        /// Toggles the enabled state of attachment-related buttons based on whether an attachment is present or not.
        /// Disables 'Add' button if an attachment is present, and enables 'Remove' and 'View' buttons accordingly.
        /// </summary>
        private void ToggleAttachmentButtons()
        {
            bool state = (attachment == null);
            btnAttachmentAdd.Enabled = state;
            btnAttachmentRemove.Enabled = !state;
            btnAttachmentView.Enabled = !state;

            if (state)
                picAttachment.Image = null;
            //else
            //    picAttachment.Image = Properties.Resources.PDF_32;
        }

        /// <summary>
        /// Tries to get the selected value from a combobox.
        /// If the combobox is not selected, displays an error message.
        /// </summary>
        /// <param name="comboBox">The combobox from which to retrieve the selected value.</param>
        /// <param name="selectedValue">The selected value returned as an out parameter.</param>
        /// <param name="errorMessage">Error message to display if no value is selected.</param>
        /// <returns>Returns true if a value is selected, otherwise false.</returns>
        private bool TryGetSelectedValue(ComboBox comboBox, out int selectedValue, string errorMessage)
        {
            if (comboBox.SelectedIndex != -1)
            {
                selectedValue = Convert.ToInt32(comboBox.SelectedValue);
                return true;
            }
            else
            {
                CommonMethods.DisplayError(errorMessage);
                selectedValue = 0;
                return false;
            }
        }

        /// <summary>
        /// Updates an existing permission change record in the database, including the attachment.
        /// If no new attachment is provided, the existing attachment is kept or deleted if necessary.
        /// </summary>
        private void UpdateRecordInDatabase()
        {
            bool attachmentBit = attachment != null;

            string updateQuery = @"
                UPDATE [PermissionChange]
                SET [DateOfChange] = @DateOfChange,
                    [Document_ID] = @DocumentID,
                    [Requestor_ID] = @RequestorID,
                    [Application_ID] = @ApplicationID,
                    [Attachment] = @Attachment,    // Storing the binary data
                    [AttachmentBit] = @AttachmentBit,
                    [Comments] = @Comments
                WHERE [ID] = @RecordNumber";

            try
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, SqlConn))
                {
                    cmd.Parameters.AddWithValue("@DateOfChange", timestamp);
                    cmd.Parameters.AddWithValue("@DocumentID", documentID);
                    cmd.Parameters.AddWithValue("@RequestorID", requestorID);
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmd.Parameters.AddWithValue("@Attachment", (object)attachment ?? DBNull.Value);  // Pass attachment as byte array
                    cmd.Parameters.AddWithValue("@AttachmentBit", attachmentBit);
                    cmd.Parameters.AddWithValue("@Comments", (object)comments ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RecordNumber", recordNumber);

                    DatabaseMethods.CheckSqlConnectionState(SqlConn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "Updating Record");
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Validates the form fields, including date and combobox selections.
        /// Based on the action type, either creates a new record or updates an existing one in the database.
        /// </summary>
        private void VerifyAndWriteData()
        {
            // Validate timestamp
            if (!DateTime.TryParseExact(txtTimestamp.Text, "MM/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out timestamp))
            {
                CommonMethods.DisplayError("Invalid date.");
                return;
            }

            // Validate combobox selections
            if (!TryGetSelectedValue(cboApplication, out applicationID, "Please select an application.") ||
                !TryGetSelectedValue(cboDocument, out documentID, "Please select a document.") ||
                !TryGetSelectedValue(cboRequestor, out requestorID, "Please select the requestor."))
            {
                return;
            }

            // Get comments, allow null if empty
            comments = string.IsNullOrEmpty(txtComments.Text) ? null : txtComments.Text;

            // Write to the database
            switch (actionType)
            {
                case "new":
                    CreateRecordInDatabase();
                    break;
                case "edit":
                    UpdateRecordInDatabase();
                    break;
                default:
                    CommonMethods.DisplayError("Invalid action type.");
                    break;
            }
        }

        #endregion
    }
}

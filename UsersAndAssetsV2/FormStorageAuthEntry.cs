using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    /// <summary>
    /// Represents the form used for entering or editing storage authorization data.
    /// </summary>
    public partial class FormStorageAuthEntry : Form
    {
        // Readonly fields to hold employee information, form state, and SQL connection
        private readonly string BadgeNumber;    // Badge number of the employee
        private readonly string EmployeeID;     // Index of the employee in the Employee table
        private readonly string FirstName;      // First name of the employee
        private readonly string Initial;        // Middle initial(s) of the employee
        private readonly string LastName;       // Last name of the employee
        private readonly bool DVD;              // Indicates if the employee has DVD rights
        private readonly bool USB;              // Indicates if the employee has USB rights
        private readonly bool IsEdit;           // Indicates if the form is in edit mode
        private readonly object CompletedBy;    // Personnel who completed the entry
        private readonly object CompletedDate;  // Date the access change was made
        private readonly object Reason;         // Reason for the access change
        private readonly object SignedDate;     // Date the record was signed
        private readonly SqlConnection SqlConn; // SQL connection used for database operations

        /// <summary>
        /// Initializes a new instance of the <see cref="FormStorageAuthEntry"/> class for creating a new record.
        /// </summary>
        /// <param name="table">DataTable containing the employee information.</param>
        /// <param name="sqlConn">SQL connection for database operations.</param>
        public FormStorageAuthEntry(DataTable table, SqlConnection sqlConn)
        {
            InitializeComponent();

            // Set the fields based on the data table
            BadgeNumber = table.Rows[0]["BadgeNumber"].ToString();
            EmployeeID = table.Rows[0]["ID"].ToString();
            FirstName = table.Rows[0]["FirstName"].ToString();
            Initial = table.Rows[0]["Initials"].ToString();
            LastName = table.Rows[0]["LastName"].ToString();
            SqlConn = sqlConn;
            IsEdit = false;

            // Set the form's start position to be centered relative to its parent
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormStorageAuthEntry"/> class for editing an existing record.
        /// </summary>
        /// <param name="row">DataRow containing the employee information.</param>
        /// <param name="sqlConn">SQL connection for database operations.</param>
        public FormStorageAuthEntry(DataRow row, SqlConnection sqlConn)
        {
            InitializeComponent();

            // Set the fields based on the data row
            BadgeNumber = row.Field<object>("Badge").ToString();
            CompletedBy = row.Field<object>("CompletedBy");  // Use object to handle possible nulls
            CompletedDate = row.Field<object>("CompletedDate"); // Use object to handle possible nulls
            DVD = row.Field<bool>("DVD");
            EmployeeID = row.Field<object>("ID").ToString();
            FirstName = row.Field<string>("First");
            Initial = row.Field<string>("Middle");
            LastName = row.Field<string>("Last");
            Reason = row.Field<object>("Reason");
            SignedDate = row.Field<object>("Date");
            SqlConn = sqlConn;
            USB = row.Field<bool>("USB");
            IsEdit = true;

            // Set the form's start position to be centered relative to its parent
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Handles the Load event of the EntryForm.
        /// Populates form controls with employee data and sets up initial control states.
        /// </summary>
        private void FormStorageAuthEntry_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            // Set control states
            dteCompletedDate.Enabled = false;
            txtBadgeNumber.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtInitial.ReadOnly = true;
            txtLastName.ReadOnly = true;

            PopulateFormFields(); // Populate the form fields with data

            // Set initial focus to the Reason text box
            txtReason.Focus();
        }      

        #region Control Methods

        /// <summary>
        /// Handles the Click event of the Cancel button.
        /// Closes the form without saving any data.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Close the form
        }

        /// <summary>
        /// Handles the Click event of the Save button.
        /// Verifies form data and writes the record to the database if valid.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validForm = VerifyFormData();
            if (validForm)
            {
                if (IsEdit)
                {
                    UpdateRecord(); // Update the record in the database
                }
                else
                {
                    WriteRecord(); // Save the record to the database
                }

                this.DialogResult = DialogResult.OK;
                this.Close(); // Close the form
            }
            else
            {
                MessageBox.Show("Please enter the required items."); // Show validation message
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the CompletedDate checkbox.
        /// Enables or disables the CompletedDate date picker based on the checkbox state.
        /// </summary>
        private void chkCompletedDate_CheckedChanged(object sender, EventArgs e)
        {
            dteCompletedDate.Enabled = chkCompletedDate.Checked; // Toggle the date picker's enabled state
        }

        /// <summary>
        /// Handles the TextChanged event of the Reason text box.
        /// Updates the character count label based on the current text length.
        /// </summary>
        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            int characterCount = 200 - txtReason.Text.Length;
            lblCharacters.Text = characterCount.ToString(); // Update the character count label
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Populates the CompletedBy combo box with employees from a specific department.
        /// </summary>
        private void PopulateCboCompletedBy()
        {
            string displayItem = "SAMAccountName"; // Display field in the combo box
            string query = " SELECT e.[ID], e.[SAMAccountName] " +
                           " FROM [Job] AS j INNER JOIN" +
                           "   [Employee] AS e ON j.[ID] = e.Job_ID INNER JOIN " +
                           "   [Department] AS d ON j.[Department_ID] = d.[ID] " +
                           " WHERE d.[ID] = '12' " +
                           "   AND e.[SAMAccountName] != '' " +
                           //"   AND e.[Active] = 1 " +
                           " ORDER BY [SAMAccountName];"; // SQL query to get the list of employees
            string valueItem = "ID"; // Value field in the combo box

            cboCompletedBy.Items.Clear();
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboCompletedBy, query, valueItem, displayItem, SqlConn);
            cboCompletedBy.SelectedIndex = -1; // Reset the selection
        }

        /// <summary>
        /// Populates the form controls with the data stored in the instance variables.
        /// </summary>
        private void PopulateFormFields()
        {
            // Populate the text boxes with employee data
            txtBadgeNumber.Text = BadgeNumber;
            txtFirstName.Text = FirstName;
            txtInitial.Text = Initial;
            txtLastName.Text = LastName;

            // Populate the USB and DVD checkboxes
            chkUSB.Checked = USB;
            chkDVD.Checked = DVD;

            // If SignedDate is not null, populate the respective control
            if (SignedDate != null && SignedDate != DBNull.Value)
            {
                dteSignedDate.Value = Convert.ToDateTime(SignedDate);
            }

            PopulateCboCompletedBy(); // Populate the CompletedBy combo box

            // If CompletedBy and CompletedDate are not null, populate the respective controls
            if (CompletedBy != null && CompletedBy != DBNull.Value)
            {
                string query = "SELECT [ID] FROM [Employee] WHERE [SAMAccountName] = '" + CompletedBy.ToString() + "';";
                DataTable table = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
                cboCompletedBy.SelectedValue = table.Rows[0]["ID"].ToString();
                chkCompletedDate.Checked = true;
                dteCompletedDate.Value = Convert.ToDateTime(CompletedDate);
            }
            else
            {
                chkCompletedDate.Checked = false;
            }

            if (Reason != null && Reason != DBNull.Value)
            {
                txtReason.Text = Reason.ToString();
            }
            else
            {
                txtReason.Text = string.Empty;
            }
        }

        /// <summary>
        /// Updates the record in the StorageAuth database table.
        /// </summary>
        private void UpdateRecord()
        {
            string query = "UPDATE [StorageAuth] " +
                           " SET  [SignedDate] = @SignedDate " +
                           "     ,[USB] = @USB " +
                           "     ,[DVD] = @DVD " +
                           "     ,[Reason] = @Reason " +
                           "     ,[CompletedBy] = @CompletedBy " +
                           "     ,[CompletedDate] = @CompletedDate " +
                           " WHERE [Employee_ID] = @EmployeeID;";

            // Determine the value for the 'Completed By' controls
            object completedBy = cboCompletedBy.SelectedValue;
            object completedDate = dteCompletedDate.Value;
            if (chkCompletedDate.Checked)
            {
                completedBy = cboCompletedBy.SelectedValue;
                completedDate = dteCompletedDate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                completedBy = DBNull.Value;
                completedDate = DBNull.Value;
            }

            using (SqlCommand command = new SqlCommand(query, SqlConn))
            {
                // Add parameters to the SQL command
                command.Parameters.AddWithValue("@SignedDate", dteSignedDate.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@USB", chkUSB.Checked);
                command.Parameters.AddWithValue("@DVD", chkDVD.Checked);
                command.Parameters.AddWithValue("@Reason", txtReason.Text);
                command.Parameters.AddWithValue("@CompletedBy", completedBy);
                command.Parameters.AddWithValue("@CompletedDate", completedDate);

                DatabaseMethods.CheckSqlConnectionState(SqlConn);

                // Execute the query to update the record
                command.ExecuteNonQuery();

                SqlConn.Close(); // Close the SQL connection
            }
        }
        
        /// <summary>
        /// Verifies that the form data meets the required validation criteria.
        /// </summary>
        /// <returns><c>true</c> if the form data is valid; otherwise, <c>false</c>.</returns>
        private bool VerifyFormData()
        {
            // Ensure at least one of the USB or DVD checkboxes is checked
            if (!chkUSB.Checked && !chkDVD.Checked)
            {
                return false;
            }
            // Ensure the reason text box has at least 5 characters
            if (txtReason.Text.Length < 5)
            {
                return false;
            }
            // If CompletedDate is checked, validate the completed date and combo box selection
            if (chkCompletedDate.Checked)
            {
                if (cboCompletedBy.SelectedIndex == -1 ||
                    dteCompletedDate.Value < dteSignedDate.Value ||
                    dteCompletedDate.Value > DateTime.Now)
                {
                    return false;
                }
            }

            return true; // All validations passed
        }
        
        /// <summary>
        /// Writes the form data as a new record in the StorageAuth database table.
        /// </summary>
        private void WriteRecord()
        {
            string query = "INSERT INTO [StorageAuth] " +
               " ([SignedDate], [Employee_ID], [USB], [DVD], [Reason], [CompletedBy], [CompletedDate]) " +
               "VALUES " +
               " (@SignedDate, @EmployeeID, @USB, @DVD, @Reason, @CompletedBy, @CompletedDate);";

            // Determine the value for the 'Completed By' controls
            object completedBy = cboCompletedBy.SelectedValue;
            object completedDate = dteCompletedDate.Value;
            if (chkCompletedDate.Checked)
            {
                completedBy = cboCompletedBy.SelectedValue;
                completedDate = dteCompletedDate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                completedBy = DBNull.Value;
                completedDate = DBNull.Value;
            }

            using (SqlCommand command = new SqlCommand(query, SqlConn))
            {
                // Add parameters to the SQL command
                command.Parameters.AddWithValue("@SignedDate", dteSignedDate.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@USB", chkUSB.Checked);
                command.Parameters.AddWithValue("@DVD", chkDVD.Checked);
                command.Parameters.AddWithValue("@Reason", txtReason.Text);
                command.Parameters.AddWithValue("@CompletedBy", completedBy);
                command.Parameters.AddWithValue("@CompletedDate", completedDate);

                DatabaseMethods.CheckSqlConnectionState(SqlConn);

                // Execute the query to insert the new record
                command.ExecuteNonQuery();

                SqlConn.Close(); // Close the SQL connection
            }
        }

        #endregion
    }
}

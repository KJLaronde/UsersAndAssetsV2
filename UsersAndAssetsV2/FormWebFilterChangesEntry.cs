using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    /// <summary>
    /// This form handles the entry and update of web filter changes for employees.
    /// It supports both creating new records and editing existing records based on 
    /// the data passed to it. The form operates in modal mode, and the changes are
    /// saved to the database upon successful validation.
    /// </summary>
    public partial class FormWebFilterChangesEntry : Form
    {
        private readonly string Comments;
        private readonly DateTime Date;
        private readonly string Description;
        private int EmployeeID;
        private readonly bool IsEdit;           // Indicates if the form is in edit mode
        private readonly int RecordID;
        private readonly SqlConnection SqlConn;

        /// <summary>
        /// Constructor for creating a new web filter change record.
        /// Initializes the form in 'new record' mode where the data fields are empty.
        /// </summary>
        /// <param name="sqlConn">SQL connection used for database operations.</param>
        public FormWebFilterChangesEntry(SqlConnection sqlConn)
        {
            InitializeComponent();

            Comments = string.Empty;
            Description = string.Empty;
            IsEdit = false;
            SqlConn = sqlConn;

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Constructor for editing an existing web filter change record.
        /// Initializes the form with data from the specified <see cref="DataRow"/>.
        /// </summary>
        /// <param name="row">DataRow containing the existing record's data.</param>
        /// <param name="sqlConn">SQL connection used for database operations.</param>
        public FormWebFilterChangesEntry(DataRow row, SqlConnection sqlConn)
        {
            InitializeComponent();

            var empIdValue = row["EmpID"]; // Retrieve the value

            Comments = row.Field<string>("Comments");
            Date = row.Field<DateTime>("Date");
            Description = row.Field<string>("Description");
            EmployeeID = Convert.ToInt32(row["EmpID"]);
            IsEdit = true;
            RecordID = row.Field<int>("ID");
            SqlConn = sqlConn;

            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Handles the form's Load event. Configures the initial state of the form, including 
        /// populating combo boxes, setting field limits, and loading existing data if in edit mode.
        /// </summary>
        private void FormWebFilterChangesEntry_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            PopulateCboEmployee();
            txtComments.MaxLength = 300;
            txtDescription.MaxLength = 300;

            if (IsEdit) PopulateFormFields();
        }

        /// <summary>
        /// Event handler for the Cancel button. Cancels the operation and closes the form.
        /// Sets the dialog result to <see cref="DialogResult.Cancel"/>.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Event handler for the Save button click. Validates form data and either updates 
        /// or inserts the record in the database depending on whether the form is in edit mode.
        /// Closes the form with <see cref="DialogResult.OK"/> if validation passes.
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
        /// Resets the selection of the employee combo box when the dropdown is opened.
        /// </summary>
        private void cboEmployee_DropDown(object sender, EventArgs e)
        {
            cboEmployee.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler that is triggered when the employee combo box dropdown is closed.
        /// If an employee is selected, this method updates the EmployeeID field with the selected value.
        /// </summary>
        /// <param name="sender">The source of the event, typically the combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown close event.</param>
        private void cboEmployee_DropDownClosed(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedIndex != -1)
            {
                EmployeeID = Convert.ToInt32(cboEmployee.SelectedValue);
            }
        }

        /// <summary>
        /// Updates the character count label as the user types in the comments text box.
        /// The character count is displayed with a maximum of 300 characters.
        /// </summary>
        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            int characterCount = 300 - txtComments.Text.Length;
            lblCommentsCount.Text = characterCount.ToString();
        }

        /// <summary>
        /// Updates the character count label as the user types in the description text box.
        /// The character count is displayed with a maximum of 300 characters.
        /// </summary>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int characterCount = 300 - txtDescription.Text.Length;
            lblDescriptionCount.Text = characterCount.ToString();
        }

        /// <summary>
        /// Executes a given SQL query with specified parameters, opening and closing 
        /// the SQL connection within the method. This method handles parameter setting via an action delegate.
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="setParameters">Action that adds necessary SQL parameters to the command.</param>
        private void ExecuteNonQuery(string query, Action<SqlCommand> setParameters)
        {
            using (SqlCommand command = new SqlCommand(query, SqlConn))
            {
                setParameters(command);
                SqlConn.Open();
                command.ExecuteNonQuery();
                SqlConn.Close();
            }
        }

        /// <summary>
        /// Populates the employee combo box with active employees from a specific department (ID 12).
        /// If no employees are available, an error message is displayed.
        /// </summary>
        private void PopulateCboEmployee()
        {
            string displayItem = "EmployeeName"; // Display field in the combo box
            string query = @" 
                SELECT e.[ID], CONCAT(e.[FirstName], ' ', e.[LastName]) AS 'EmployeeName' 
                FROM [Job] AS j INNER JOIN 
                    [Employee] AS e ON j.[ID] = e.Job_ID INNER JOIN 
                    [Department] AS d ON j.[Department_ID] = d.[ID] 
                WHERE d.[ID] = '12' 
                    AND e.[Active] = 1 
                ORDER BY [EmployeeName];"; // SQL query to get the list of employees
            string valueItem = "ID"; // Value field in the combo box

            cboEmployee.Items.Clear();
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboEmployee, query, valueItem, displayItem, SqlConn);

            // Debug: Check if ComboBox is being populated
            if (cboEmployee.Items.Count == 0)
            {
                MessageBox.Show("Employee ComboBox not populated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cboEmployee.SelectedIndex = -1; // Reset the selection
        }

        /// <summary>
        /// Populates the form fields with the data from the current record when in edit mode.
        /// This includes setting the employee, comment, description, and date fields.
        /// </summary>
        private void PopulateFormFields()
        {
            if (IsEdit)
            {
                // Populate the comment text box
                txtComments.Text = Comments;

                // Populate the description text box
                txtDescription.Text = Description;

                // Populate the date field (assuming dteEntryDate is a DateTimePicker)
                dteEntryDate.Value = Date;

                // Find and select the employee in the combo box
                cboEmployee.SelectedValue = EmployeeID.ToString();
            }
        }

        /// <summary>
        /// Updates an existing web filter change record in the database using the data from the form fields.
        /// This includes updating the employee ID, date, description, and comments.
        /// </summary>
        private void UpdateRecord()
        {
            string query = @"
                UPDATE [WebFilterChanges] 
                SET [Employee_ID] = @EmployeeID 
                   ,[Date] = @Date 
                   ,[Description] = @Description 
                   ,[Comments] = @Comments 
                WHERE [ID] = @RecordID";

            object entryDate = dteEntryDate.Value.ToString("yyyy-MM-dd");

            try
            {
                ExecuteNonQuery(query, command =>
                {
                    command.Parameters.AddWithValue("@Comments", txtComments.Text);
                    command.Parameters.AddWithValue("@Date", entryDate);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    if (IsEdit) command.Parameters.AddWithValue("@RecordID", RecordID);
                });
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConn?.Close();
            }
        }

        /// <summary>
        /// Validates the form fields before saving or updating the record. 
        /// Ensures that the employee is selected, description and comments are not empty, 
        /// and the date is valid (not in the future).
        /// </summary>
        /// <returns>True if the form data is valid, otherwise false.</returns>
        private bool VerifyFormData()
        {
            // 1. Check if an employee is selected
            if (cboEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmployee.Focus(); // Set focus back to the employee combo box
                return false;
            }

            // 2. Check if the description field is not empty
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus(); // Set focus back to the description text box
                return false;
            }

            // 3. Check if the comment field is not empty
            if (string.IsNullOrWhiteSpace(txtComments.Text))
            {
                MessageBox.Show("Comments cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComments.Focus(); // Set focus back to the comments text box
                return false;
            }

            // 4. Check if the selected date is valid (optional, based on business rules)
            if (dteEntryDate.Value == null || dteEntryDate.Value > DateTime.Now)
            {
                MessageBox.Show("Please select a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dteEntryDate.Focus(); // Set focus back to the date picker
                return false;
            }

            // If all checks pass, return true
            return true;
        }

        /// <summary>
        /// Inserts a new web filter change record into the database using the data from the form fields.
        /// This includes adding the employee ID, date, description, and comments.
        /// </summary>
        private void WriteRecord()
        {
            string query = @"
                INSERT INTO [WebFilterChanges] 
                    ([Employee_ID], [Date], [Description], [Comments])
                VALUES
                    (@EmployeeID, @Date, @Description, @Comments);";

            object entryDate = dteEntryDate.Value.ToString("yyyy-MM-dd");

            try
            {
                ExecuteNonQuery(query, command =>
                {
                    command.Parameters.AddWithValue("@Comments", txtComments.Text);
                    command.Parameters.AddWithValue("@Date", entryDate);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    if (IsEdit) command.Parameters.AddWithValue("@RecordID", RecordID);
                });
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConn?.Close();
            }
        }
    }
}

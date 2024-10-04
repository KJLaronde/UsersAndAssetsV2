using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    /// <summary>
    /// The main form for managing storage authorizations in the application.
    /// </summary>
    public partial class FormStorageAuth : Form
    { 
        // Readonly field for SQL connection
        private readonly SqlConnection SqlConn;
        private new readonly FormMain Parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormStorageAuth"/> class.
        /// Establishes the SQL connection and initializes the form components.
        /// </summary>
        public FormStorageAuth(FormMain formMain)
        {
            Parent = formMain;
            SqlConn = Parent.SqlConn;

            this.StartPosition = FormStartPosition.CenterParent;

            InitializeComponent();
            
            grdHistory.CellDoubleClick += grdHistory_CellDoubleClick;
        }

        /// <summary>
        /// Handles the Load event of the main form.
        /// Clears the form and populates the employee combo box when the form is loaded.
        /// </summary>
        private void FormStorageAuth_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            ClearForm(); // Reset the form controls
            PopulateCboEmployee(); // Load the employee list into the combo box
        }

        #region Hide the closing 'X'

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #endregion
     
        #region Control Methods

        /// <summary>
        /// Handles the Click event of the Clear button.
        /// Resets the form controls to their default state.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        /// <summary>
        /// Handles the Click event of the Close button.
        /// Closes the form and opens its parent.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the New button.
        /// Opens a new entry form for the selected employee.
        /// After the entry form is closed, refreshes the data grid.
        /// </summary>
        private void btnNew_Click(object sender, EventArgs e)
        {
            int employeeID = Convert.ToInt32(cboEmployee.SelectedValue);
            string query = $@"
                SELECT [ID], [BadgeNumber], [FirstName], [Initials], [LastName] 
                FROM [Employee] 
                WHERE [ID] = '{employeeID}';";

            if (employeeID > 0)
            {
                DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
                using (FormStorageAuthEntry frmEntry = new FormStorageAuthEntry(dataTable, SqlConn))
                {
                    if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                    {
                        PopulateDataGrid(employeeID); // Refresh the data grid after closing the form
                    }
                }
            }
        }

        /// <summary>
        /// Handles the DropDown event of the Employee combo box.
        /// Clears the form and resets the combo box selection when the dropdown opens.
        /// </summary>
        private void cboEmployee_DropDown(object sender, EventArgs e)
        {
            btnClear_Click(sender, e); // Clear the form
            cboEmployee.SelectedIndex = -1; // Reset the selection
        }

        /// <summary>
        /// Handles the DropDownClosed event of the Employee combo box.
        /// Enables controls and populates the data grid based on the selected employee.
        /// </summary>
        private void cboEmployee_DropDownClosed(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedIndex != -1 || cboEmployee.Text.Length > 0)
            {
                grpButtons.Enabled = true;
                pnlSearch.Enabled = true;
                PopulateDataGrid(Convert.ToInt32(cboEmployee.SelectedValue));
                cboEmployee.Focus();
            }
            else
            {
                ClearForm(); // Reset the form if no employee is selected
            }
        }

        /// <summary>
        /// Handles the Enter event of the Employee combo box.
        /// Simulates closing the dropdown to trigger data grid population if needed.
        /// </summary>
        private void cboEmployee_Enter(object sender, EventArgs e) => cboEmployee_DropDownClosed(sender, e);

        /// <summary>
        /// Handles the KeyDown event of the Employee combo box.
        /// Triggers the DropDownClosed logic when the Enter key is pressed.
        /// </summary>
        private void cboEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key was pressed...
            if (e.KeyCode == Keys.Enter)
            {
                cboEmployee_DropDownClosed(sender, e); // Trigger the dropdown closed logic
            }
        }

        /// <summary>
        /// Handles the Leave event of the cboEmployee ComboBox. 
        /// Ensures that the dropdown is closed when the ComboBox loses focus, 
        /// and triggers the DropDownClosed event manually to handle any related logic.
        /// </summary>
        private void cboEmployee_Leave(object sender, EventArgs e)
        {
            cboEmployee.DroppedDown = false;
            cboEmployee_DropDownClosed(sender, e);
        }

        /// <summary>
        /// Handles the CellDoubleClick event of the grdHistory DataGridView.
        /// Opens an EntryForm to edit the details of the selected record when a row is double-clicked.
        /// </summary>
        private void grdHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid (not a header or out of bounds)
            if (e.RowIndex >= 0)
            {
                // Retrieve the selected row
                DataGridViewRow selectedRow = grdHistory.Rows[e.RowIndex];

                // Extract data from the selected row
                DataTable dt = (DataTable)grdHistory.DataSource;
                DataRow row = dt.Rows[e.RowIndex];
                using (FormStorageAuthEntry frmEntry = new FormStorageAuthEntry(row, SqlConn))
                {
                    if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                    {
                        int employeeID = Convert.ToInt32(cboEmployee.SelectedValue);
                        PopulateDataGrid(employeeID); // Refresh the data grid after closing the form
                    }
                }
            }
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Resets the form controls to their default state.
        /// </summary>
        private void ClearForm()
        {
            cboEmployee.SelectedIndex = -1; // Clear the employee selection
            grpButtons.Enabled = false; // Disable the buttons group
            grdHistory.DataSource = null; // Clear the data grid
            pnlSearch.Enabled = false; // Disable the search panel
            cboEmployee.Focus(); // Set focus to the employee combo box
        }

        /// <summary>
        /// Populates the Employee combo box with a list of employees from the database.
        /// </summary>
        private void PopulateCboEmployee()
        {
            string query = @"
                SELECT [ID], CONCAT([LastName], ', ', [FirstName], ' ', [Initials]) AS 'Employee' 
                FROM [Employee] ORDER BY 'Employee';"; 
            string valueItem = "ID"; // Value field for the combo box
            string displayItem = "Employee"; // Display field for the combo box

            cboEmployee.Items.Clear(); // Clear existing items
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboEmployee, query, valueItem, displayItem, SqlConn);
            cboEmployee.SelectedIndex = -1; // Reset the selection
        }

        /// <summary>
        /// Populates the data grid with the history of storage authorizations for the selected employee.
        /// </summary>
        /// <param name="employeeID">The ID of the selected employee.</param>
        private void PopulateDataGrid(int employeeID)
        {
            string query = $@"
                SELECT e.[ID]
                    , s.[SignedDate] AS 'Date'
                    , e.[LastName] AS 'Last'
                    , e.[FirstName] AS 'First'  
                    , e.[Initials] AS 'Middle'
                    , e.[BadgeNumber] AS 'Badge'
                    , s.[USB]
                    , s.[DVD]
                    , s.[CompletedDate]
                    ,  (SELECT e2.[SAMAccountName] 
                        FROM [Employee] AS e2 
                        WHERE e2.[ID] = s.[CompletedBy]) AS 'CompletedBy' 
                    , s.[Reason] 
                FROM [Employee] AS e INNER JOIN 
                     [StorageAuth] AS s ON s.[Employee_ID] = e.[ID] 
                WHERE e.[ID] = {employeeID} 
                ORDER BY s.[SignedDate];";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            pnlSearch.Controls.Add(grdHistory); // Add the data grid to the search panel
            grdHistory.DataSource = dataTable; // Bind the data grid to the data table
            grdHistory.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; // Set header style
            grdHistory.AutoResizeColumns(); // Auto-resize the columns
            grdHistory.Columns[0].Visible = false; // Hide the ID column
            grdHistory.ScrollBars = ScrollBars.Both; // Enable both scroll bars
        }

        #endregion
    }
}

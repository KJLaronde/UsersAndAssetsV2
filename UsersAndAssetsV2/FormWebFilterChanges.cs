using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormWebFilterChanges : Form
    {
        private readonly SqlConnection SqlConn;
        private new readonly FormMain Parent;

        /// <summary>
        /// Initializes a new instance of the FormWebFilterChanges class.
        /// Sets the parent form and SQL connection, initializes the form, and sets the icon and start position.
        /// </summary>
        /// <param name="formMain">The parent form (FormMain) from which this form is opened.</param>
        public FormWebFilterChanges(FormMain formMain)
        {
            Parent = formMain;
            SqlConn = Parent.SqlConn;

            InitializeComponent();
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Handles the form's load event. Sets the icon and start position, and populates the data grid with records.
        /// </summary>
        /// <param name="sender">The source of the event (the form).</param>
        /// <param name="e">Event arguments associated with the form load event.</param>
        private void FormWebFilterChanges_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            PopulateDataGrid();
        }

        #region Hide the closing 'X'

        /// <summary>
        /// Overrides the CreateParams to hide the form's close button ('X') in the window.
        /// </summary>
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

        /// <summary>
        /// Handles the close button click event. Closes the current form and shows the parent form (FormMain).
        /// </summary>
        /// <param name="sender">The source of the event (the Close button).</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the "New" button click event. Opens a new modal form to create a new web filter change record.
        /// If a new record is added, refreshes the data grid.
        /// </summary>
        /// <param name="sender">The source of the event (the New button).</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            using (FormWebFilterChangesEntry frmEntry = new FormWebFilterChangesEntry(SqlConn))
            {
                if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                {
                    PopulateDataGrid(); // Refresh the data grid after closing the form
                }
            }
        }

        /// <summary>
        /// Handles the cell double-click event on the data grid. Opens the selected web filter change record for editing.
        /// If the record is updated, refreshes the data grid.
        /// </summary>
        /// <param name="sender">The source of the event (the data grid).</param>
        /// <param name="e">Event arguments for the cell double-click event.</param>
        private void grdRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid (not a header or out of bounds)
            if (e.RowIndex >= 0)
            {
                // Retrieve the selected row
                DataGridViewRow selectedRow = grdRecords.Rows[e.RowIndex];

                // Extract data from the selected row
                DataTable dt = (DataTable)grdRecords.DataSource;
                DataRow row = dt.Rows[e.RowIndex];
                using (FormWebFilterChangesEntry frmEntry = new FormWebFilterChangesEntry(row, SqlConn))
                {
                    if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                    {
                        PopulateDataGrid(); // Refresh the data grid after closing the form
                    }
                }
            }
        }

        /// <summary>
        /// Populates the data grid with web filter change records from the database.
        /// Retrieves records from the WebFilterChanges table and binds the data to the data grid.
        /// </summary>
        private void PopulateDataGrid()
        {
            string query = @"
                SELECT w.[ID]
                      ,w.[Employee_ID] AS 'EmpID'
                      ,w.[Date]
                      ,CONCAT(e.[FirstName], ' ', e.[LastName]) AS 'Employee'
                      ,w.[Description]
                      ,w.[Comments]
                FROM [WebFilterChanges] AS w INNER JOIN 
                    [Employee] AS e ON w.[Employee_ID] = e.[ID]
                ORDER BY w.[Date];";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            pnlRecords.Controls.Add(grdRecords); // Add the data grid to the search panel
            grdRecords.DataSource = dataTable; // Bind the data grid to the data table
            grdRecords.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; // Set header style
            grdRecords.AutoResizeColumns(); // Auto-resize the columns
            grdRecords.Columns[0].Visible = false; // Hide the ID column
            grdRecords.Columns[1].Visible = false; // Hide the Employee ID column
            grdRecords.ScrollBars = ScrollBars.Both; // Enable both scroll bars
        }
    }
}

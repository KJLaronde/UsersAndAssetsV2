using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    /// <summary>
    /// Represents the form used for managing YubiKey data, including listing, editing, and creating new YubiKey records.
    /// </summary>
    public partial class FormYubiKeys : Form
    {
        private new readonly FormMain Parent;
        private readonly int SiteLocationID;
        private readonly SqlConnection SqlConn;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormYubiKeys"/> class.
        /// </summary>
        /// <param name="formMain">The parent form that launched this form.</param>
        public FormYubiKeys(FormMain formMain)
        {
            Parent = formMain;
            SiteLocationID = Parent.SiteLocationID;
            SqlConn = Parent.SqlConn;

            InitializeComponent();
        }

        /// <summary>
        /// Handles the form's load event and populates the data grid with YubiKey records.
        /// </summary>
        private void FormYubiKeys_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        #region Hide the closing 'X'

        /// <summary>
        /// Overrides the form's creation parameters to disable the close button (the 'X' button).
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
        /// Handles the click event for the Close button. Closes the current form and returns to the parent form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        /// <summary>
        /// Populates the data grid with YubiKey records from the database.
        /// Removes unnecessary columns and adjusts the layout of the grid.
        /// </summary>
        private void PopulateDataGrid()
        {
            string query = @"
                SELECT y.[ID]
                     , d.[ID] AS 'DeptID'
                     , a.[ID] AS 'AssetID'
                     , y.[SerialNumber] AS 'Serial'
                     , y.[PublicID]
                     , a.[Description] AS 'Type'
                     , d.[Name] AS 'Department'
                FROM [AssetType] AS a INNER JOIN
                     [YubiKey] AS y ON a.ID = y.[AssetType_ID] INNER JOIN
                     [Department] AS d ON y.[Department_ID] = d.[ID]
                ORDER BY y.[SerialNumber];";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            pnlYubikeys.Controls.Add(grdYubiKeys); // Add the data grid to the search panel
            grdYubiKeys.DataSource = dataTable; // Bind the data grid to the data table
            grdYubiKeys.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; // Set header style
            grdYubiKeys.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Automatically adjust to fit content
            grdYubiKeys.AutoResizeColumns(); // Auto-resize the columns

            // Remove the ID columns from the grid
            if (grdYubiKeys.Columns.Contains("ID"))
            {
                grdYubiKeys.Columns.Remove("ID"); // Remove the ID column
            }
            if (grdYubiKeys.Columns.Contains("DeptID"))
            {
                grdYubiKeys.Columns.Remove("DeptID"); // Remove the DeptID column
            }
            if (grdYubiKeys.Columns.Contains("AssetID"))
            {
                grdYubiKeys.Columns.Remove("AssetID"); // Remove the AssetID column
            }

            grdYubiKeys.ScrollBars = ScrollBars.Both; // Enable both scroll bars
        }

        /// <summary>
        /// Handles the event when a YubiKey record is double-clicked in the data grid. 
        /// Opens the YubiKey entry form for editing the selected record.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Contains the row index of the clicked cell.</param>
        private void grdYubiKeys_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid (not a header or out of bounds)
            if (e.RowIndex >= 0)
            {
                // Extract data from the selected row
                DataTable dt = (DataTable)grdYubiKeys.DataSource;
                DataRow row = dt.Rows[e.RowIndex];
                using (FormYubiKeysEntry frmEntry = new FormYubiKeysEntry(row, SqlConn))
                {
                    if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                    {
                        PopulateDataGrid(); // Refresh the data grid after closing the form
                    }
                }
            }
        }

        /// <summary>
        /// Handles the event when the "New" button is clicked. 
        /// Opens the YubiKey entry form for creating a new record.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments associated with the click event.</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            using (FormYubiKeysEntry frmEntry = new FormYubiKeysEntry(SqlConn))
            {
                if (frmEntry.ShowDialog(this) == DialogResult.OK) // Wait for the modal form to close
                {
                    PopulateDataGrid(); // Refresh the data grid after closing the form
                }
            }
        }
    }
}

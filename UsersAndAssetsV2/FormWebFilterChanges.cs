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

        public FormWebFilterChanges(FormMain formMain)
        {
            Parent = formMain;
            SqlConn = Parent.SqlConn;

            InitializeComponent();
        }

        private void FormWebFilterChanges_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            PopulateDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

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

        private void PopulateDataGrid()
        {
            string query = @"
                SELECT w.[ID]
                     , w.[Date]
                     , CONCAT(e.[FirstName], ' ', e.[LastName]) AS 'Employee'
                     , w.[Description]
                     , w.[Comments]
                FROM [WebFilterChanges] AS w INNER JOIN 
                    [Employee] AS e ON w.[Employee_ID] = e.[ID]
                ORDER BY w.[Date];";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            pnlRecords.Controls.Add(grdRecords); // Add the data grid to the search panel
            grdRecords.DataSource = dataTable; // Bind the data grid to the data table
            grdRecords.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; // Set header style
            grdRecords.AutoResizeColumns(); // Auto-resize the columns
            grdRecords.Columns[0].Visible = false; // Hide the ID column
            grdRecords.ScrollBars = ScrollBars.Both; // Enable both scroll bars
        }
    }
}

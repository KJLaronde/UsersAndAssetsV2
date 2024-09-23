using SharedMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormYubiKeys : Form
    {
        private new readonly FormMain Parent;
        private readonly int SiteLocationID;
        private readonly SqlConnection SqlConn;

        public FormYubiKeys(FormMain formMain)
        {
            Parent = formMain;
            SiteLocationID = Parent.SiteLocationID;
            SqlConn = Parent.SqlConn;

            InitializeComponent();

            // Set the form's start position to be centered relative to its parent
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FormYubiKeys_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        private void PopulateDataGrid()
        {
            string query = @"
                SELECT y.ID
                     , y.SerialNumber AS 'Serial'
                     , y.PublicID
                     , a.[Description] AS 'Type'
                     , d.[Name] AS 'Department'
                FROM AssetType AS a INNER JOIN
                     YubiKey AS y ON a.ID = y.AssetType_ID INNER JOIN
                     Department AS d ON y.Department_ID = d.ID
                ORDER BY y.[SerialNumber];";

            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            pnlYubikeys.Controls.Add(grdYubiKeys); // Add the data grid to the search panel
            grdYubiKeys.DataSource = dataTable; // Bind the data grid to the data table
            grdYubiKeys.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; // Set header style
            grdYubiKeys.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Automatically adjust to fit content
            grdYubiKeys.AutoResizeColumns(); // Auto-resize the columns

            // Remove the ID column completely from the grid
            if (grdYubiKeys.Columns.Count > 0)
            {
                grdYubiKeys.Columns.RemoveAt(0); // Remove the first column (ID)
            }

            grdYubiKeys.ScrollBars = ScrollBars.Both; // Enable both scroll bars
        }

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

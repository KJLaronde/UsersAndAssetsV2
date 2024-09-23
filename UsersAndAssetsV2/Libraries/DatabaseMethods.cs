using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SharedMethods
{
    public static class DatabaseMethods
    {
        public static DataTable ConvertToDataTable(List<string> data)
        {
            DataTable dataTable = new DataTable();

            // Add a single column to the DataTable
            dataTable.Columns.Add("Column1");

            // Add rows to the DataTable
            if (data != null)
            {
                foreach (var item in data)
                {
                    DataRow row = dataTable.NewRow();
                    row[0] = item; 
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
        public static DataTable ConvertToDataTable(List<Dictionary<string, object>> data)
        {
            DataTable dataTable = new DataTable();

            if (data == null || data.Count == 0)
                return dataTable;

            // Add columns to the DataTable
            foreach (var key in data[0].Keys)
            {
                dataTable.Columns.Add(key);
            }

            // Add rows to the DataTable
            foreach (var dict in data)
            {
                DataRow row = dataTable.NewRow();
                foreach (var key in dict.Keys)
                {
                    row[key] = dict[key] ?? DBNull.Value; // Handle null values
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        public static DataTable QueryDatabaseForDataTable(string query, SqlConnection sqlConnection) 
        {
            CheckSqlConnectionState(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            sqlConnection.Close();

            return dataTable;
        }
        public static List<string> QueryDatabaseForList(string query, SqlConnection sqlConnection) 
        {
            CheckSqlConnectionState(sqlConnection);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<string> resultingList = new List<string>();

            while (reader.Read())
            {
                resultingList.Add(reader.GetString(0));
            }
            reader.Close();
            sqlConnection.Close();

            return resultingList;
        }
        public static void CheckSqlConnectionState(SqlConnection sqlConnection) 
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        public static void ExecuteNonQuery(string query, SqlConnection sqlConnection) 
        {
            CheckSqlConnectionState(sqlConnection);
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }
        public static void ExportDataTableToExcel(DataTable dataTable, string defaultFileName = "DataExport.xlsx")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Save Excel File",
                FileName = defaultFileName  // Set the default filename
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                if (!string.IsNullOrEmpty(filename))
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(dataTable, "Data");
                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(filename);
                    }
                }
            }
        }
        public static void OpenDataTableInExcel(DataTable dataTable)
        {
            // Define a temporary file path
            string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");

            // Export the DataTable to an Excel file
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(dataTable, "Data");
                workbook.SaveAs(tempFile);
            }

            // Open the Excel file using the default application
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = tempFile,
                UseShellExecute = true
            });
        }
        
        public static void PopulateComboBoxUsingDataReader(ComboBox comboBox, string query, SqlConnection sqlConnection) 
        {
            /// <summary>
            /// This method populates a combo box directly using a list of items 
            /// returned from a database query. (Only the first column is assigned 
            /// to the ComboBox.)
            /// </summary>
            try
            {
                CheckSqlConnectionState(sqlConnection);

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(sqlDataReader[0].ToString());
                }

                sqlDataReader.Close();
                sqlConnection.Close();
                comboBox.SelectedIndex = -1;
            }
            catch (Exception err)
            {
                CommonMethods.DisplayError(err.Message);
            }
        }
        public static void PopulateComboBoxUsingObjectFields(ComboBox comboBox, string query, string valueItem, string displayItem, SqlConnection sqlConnection) 
        {
            /// <summary>
            /// This method uses an object (CboItems) containing two fields (Value, Display) 
            /// that are used to populate the corresponding properties of the ComboBox
            /// passed.
            /// </summary>
            DataTable dataTable = QueryDatabaseForDataTable(query, sqlConnection);
            var dataSource = new List<CboItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                dataSource.Add(new CboItem() { Value = row[valueItem].ToString(), Display = row[displayItem].ToString() });
            }
            //comboBox.ValueMember = "Value";
            //comboBox.DisplayMember = "Display";
            comboBox.DataSource = dataSource;
            comboBox.SelectedIndex = -1;
        }
        public static void PrintDataTable(DataTable dataTable)
        {
            try
            {
                // Define a temporary file path
                string tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".xlsx");

                // Export the DataTable to an Excel file
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(dataTable, "Data");
                    worksheet.Columns().AdjustToContents(); // Autofit columns
                    workbook.SaveAs(tempFile);
                }

                // Open the Excel file and print it using Interop
                var excelApp = new Excel.Application();
                excelApp.Visible = false;
                var workbookInterop = excelApp.Workbooks.Open(tempFile);
                var worksheetInterop = workbookInterop.Worksheets[1];

                worksheetInterop.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                worksheetInterop.PageSetup.FitToPagesWide = 1;
                worksheetInterop.PageSetup.Zoom = false;
                worksheetInterop.PrintOutEx();

                // Cleanup
                workbookInterop.Close(false);
                excelApp.Quit();
                Marshal.ReleaseComObject(worksheetInterop);
                Marshal.ReleaseComObject(workbookInterop);
                Marshal.ReleaseComObject(excelApp);

                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
        }

        public static void TestForDbNullInCheckBox(CheckBox checkBox, object value) 
        {
            var temp = value;
            if (temp != DBNull.Value)
                checkBox.Checked = Convert.ToBoolean(value);
            else
                checkBox.Checked = false;
        }
        public static void TestForDBNullInComboBox(ComboBox comboBox, object value) 
        {
            var temp = value;
            if (temp != DBNull.Value)
                comboBox.SelectedValue = Convert.ToString(temp);
            else
                comboBox.SelectedIndex = -1;
        }
        public static void TestForDbNullInDateTimePicker(DateTimePicker dateTimePicker, object value) 
        {
            var temp = value;
            if (temp != DBNull.Value)
                dateTimePicker.Value = Convert.ToDateTime(temp);
            else
                dateTimePicker.Value = DateTime.Now;
        }
        public static void TestForDBNullInTextbox(TextBox textBox, object value) 
        {
            var temp = value;
            if (temp != DBNull.Value)
                textBox.Text = Convert.ToString(temp);
            else
                textBox.Text = null;
        }
        public static void WriteDatabaseRecord(string query, SqlConnection sqlConnection) 
        {
            try
            {
                ExecuteNonQuery(query, sqlConnection);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "WriteDatabaseRecord");
            }
        }
    }
}

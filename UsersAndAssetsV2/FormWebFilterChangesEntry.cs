using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormWebFilterChangesEntry : Form
    {
        private readonly string Comment;
        private readonly object Date;
        private readonly string Description;
        private readonly int EmployeeID;
        private readonly string EmployeeName;
        private readonly bool IsEdit;           // Indicates if the form is in edit mode
        private readonly int RecordID;
        private readonly SqlConnection SqlConn; // SQL connection used for database operations

        public FormWebFilterChangesEntry(SqlConnection sqlConn)
        {
            InitializeComponent();

            IsEdit = false;
            SqlConn = sqlConn; 
        }

        public FormWebFilterChangesEntry(DataRow row, SqlConnection sqlConn)
        {
            InitializeComponent();

            Comment = row.Field<object>("Comment").ToString(); 
            Date = row.Field<object>("Date"); 
            Description = row.Field<object>("Description").ToString(); 
            EmployeeName = row.Field<object>("Employee").ToString();
            IsEdit = true;
            RecordID = (int)row.Field<object>("ID");
            SqlConn = sqlConn;
        }

        private void FormWebFilterChangesEntry_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            PopulateCboEmployee();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }

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

        private void cboEmployee_DropDown(object sender, EventArgs e)
        {
            cboEmployee.SelectedIndex = -1;
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            int characterCount = 300 - txtComments.Text.Length;
            lblCommentsCount.Text = characterCount.ToString();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            int characterCount = 300 - txtDescription.Text.Length;
            lblDescriptionCount.Text = characterCount.ToString();
        }

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
            cboEmployee.SelectedIndex = -1; // Reset the selection
        }

        private void PopulateFormFields() { }

        private void UpdateRecord() 
        {
            string query = @"
                UPDATE [WebFilterChanges] 
                SET  [Employee_ID] = @EmployeeID 
                    ,[Date] = '@Date' 
                    ,[Description] = '@Description' 
                    ,[Comment] = '@Comment' 
                WHERE [ID] = @RecordID";

            object entryDate = dteEntryDate.Value.ToString("yyyy-MM-dd");

            using (SqlCommand command = new SqlCommand(query, SqlConn))
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Comment", txtComments.Text);
                command.Parameters.AddWithValue("@Date", entryDate);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("@RecordID", RecordID);

                SqlConn.Open();
                command.ExecuteNonQuery();
                SqlConn.Close();
            }
        }
        
        private bool VerifyFormData() { return true; }
        
        private void WriteRecord() 
        {
            
        }
    }
}

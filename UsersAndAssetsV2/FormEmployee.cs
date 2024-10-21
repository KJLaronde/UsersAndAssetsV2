using ExtensionsMethods;
using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormEmployee : Form
    {
        #region Fields and Properties

        private new readonly FormMain Parent;
        private readonly SqlConnection SqlConnection;
        private readonly int SiteLocationID;
        private readonly string SiteName;

        bool active;
        bool emailArchived;
        bool emailHidden;
        bool temporary;
        DateTime? archiveDate;
        DateTime? endDate;
        DateTime positionStartDate;
        DateTime startDate;
        int accountTypeID;
        int? badgeNumber;
        int? dualJobID;
        int? employeeID;
        int jobID;
        int? longDistanceCode;
        long? phoneExtension;
        short? phoneRank;
        string firstName;
        string initials;
        string lastName;
        string samAccountName;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FormEmployee"/> class.
        /// </summary>
        /// <param name="formMain">The parent form which contains main application data and connections.</param>
        public FormEmployee(FormMain formMain)
        {
            InitializeComponent();
            Parent = formMain;
            SiteLocationID = Parent.SiteLocationID;
            SiteName = Parent.SiteName;
            SqlConnection = Parent.SqlConn;
        }

        /// <summary>
        /// Handles the load event of the <see cref="FormEmployee"/> form. 
        /// Initializes the form's UI elements and populates initial data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Text = $"Users and Assets - {SiteName}";
            pnlUserInfo.Enabled = false;
            pnlADUser.Enabled = false;
            txtBadgeNumber.MaxLength = 5;

            // Populate the two Department combo boxes
            string valueItem = "ID";
            string displayItem = "Name";
            string query = " SELECT DISTINCT [ID], [Name] FROM [Department] ORDER BY [Name]; ";
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboDepartment, query, valueItem, displayItem, SqlConnection);
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboDualDepartment, query, valueItem, displayItem, SqlConnection);

            SetDefaultDateTimePickerFormat();
            PopulateCboNameSearch();
            ClearForm();
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

        #region Buttons

        /// <summary>
        /// Event handler for the Add Employee button click event. 
        /// Enables the user information panel, clears the form fields, and resets the name search combo box.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Add Employee button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            pnlUserInfo.Enabled = true;
            ClearForm();
            cboNameSearch.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the Close button click event.
        /// Shows the parent form and closes the current form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Close button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        /// <summary>
        /// Event handler for the New Asset button click event.
        /// Opens the <see cref="FormAssets"/> dialog to add a new asset, and refreshes the assigned assets panel.
        /// </summary>
        /// <param name="sender">The source of the event, typically the New Asset button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnNewAsset_Click(object sender, EventArgs e)
        {
            FormAssets form = new FormAssets(SiteName, SiteLocationID, SqlConnection);
            _ = form.ShowDialog();

            // Refresh the panel
            PopulatePnlAssignedAssets();
        }

        /// <summary>
        /// Event handler for the New Permission button click event.
        /// Opens a modal form to add a new permission for the selected employee, and refreshes the permission changes panel.
        /// </summary>
        /// <param name="sender">The source of the event, typically the New Permission button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnNewPermission_Click(object sender, EventArgs e)
        {
            FormEmployeePermissionEntry form = new FormEmployeePermissionEntry("new", Parent, (int)employeeID);
            var dialogResult = form.ShowDialog();
            PopulatePnlPermissionChanges();
        }

        /// <summary>
        /// Event handler for the Save button click event.
        /// Verifies the data and creates a new database record if no employee is selected from the name search combo box,
        /// or updates the existing record if an employee is selected. 
        /// After saving, clears the form, disables the user panels, and repopulates the name search combo box.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Save button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (VerifyData())
            {
                if (employeeID == null)
                {
                    // Create a new record if no employee is selected from the name search combo box
                    CreateDatabaseRecord();
                }
                else
                {
                    // Update the existing record if an employee is being edited
                    UpdateDatabaseRecord();
                }

                ClearForm();
                pnlADUser.Enabled = false;
                pnlUserInfo.Enabled = false;
                PopulateCboNameSearch();
            }
        } 

        #endregion

        #region ComboBoxes

        /// <summary>
        /// Event handler for the department combo box dropdown event. 
        /// Resets the selected index of the department combo box to -1 when the dropdown is opened, 
        /// clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            cboDepartment.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the department combo box dropdown closed event. 
        /// Populates the job positions combo box based on the selected department.
        /// </summary>
        /// <param name="sender">The source of the event, typically the department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown close event.</param>
        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            PopulateJobs(cboJobPosition, cboDepartment);
        }

        /// <summary>
        /// Event handler for the dual department combo box dropdown event. 
        /// Resets the selected index of the dual department combo box to -1 when the dropdown is opened, 
        /// clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the dual department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboDualDepartment_DropDown(object sender, EventArgs e)
        {
            cboDualDepartment.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the dual department combo box dropdown closed event. 
        /// Populates the dual job positions combo box based on the selected dual department.
        /// </summary>
        /// <param name="sender">The source of the event, typically the dual department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown close event.</param>
        private void cboDualDepartment_DropDownClosed(object sender, EventArgs e)
        {
            PopulateJobs(cboDualJobPosition, cboDualDepartment);
        }

        /// <summary>
        /// Event handler for the dual job position combo box dropdown event. 
        /// Resets the selected index of the dual job position combo box to -1 when the dropdown is opened, 
        /// clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the dual job position combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboDualJobPosition_DropDown(object sender, EventArgs e)
        {
            cboDualJobPosition.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the job position combo box dropdown event. 
        /// Resets the selected index of the job position combo box to -1 when the dropdown is opened, 
        /// clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the job position combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboJobPosition_DropDown(object sender, EventArgs e)
        {
            cboJobPosition.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the name search combo box dropdown event. 
        /// Resets the selected index of the name search combo box to -1 when the dropdown is opened, 
        /// clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the name search combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboNameSearch_DropDown(object sender, EventArgs e)
        {
            cboNameSearch.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the name search combo box dropdown closed event. 
        /// Clears the form if no name is selected, otherwise populates the form based on the selected name.
        /// </summary>
        /// <param name="sender">The source of the event, typically the name search combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown close event.</param>
        private void cboNameSearch_DropDownClosed(object sender, EventArgs e)
        {
            if (cboNameSearch.SelectedIndex < 0)
                ClearForm();
            else
                PopulateForm();
        }

        /// <summary>
        /// Event handler for the key down event in the name search combo box. 
        /// If the Enter key is pressed, triggers the dropdown closed event to either clear or populate the form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the name search combo box.</param>
        /// <param name="e">Event arguments associated with the key down event.</param>
        private void cboNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key was pressed...
            if (e.KeyCode == Keys.Enter)
            {
                cboNameSearch_DropDownClosed(sender, e);
            }
        }

        #endregion

        #region CheckBoxes

        /// <summary>
        /// Event handler for the Active checkbox state change event. 
        /// When the checkbox is checked and the SAM account name has more than 3 characters, 
        /// it populates the Active Directory user panel using the SAM account name.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Active checkbox.</param>
        /// <param name="e">Event arguments associated with the checkbox state change event.</param>
        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            string name = txtSamAccountName.Text;
            if (chkActive.Checked && name.Length > 3)
            {
                PopulatePnlAdUser(name);
            }
        }

        /// <summary>
        /// Event handler for the Archive Date checkbox state change event. 
        /// Enables or disables the archive date picker based on the checkbox state.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Archive Date checkbox.</param>
        /// <param name="e">Event arguments associated with the checkbox state change event.</param>
        private void chkArchiveDate_CheckedChanged(object sender, EventArgs e) => dteArchiveDate.Enabled = chkArchiveDate.Checked;

        /// <summary>
        /// Event handler for the End Date checkbox state change event. 
        /// Enables or disables the end date picker based on the checkbox state.
        /// </summary>
        /// <param name="sender">The source of the event, typically the End Date checkbox.</param>
        /// <param name="e">Event arguments associated with the checkbox state change event.</param>
        private void chkEndDate_CheckedChanged(object sender, EventArgs e) => dteEndDate.Enabled = chkEndDate.Checked;

        #endregion

        #region GridViews

        /// <summary>
        /// Event handler for the double-click event on the assigned assets grid. 
        /// Opens the <see cref="FormAssets"/> dialog to view or edit the selected asset based on its asset number,
        /// then refreshes the assigned assets panel.
        /// </summary>
        /// <param name="sender">The source of the event, typically the assigned assets grid.</param>
        /// <param name="e">Event arguments associated with the cell double-click event, 
        /// providing information about the clicked cell.</param>
        private void grdAssignedAssets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string assetNumber = Convert.ToString(grdAssignedAssets[0, e.RowIndex].Value);
            FormAssets form = new FormAssets(SiteName, SiteLocationID, SqlConnection, assetNumber);
            _ = form.ShowDialog();

            // Refresh the panel
            PopulatePnlAssignedAssets();
        }

        /// <summary>
        /// Event handler for the double-click event on the permission changes grid. 
        /// Opens the <see cref="FormEmployeePermissionEntry"/> dialog to view or edit the selected permission record, 
        /// then refreshes the permission changes panel.
        /// </summary>
        /// <param name="sender">The source of the event, typically the permission changes grid.</param>
        /// <param name="e">Event arguments associated with the cell double-click event, 
        /// providing information about the clicked cell.</param>
        private void grdPermissionChanges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            long recordID = Convert.ToInt64(grdPermissionChanges[0, e.RowIndex].Value);
            using (FormEmployeePermissionEntry form = new FormEmployeePermissionEntry("edit", Parent, (int)employeeID, recordID))
            {
                _ = form.ShowDialog();
            }

            // Refresh the panel
            PopulatePnlPermissionChanges();
        }

        #endregion

        #region TextBoxes

        /// <summary>
        /// Event handler for the leave event of the SAM account name text box. 
        /// When the user leaves the text box and a network login is entered for a new user (i.e., no name is selected in the name search combo box),
        /// it populates the Active Directory user panel based on the entered SAM account name.
        /// </summary>
        /// <param name="sender">The source of the event, typically the SAM account name text box.</param>
        /// <param name="e">Event arguments associated with the leave event.</param>
        private void txtSamAccountName_Leave(object sender, EventArgs e)
        {
            string name = txtSamAccountName.Text;
            // If a network login was entered for a new user...
            if (name.Length > 0 && cboNameSearch.SelectedIndex == -1)
            {
                PopulatePnlAdUser(name);
            }
        }

        #endregion

        #endregion Control Methods

        #region Private Methods

        #region Active Directory Operations

        /// <summary>
        /// Copies common information from the Active Directory user panel to the user information panel.
        /// </summary>
        private void CopyAdInfoToUserPanel()
        {
            // Copy common information from the AD panel to the user one
            chkActive.Checked = chkAD_Active.Checked;
            txtLastName.Text = txtAD_LastName.Text;
            txtFirstName.Text = txtAD_FirstName.Text;
            txtInitials.Text = txtAD_Initials.Text;
            txtExtension.Text = txtAD_Phone.Text;
            txtSamAccountName.Text = txtAD_SamAccountName.Text;
            cboJobPosition.Text = txtAD_Title.Text;
        }

        /// <summary>
        /// Populates the Active Directory user panel with data for the specified SAM account name.
        /// </summary>
        /// <param name="samAccountName">The SAM account name of the user to retrieve data for.</param>
        private void PopulatePnlAdUser(string samAccountName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "nation.ho-chunk.com", "DC=nation,DC=ho-chunk,DC=com"))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, samAccountName);

                    if (user != null)
                    {
                        PopulateAdControls(user);
                        CopyAdInfoToUserPanel();
                    }
                    else
                    {
                        ClearAllAdPanelControls();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Populates the user information panel with data from the database for the selected employee.
        /// </summary>
        private void PopulatePnlUserInfo()
        {
            try
            {
                string query = @"
                        SELECT E.BadgeNumber, E.FirstName, E.Initials, E.LastName, E.StartDate, E.PositionStartDate, 
                            E.EndDate, E.ArchiveDate, E.Temporary, E.PhoneExtension, E.LongDistanceCode, 
                            E.SAMAccountName, T.Description, E.EmailHidden, E.EmailArchived, E.PhoneRank, 
                            E.Active, E.Temporary, J.Department_ID AS 'Dept1', J.ID AS 'Job1', 
                            X.Department_ID AS 'Dept2', X.ID AS 'Job2'
                        FROM Employee AS E 
                            INNER JOIN AccountType AS T ON E.AccountType_ID = T.ID 
                            INNER JOIN Job AS J ON E.Job_ID = J.ID 
                            INNER JOIN Job AS X ON E.Job_ID_2 = X.ID 
                        WHERE E.ID = @EmployeeID";

                using (var cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    DatabaseMethods.CheckSqlConnectionState(SqlConnection);               
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Checkbox Fields
                            SetCheckBox(chkActive, reader, "Active");
                            SetCheckBox(chkEmailArchived, reader, "EmailArchived");
                            SetCheckBox(chkEmailHidden, reader, "EmailHidden");
                            SetCheckBox(chkTemporary, reader, "Temporary");

                            // DateTimePicker Fields
                            SetDateTimePicker(dteArchiveDate, reader, "ArchiveDate", chkArchiveDate);
                            SetDateTimePicker(dteEndDate, reader, "EndDate", chkEndDate);
                            dteHireDate.Value = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                            dtePositionStart.Value = reader.GetDateTime(reader.GetOrdinal("PositionStartDate"));

                            // TextBox Fields
                            SetTextBox(txtBadgeNumber, reader, "BadgeNumber");
                            SetTextBox(txtExtension, reader, "PhoneExtension");
                            SetTextBox(txtFirstName, reader, "FirstName");
                            SetTextBox(txtInitials, reader, "Initials");
                            SetTextBox(txtLastName, reader, "LastName");
                            SetTextBox(txtLDCode, reader, "LongDistanceCode");
                            SetTextBox(txtPhoneRank, reader, "PhoneRank");
                            SetTextBox(txtSamAccountName, reader, "SAMAccountName");

                            // ComboBox Fields
                            SetComboBox(cboDepartment, reader, "Dept1");
                            SetComboBox(cboDualDepartment, reader, "Dept2");

                            // Populate Job ComboBoxes based on selected Departments
                            PopulateJobs(cboJobPosition, cboDepartment);
                            PopulateJobs(cboDualJobPosition, cboDualDepartment);
                            SetComboBox(cboJobPosition, reader, "Job1");
                            SetComboBox(cboDualJobPosition, reader, "Job2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }

            pnlUserInfo.Enabled = true;
        }

        #endregion

        #region Database Operations

        /// <summary>
        /// Creates a new employee record in the database based on the current form data.
        /// </summary>
        private void CreateDatabaseRecord()
        {
            string query = @"
                INSERT INTO [Employee] (
                    [BadgeNumber], [FirstName], [Initials], [LastName], [Job_ID], [Job_ID_2],
                    [StartDate], [PositionStartDate], [EndDate], [ArchiveDate], [Temporary],
                    [PhoneExtension], [LongDistanceCode], [AccountType_ID], [SAMAccountName],
                    [EmailHidden], [EmailArchived], [PhoneRank], [SiteLocation_ID], [Active]
                ) VALUES (
                    @BadgeNumber, @FirstName, @Initials, @LastName, @JobID, @DualJobID, 
                    @StartDate, @PositionStartDate, @EndDate, @ArchiveDate, @Temporary,
                    @PhoneExtension, @LongDistanceCode, @AccountTypeID, @SamAccountName, 
                    @EmailHidden, @EmailArchived, @PhoneRank, @SiteLocationID, @Active
                );";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@BadgeNumber", badgeNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FirstName", firstName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Initials", initials ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastName", lastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@JobID", jobID);
                    cmd.Parameters.AddWithValue("@DualJobID", dualJobID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@PositionStartDate", positionStartDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ArchiveDate", archiveDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Temporary", temporary ? 1 : 0);
                    cmd.Parameters.AddWithValue("@PhoneExtension", phoneExtension ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LongDistanceCode", longDistanceCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountTypeID", accountTypeID);
                    cmd.Parameters.AddWithValue("@SamAccountName", samAccountName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmailHidden", emailHidden ? 1 : 0);
                    cmd.Parameters.AddWithValue("@EmailArchived", emailArchived ? 1 : 0);
                    cmd.Parameters.AddWithValue("@PhoneRank", phoneRank ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SiteLocationID", SiteLocationID);
                    cmd.Parameters.AddWithValue("@Active", active ? 1 : 0);

                    // Execute the query
                    DatabaseMethods.CheckSqlConnectionState(SqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// Populates the name search combo box with employee names from the database.
        /// </summary>
        private void PopulateCboNameSearch()
        {
            string query = @"
                SELECT [ID], CONCAT([LastName], ', ', [FirstName], ' ', [Initials]) AS 'Employee' 
                FROM [Employee]
                ORDER BY [Employee]";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@SiteLocationID", SiteLocationID);

                    SqlConnection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        BindComboBox(cboNameSearch, dataTable, "ID", "Employee");
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }

            cboNameSearch.SelectedIndex = -1;
        }

        /// <summary>
        /// Populates the form with employee data based on the selected employee in the search combo box.
        /// </summary>
        private void PopulateForm()
        {
            try
            {
                ClearForm();
                employeeID = GetSelectedEmployeeID();
                if (employeeID == null)
                {
                    CommonMethods.DisplayError("Invalid employee selected.");
                    return;
                }

                PopulatePnlUserInfo();
                PopulateActiveDirectoryInfo();
                PopulatePnlAssignedAssets();
                PopulatePnlPermissionChanges();
                EnableUserPnlControls();
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Populates the job titles available in the given department combo box.
        /// </summary>
        /// <param name="jobComboBox">The combo box to populate with job titles.</param>
        /// <param name="deptComboBox">The department combo box used to filter the job titles.</param>
        private void PopulateJobs(ComboBox jobComboBox, ComboBox deptComboBox)
        {
            if (deptComboBox.SelectedValue.ToString() == String.Empty)
            {
                ClearComboBox(jobComboBox);
                return;
            }

            string query = @"
                SELECT [ID], [Title] 
                FROM [Job] 
                WHERE [Department_ID] = @DeptID 
                ORDER BY [Title]";

            string deptID = deptComboBox.SelectedValue.ToString();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(SqlConnection.ConnectionString))
                {
                    DatabaseMethods.CheckSqlConnectionState(sqlConnection);

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@DeptID", deptID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            BindComboBox(jobComboBox, dataTable, "ID", "Title");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }

            jobComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Populates the panel with assigned assets for the selected employee from the database.
        /// </summary>
        private void PopulatePnlAssignedAssets()
        {
            string query = @"
                SELECT A.ID, 
                    A.Number AS 'Asset', 
                    A.NetworkName AS 'AD Name', 
                    T.Description AS 'Asset Type', 
                    M.Name AS 'Mfg', 
                    L.Description AS 'Model', 
                    A.SerialNumber AS 'Serial', 
                    Loc.Name AS 'Location' 
                FROM Asset AS A 
                    INNER JOIN AssetType AS T ON A.AssetType_ID = T.ID 
                    INNER JOIN AssetLocation AS Loc ON A.AssetLocation_ID = Loc.ID 
                    INNER JOIN Manufacturer AS M ON A.Manufacturer_ID = M.ID 
                    INNER JOIN Model AS L ON A.Model_ID = L.ID 
                WHERE A.Employee_ID = @EmployeeID 
                ORDER BY A.Number";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    SqlConnection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    SetupAssignedAssetsGrid(dataTable);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// Populates the panel with permission change records for the selected employee from the database.
        /// </summary>
        private void PopulatePnlPermissionChanges()
        {
            string query = @"
                SELECT [P].[ID] AS 'Record', 
                    [P].[DateOfChange] AS 'Date', 
                    [P].[ADName] AS 'AD Name', 
                    [D].[Name] AS 'Document', 
                    CONCAT([E].[FirstName], ' ', [E].[LastName]) AS 'Requestor', 
                    [A].[Name] AS 'Application', 
                    [P].[Comments] 
                FROM [PermissionChange] AS P 
                    INNER JOIN [Application] AS A ON [P].[Application_ID] = [A].[ID] 
                    INNER JOIN [Document] AS D ON [P].[Document_ID] = [D].[ID] 
                    INNER JOIN [Employee] AS E ON [P].[Employee_ID] = [E].[ID] 
                WHERE [P].[UserID] = @EmployeeID 
                ORDER BY [P].[ID] DESC";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    SqlConnection.Open();

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    SetupPermissionChangesGrid(dataTable);
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// Updates the existing employee record in the database with the current form data.
        /// </summary>
        private void UpdateDatabaseRecord()
        {
            try
            {
                // Convert True or False entries into bits
                int activeBit = active ? 1 : 0;
                int emailArchivedBit = emailArchived ? 1 : 0;
                int emailHiddenBit = emailHidden ? 1 : 0;
                int temporaryBit = temporary ? 1 : 0;

                // Prepare the query with parameters
                string query = @"
                    UPDATE [Employee] SET
                        [BadgeNumber] = @BadgeNumber,
                        [FirstName] = @FirstName,
                        [Initials] = @Initials,
                        [LastName] = @LastName,
                        [Job_ID] = @JobID,
                        [Job_ID_2] = @DualJobID,
                        [StartDate] = @StartDate,
                        [PositionStartDate] = @PositionStartDate,
                        [Temporary] = @Temporary,
                        [AccountType_ID] = @AccountTypeID,
                        [SAMAccountName] = @SamAccountName,
                        [EmailHidden] = @EmailHidden,
                        [EmailArchived] = @EmailArchived,
                        [SiteLocation_ID] = @SiteLocationID,
                        [Active] = @Active,
                        [EndDate] = @EndDate,
                        [ArchiveDate] = @ArchiveDate,
                        [PhoneExtension] = @PhoneExtension,
                        [PhoneRank] = @PhoneRank,
                        [LongDistanceCode] = @LongDistanceCode
                    WHERE [ID] = @EmployeeID";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@BadgeNumber", badgeNumber);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@Initials", initials);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@JobID", jobID);
                    cmd.Parameters.AddWithValue("@DualJobID", dualJobID);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@PositionStartDate", positionStartDate);
                    cmd.Parameters.AddWithValue("@Temporary", temporaryBit);
                    cmd.Parameters.AddWithValue("@AccountTypeID", accountTypeID);
                    cmd.Parameters.AddWithValue("@SamAccountName", samAccountName);
                    cmd.Parameters.AddWithValue("@EmailHidden", emailHiddenBit);
                    cmd.Parameters.AddWithValue("@EmailArchived", emailArchivedBit);
                    cmd.Parameters.AddWithValue("@SiteLocationID", SiteLocationID);
                    cmd.Parameters.AddWithValue("@Active", activeBit);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    // Handle nullable values
                    cmd.Parameters.AddWithValue("@EndDate", chkEndDate.Checked && !chkActive.Checked ? (object)endDate : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ArchiveDate", chkArchiveDate.Checked && !chkActive.Checked ? (object)archiveDate : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneExtension", phoneExtension > 1 ? (object)phoneExtension : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneRank", phoneRank > 1 ? (object)phoneRank : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LongDistanceCode", longDistanceCode > 1 ? (object)longDistanceCode : DBNull.Value);

                    // Execute the query
                    DatabaseMethods.CheckSqlConnectionState(SqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
                return;
            }
            finally
            {
                SqlConnection?.Close();
            }
        }
        
        #endregion

        #region Utility Methods

        /// <summary>
        /// Clears the data source of a <see cref="ComboBox"/> and resets its selection.
        /// </summary>
        /// <param name="comboBox">The combo box to clear.</param>
        private void ClearComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = null;
        }

        /// <summary>
        /// Clears all input fields on the form and resets the form to its initial state.
        /// </summary>
        private void ClearForm()
        {
            ClearAllUserInfoPanelControls();
            ClearAllAdPanelControls();
            pnlAssignedAssets.Controls.Clear();
            pnlPermissionChanges.Controls.Clear();
            tabEmployeeData.Focus();
            ReinitializeVariables();
        }

        /// <summary>
        /// Creates a temporary file with the specified data and file extension.
        /// </summary>
        /// <param name="data">The byte array containing the file data.</param>
        /// <param name="extension">The file extension to use for the temporary file.</param>
        /// <returns>The path to the created temporary file.</returns>
        private string CreateTempFile(byte[] data, string extension)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), "MyAppTempFiles");
            Directory.CreateDirectory(tempDirectory);

            string tempFilePath = Path.Combine(tempDirectory, Guid.NewGuid().ToString() + extension);
            File.WriteAllBytes(tempFilePath, data);

            return tempFilePath;
        }

        /// <summary>
        /// Deletes a temporary file from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the file to be deleted.</param>
        private void DeleteTempFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError($"Error deleting temp file: {ex.Message}");
            }
        }

        /// <summary>
        /// Enables all controls within the user information panel and triggers associated events to ensure consistency.
        /// </summary>
        private void EnableUserPnlControls()
        {
            EnableControlsRecursive(pnlUserInfo);

            // Trigger the necessary events after enabling controls
            chkEndDate_CheckedChanged(this, null);
            chkArchiveDate_CheckedChanged(this, null);
        }

        /// <summary>
        /// Opens the specified file using the default system application for that file type.
        /// </summary>
        /// <param name="filePath">The path to the file to be opened.</param>
        private void OpenFile(string filePath)
        {
            Process process = Process.Start(filePath);
            process?.WaitForExit(); // Wait for the user to close the file
        }

        /// <summary>
        /// Opens an attachment stored as a byte array, displaying it as a PDF file.
        /// </summary>
        /// <param name="attachment">The byte array containing the attachment data.</param>
        private void OpenGridViewRecordAttachment(byte[] attachment)
        {
            if (attachment == null || attachment.Length == 0)
            {
                CommonMethods.DisplayError("Attachment is empty or null.");
                return;
            }

            string tempFilePath = null;

            try
            {
                tempFilePath = CreateTempFile(attachment, ".pdf");
                OpenFile(tempFilePath);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally
            {
                DeleteTempFile(tempFilePath);
            }
        }

        /// <summary>
        /// Reinitializes all employee-related variables to their default values.
        /// </summary>
        private void ReinitializeVariables()
        {
            employeeID = null;
            badgeNumber = null;
            firstName = null;
            initials = null;
            lastName = null;
            jobID = 1;
            dualJobID = 1;
            positionStartDate = DateTime.Now;
            startDate = DateTime.Now;
            endDate = null;
            archiveDate = null;
            temporary = false;
            phoneExtension = null;
            longDistanceCode = null;
            accountTypeID = 1;
            samAccountName = null;
            emailHidden = false;
            emailArchived = false;
            phoneRank = null;
            active = true;
        }
        
        #endregion

        #region Validation Methods

        /// <summary>
        /// Validates the badge number input to ensure it meets the required criteria and checks if it already exists in the database.
        /// </summary>
        /// <param name="badgeNumberText">The badge number as a string.</param>
        /// <returns><c>true</c> if the badge number is valid and does not already exist; otherwise, <c>false</c>.</returns>
        private bool ValidateBadgeNumber(string badgeNumberText)
        {
            // Check if the badge number is valid
            if (badgeNumberText.Length < 6 && int.TryParse(badgeNumberText, out int resultBadgeNum))
            {
                // Check if the badge number already exists in the database
                string query = "SELECT COUNT(*) FROM Employee WHERE BadgeNumber = @BadgeNumber AND ID != @EmployeeID";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                    {
                        // Ensure we're not counting the currently loaded employee's badge number
                        cmd.Parameters.AddWithValue("@BadgeNumber", resultBadgeNum);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID ?? (object)DBNull.Value);

                        SqlConnection.Open();

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("The Badge Number already exists for another employee.", "Input Error");
                            txtBadgeNumber.Focus();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while checking the Badge Number: {ex.Message}", "Database Error");
                    return false;
                }
                finally
                {
                    SqlConnection.Close();
                }

                badgeNumber = resultBadgeNum;
                return true;
            }
            else
            {
                MessageBox.Show("The Badge Number is invalid.", "Input Error");
                txtBadgeNumber.Focus();
                return false;
            }
        }


        /// <summary>
        /// Validates the initials input to ensure it meets the required criteria.
        /// </summary>
        /// <param name="textBox">The text box containing the initials input.</param>
        /// <param name="initials">The validated initials as an output parameter.</param>
        /// <returns><c>true</c> if the initials are valid; otherwise, <c>false</c>.</returns>
        private bool ValidateInitials(TextBox textBox, out string initials)
        {
            initials = textBox.Text.Trim().ToUpper();
            if (!Regex.IsMatch(initials, @"\d") && initials.Length <= 3)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The Initials are invalid.", "Input Error");
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Validates the selected job position in the combo box to ensure it meets the required criteria.
        /// </summary>
        /// <param name="comboBox">The combo box containing the job position selection.</param>
        /// <param name="fieldName">The name of the field being validated (for error messages).</param>
        /// <param name="allowNone">If set to <c>true</c>, allows no selection (job ID = 1).</param>
        /// <returns>The validated job ID, or <c>0</c> if validation fails.</returns>
        private int ValidateJobPosition(ComboBox comboBox, string fieldName, bool allowNone = false)
        {
            int jobID = Convert.ToInt32(comboBox.SelectedValue);
            if (jobID > 1 || (allowNone && jobID == 1))
            {
                return jobID;
            }
            else
            {
                CommonMethods.DisplayError($"You must select a {fieldName}.", "Input Error");
                return 0;
            }
        }

        /// <summary>
        /// Validates the name input to ensure it meets the required criteria.
        /// </summary>
        /// <param name="textBox">The text box containing the name input.</param>
        /// <param name="name">The validated name as an output parameter.</param>
        /// <param name="fieldName">The name of the field being validated (for error messages).</param>
        /// <returns><c>true</c> if the name is valid; otherwise, <c>false</c>.</returns>
        private bool ValidateName(TextBox textBox, out string name, string fieldName)
        {
            name = textBox.Text.Trim();
            if (!Regex.IsMatch(name, @"\d") && name.Length > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"The {fieldName} is invalid.", "Input Error");
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Validates a numeric input field to ensure it meets the required length and value criteria.
        /// </summary>
        /// <param name="textBox">The text box containing the numeric input.</param>
        /// <param name="minLength">The minimum allowed length of the input.</param>
        /// <param name="maxLength">The maximum allowed length of the input.</param>
        /// <param name="fieldName">The name of the field being validated (for error messages).</param>
        /// <returns>The validated numeric value, or <c>null</c> if validation fails.</returns>
        private short? ValidateNumericField(TextBox textBox, int minLength, int maxLength, string fieldName)
        {
            if (textBox.Text.Length >= minLength && textBox.Text.Length <= maxLength && short.TryParse(textBox.Text, out short result))
            {
                return result;
            }
            else if (textBox.Text.Length == 0)
            {
                return null;
            }
            else
            {
                MessageBox.Show($"The {fieldName} is invalid.", "Input Error");
                textBox.Focus();
                return null;
            }
        }

        /// <summary>
        /// Validates the data entered in the form to ensure all required fields are correct and consistent.
        /// </summary>
        /// <returns><c>true</c> if the data is valid; otherwise, <c>false</c>.</returns>
        private bool VerifyData()
        {
            try
            {
                // Various checkboxes
                active = chkActive.Checked;
                emailArchived = chkEmailArchived.Checked;
                emailHidden = chkEmailHidden.Checked;
                temporary = chkTemporary.Checked;

                // Account Type
                accountTypeID = 1;

                // Nullable DateTime fields
                archiveDate = chkArchiveDate.Checked ? (DateTime?)dteArchiveDate.Value : null;
                endDate = chkEndDate.Checked ? (DateTime?)dteEndDate.Value : null;

                // Badge Number Validation
                if (!ValidateBadgeNumber(txtBadgeNumber.Text))
                    return false;

                // Name Validations
                if (!ValidateName(txtFirstName, out firstName, "First Name"))
                    return false;

                if (!ValidateInitials(txtInitials, out initials))
                    return false;

                if (!ValidateName(txtLastName, out lastName, "Last Name"))
                    return false;

                // Job Validations
                jobID = ValidateJobPosition(cboJobPosition, "primary department and job title");
                if (jobID == 0) return false;

                dualJobID = ValidateJobPosition(cboDualJobPosition, "Job2", allowNone: true);

                // Long Distance Code Validation
                longDistanceCode = ValidateNumericField(txtLDCode, 4, 5, "Long Distance Code");

                // Phone Extension Validation
                phoneExtension = ValidateNumericField(txtExtension, 5, 5, "Phone Extension");

                // Phone Rank Validation
                phoneRank = ValidateNumericField(txtPhoneRank, 1, 3, "Phone Rank");

                // SAM Account Name
                samAccountName = txtSamAccountName.Text.Length > 0 ? txtSamAccountName.Text : null;

                // Start Dates Validation
                positionStartDate = dtePositionStart.Value;
                startDate = dteHireDate.Value;
                if (startDate > positionStartDate)
                {
                    CommonMethods.DisplayError("The Hire Date cannot come after the Position Start Date.", "Input Error");
                    dteHireDate.Focus();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Binds a <see cref="ComboBox"/> to a data source using specified value and display members.
        /// </summary>
        /// <param name="comboBox">The combo box to bind.</param>
        /// <param name="dataTable">The data source to bind to the combo box.</param>
        /// <param name="valueMember">The property to use as the value member.</param>
        /// <param name="displayMember">The property to use as the display member.</param>
        private void BindComboBox(ComboBox comboBox, DataTable dataTable, string valueMember, string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
        }

        /// <summary>
        /// Clears all text boxes in the Active Directory user panel and resets checkboxes to their default states.
        /// </summary>
        private void ClearAllAdPanelControls()
        {
            // Clear out all of the textboxes on the AD panel
            var allTextBoxes = pnlADUser.GetChildControls<TextBox>();
            foreach (TextBox textbox in allTextBoxes)
            {
                textbox.Text = String.Empty;
            }
            chkAD_Active.Checked = false;
            chkAD_Hidden.Checked = false;
        }

        /// <summary>
        /// Clears and resets all controls in the user information panel, including text boxes, combo boxes, and checkboxes.
        /// </summary>
        private void ClearAllUserInfoPanelControls()
        {
            foreach (Control control in pnlUserInfo.Controls)
            {
                switch (control)
                {
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        checkBox.Enabled = true;
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedIndex = -1;
                        comboBox.Enabled = true;
                        break;
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        textBox.Enabled = true;
                        break;
                }
            }

            // Set the DateTimePickers individually and then disable them
            // HireDate must precede PositionStart
            dteHireDate.Value = DateTime.Now;
            dtePositionStart.Value = DateTime.Now;
            dteEndDate.Value = DateTime.Now;
            dteArchiveDate.Value = DateTime.Now;

            dteHireDate.Enabled = true;
            dtePositionStart.Enabled = true;
            dteEndDate.Enabled = true;
            dteArchiveDate.Enabled = true;
        }

        /// <summary>
        /// Recursively enables all relevant controls within a parent control.
        /// </summary>
        /// <param name="parent">The parent control containing child controls to be enabled.</param>
        private void EnableControlsRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                switch (control)
                {
                    case CheckBox _:
                    case ComboBox _:
                    case TextBox _:
                    case DateTimePicker _:
                        control.Enabled = true;
                        break;
                }

                // Recursively enable controls in nested containers
                if (control.HasChildren)
                {
                    EnableControlsRecursive(control);
                }
            }
        }

        /// <summary>
        /// Retrieves the selected employee's ID from the name search combo box.
        /// </summary>
        /// <returns>The employee ID if valid; otherwise, <c>null</c>.</returns>
        private int? GetSelectedEmployeeID()
        {
            if (int.TryParse(cboNameSearch.SelectedValue?.ToString(), out int id))
            {
                return id;
            }
            return null;
        }

        /// <summary>
        /// Populates the Active Directory user panel with information based on the entered SAM account name.
        /// </summary>
        private void PopulateActiveDirectoryInfo()
        {
            string samAccount = txtSamAccountName.Text;
            if (!string.IsNullOrWhiteSpace(samAccount) && samAccount.Length > 3)
            {
                PopulatePnlAdUser(samAccount);
            }
        }

        /// <summary>
        /// Populates the Active Directory user panel controls with data from a <see cref="UserPrincipal"/> object.
        /// </summary>
        /// <param name="user">The <see cref="UserPrincipal"/> containing the user's Active Directory data.</param>
        private void PopulateAdControls(UserPrincipal user)
        {
            SetTextBox(txtAD_City, user, "l");
            SetTextBox(txtAD_Company, user, "company");
            SetTextBox(txtAD_CreateTimestamp, user, "whenCreated");
            SetTextBox(txtAD_Department, user, "department");
            SetTextBox(txtAD_Description, user, "description");
            SetTextBox(txtAD_DisplayName, user, "displayName");
            SetTextBox(txtAD_Drive, user, "homeDrive");
            SetTextBox(txtAD_EmailAddress, user, "mail");
            SetTextBox(txtAD_FirstName, user, "givenName");
            SetTextBox(txtAD_Initials, user, "initials");
            SetTextBox(txtAD_LastLogonTimestamp, user.LastLogon?.ToString());
            SetTextBox(txtAD_LastName, user, "sn");
            SetTextBox(txtAD_DriveLocation, user, "homeDirectory");
            SetTextBox(txtAD_ModifyTimestamp, user, "whenChanged");
            SetTextBox(txtAD_Office, user, "physicalDeliveryOfficeName");
            SetTextBox(txtAD_Phone, user, "telephoneNumber");
            SetTextBox(txtAD_SamAccountName, user, "samAccountName");
            SetTextBox(txtAD_SID, user.GetIDProperty("objectSid"));
            SetTextBox(txtAD_State, user, "st");
            SetTextBox(txtAD_StreetAddress, user, "streetAddress");
            SetTextBox(txtAD_Title, user, "title");
            SetTextBox(txtAD_UserAccountControl, user, "userAccountControl");
            SetTextBox(txtAD_ZipCode, user, "postalCode");
            chkAD_Active.Checked = user.Enabled.GetValueOrDefault();
        }

        /// <summary>
        /// Recursively sets the custom date format for all <see cref="DateTimePicker"/> controls within a specified panel.
        /// If there are nested panels or containers, it applies the format to their <see cref="DateTimePicker"/> controls as well.
        /// </summary>
        /// <param name="panel">The parent panel containing the controls.</param>
        /// <param name="format">The custom date format string to apply to all <see cref="DateTimePicker"/> controls.</param>
        private void SetDateTimePickerFormatInPanel(Panel panel, string format)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.CustomFormat = format;
                }

                // Handle nested controls if necessary
                if (control.HasChildren)
                {
                    SetDateTimePickerFormatInPanel((Panel)control, format);
                }
            }
        }

        /// <summary>
        /// Sets the default date format for all <see cref="DateTimePicker"/> controls in the user and AD panels.
        /// </summary>
        private void SetDefaultDateTimePickerFormat()
        {
            string format = "MM/dd/yyyy";

            // Process both panels in a single method
            SetDateTimePickerFormatInPanel(pnlUserInfo, format);
            SetDateTimePickerFormatInPanel(pnlADUser, format);
        }

        /// <summary>
        /// Sets the state of a <see cref="CheckBox"/> based on a database column value.
        /// </summary>
        /// <param name="checkBox">The check box to set.</param>
        /// <param name="reader">The <see cref="SqlDataReader"/> containing the data.</param>
        /// <param name="columnName">The name of the column containing the check box value.</param>
        private void SetCheckBox(CheckBox checkBox, SqlDataReader reader, string columnName)
        {
            checkBox.Checked = reader[columnName] != DBNull.Value && (bool)reader[columnName];
        }

        /// <summary>
        /// Sets the selected value of a <see cref="ComboBox"/> based on a database column value.
        /// </summary>
        /// <param name="comboBox">The combo box to set.</param>
        /// <param name="reader">The <see cref="SqlDataReader"/> containing the data.</param>
        /// <param name="columnName">The name of the column containing the combo box value.</param>
        private void SetComboBox(ComboBox comboBox, SqlDataReader reader, string columnName)
        {
            comboBox.SelectedValue = reader[columnName] != DBNull.Value ? reader[columnName].ToString() : String.Empty;
        }

        /// <summary>
        /// Sets the value of a <see cref="DateTimePicker"/> based on a database column value, optionally linking it to a check box.
        /// </summary>
        /// <param name="dateTimePicker">The date time picker to set.</param>
        /// <param name="reader">The <see cref="SqlDataReader"/> containing the data.</param>
        /// <param name="columnName">The name of the column containing the date value.</param>
        /// <param name="linkedCheckBox">An optional check box to enable or disable based on the date value.</param>
        private void SetDateTimePicker(DateTimePicker dateTimePicker, SqlDataReader reader, string columnName, CheckBox linkedCheckBox = null)
        {
            if (reader[columnName] != DBNull.Value)
            {
                dateTimePicker.Value = (DateTime)reader[columnName];
                if (linkedCheckBox != null) linkedCheckBox.Checked = true;
            }
            else
            {
                if (linkedCheckBox != null) linkedCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Sets the text of a <see cref="TextBox"/> based on a database column value.
        /// </summary>
        /// <param name="textBox">The text box to set.</param>
        /// <param name="reader">The <see cref="SqlDataReader"/> containing the data.</param>
        /// <param name="columnName">The name of the column containing the text value.</param>
        private void SetTextBox(TextBox textBox, SqlDataReader reader, string columnName)
        {
            textBox.Text = reader[columnName] != DBNull.Value ? reader[columnName].ToString() : string.Empty;
        }

        /// <summary>
        /// Sets the text of a <see cref="TextBox"/> based on a property value from a <see cref="UserPrincipal"/> object.
        /// </summary>
        /// <param name="textBox">The text box to set.</param>
        /// <param name="user">The <see cref="UserPrincipal"/> containing the property value.</param>
        /// <param name="propertyName">The name of the property containing the text value.</param>
        private void SetTextBox(TextBox textBox, UserPrincipal user, string propertyName)
        {
            textBox.Text = user.GetProperty(propertyName) ?? string.Empty;
        }

        /// <summary>
        /// Sets the text of a <see cref="TextBox"/> based on a provided string value.
        /// </summary>
        /// <param name="textBox">The text box to set.</param>
        /// <param name="value">The string value to set in the text box.</param>
        private void SetTextBox(TextBox textBox, string value)
        {
            textBox.Text = value ?? string.Empty;
        }

        /// <summary>
        /// Configures the assigned assets grid with data from the provided <see cref="DataTable"/>.
        /// </summary>
        /// <param name="dataTable">The data table containing the assigned assets data.</param>
        private void SetupAssignedAssetsGrid(DataTable dataTable)
        {
            pnlAssignedAssets.Controls.Clear(); // Clear any previous controls
            pnlAssignedAssets.Controls.Add(grdAssignedAssets);
            pnlAssignedAssets.Controls.Add(btnNewAsset);

            grdAssignedAssets.DataSource = dataTable;
            grdAssignedAssets.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grdAssignedAssets.Columns[0].Visible = false; // Hide the ID column
            grdAssignedAssets.AutoResizeColumns();
            grdAssignedAssets.ScrollBars = ScrollBars.Both;
        }

        /// <summary>
        /// Configures the permission changes grid with data from the provided <see cref="DataTable"/>.
        /// </summary>
        /// <param name="dataTable">The data table containing the permission changes data.</param>
        private void SetupPermissionChangesGrid(DataTable dataTable)
        {
            pnlPermissionChanges.Controls.Clear(); // Clear any previous controls
            pnlPermissionChanges.Controls.Add(grdPermissionChanges);
            pnlPermissionChanges.Controls.Add(btnNewPermission);

            grdPermissionChanges.DataSource = dataTable;
            grdPermissionChanges.Dock = DockStyle.Bottom;
            grdPermissionChanges.Width = pnlPermissionChanges.Width;

            grdPermissionChanges.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy";
            grdPermissionChanges.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grdPermissionChanges.Columns[0].Visible = false; // Hide the ID column

            grdPermissionChanges.AutoResizeColumns();
            grdPermissionChanges.ScrollBars = ScrollBars.Both;
        }

        #endregion
    }
}

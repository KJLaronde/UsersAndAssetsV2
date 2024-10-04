using SharedMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormReports : Form
    {
        private FormMain ParentForm;
        private readonly SqlConnection SqlConn;

        /// <summary>
        /// Initializes a new instance of the FormMain class.
        /// Sets up the SQL connection using the predefined connection string.
        /// </summary>
        public FormReports(FormMain formMain)
        {
            ParentForm = formMain;
            // Connection for the database
            SqlConn = ParentForm.SqlConn;
            
            this.StartPosition = FormStartPosition.CenterParent;
            
            InitializeComponent();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            // Disable buttons tied to unfinished code
            btnActiveEmpPermissions.Enabled = false;    

            PopulateCboAssetsByStatus();
            PopulateCboAssetByType();
            rdoEmployeeActive.Checked = true;
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

        /// <summary>
        /// Handles the Close button click event to close the application.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            ParentForm.Show();
            this.Close();
        }

        #region Controls: Assets

        /// <summary>
        /// Handles the Click event for the btnAssetsRun button.
        /// Determines which combo box (cboAssetsByStatus or cboAssetsByType) has a selected value and
        /// calls the appropriate method to query the database based on the selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void btnAssetsRun_Click(object sender, EventArgs e)
        {
            // Check if the cboAssetsByStatus combo box has a selected item.
            if (cboAssetsByStatus.SelectedIndex != -1)
            {
                // Query the database for results based on the selected asset status.
                QueryDatabaseForAssetStatusResults(cboAssetsByStatus.SelectedIndex);
            }
            // If cboAssetsByStatus does not have a selection, check cboAssetsByType.
            else if (cboAssetsByType.SelectedIndex != -1)
            {
                // Query the database for results based on the selected asset type.
                QueryDatabaseForAssetTypeResults(cboAssetsByType.Text);
            }
        }

        /// <summary>
        /// Handles the DropDown event for the cboAssetsByStatus combo box.
        /// Resets the SelectedIndex of both cboAssetsByStatus and cboAssetsByType to -1,
        /// ensuring that only one combo box can have a selected value at a time.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void cboAssetsByStatus_DropDown(object sender, EventArgs e)
        {
            // Reset the selected index of both combo boxes to ensure only one can be selected at a time.
            cboAssetsByStatus.SelectedIndex = -1;
            cboAssetsByType.SelectedIndex = -1;
        }

        /// <summary>
        /// Handles the DropDown event for the cboAssetsByType combo box.
        /// Resets the SelectedIndex of both cboAssetsByStatus and cboAssetsByType to -1,
        /// ensuring that only one combo box can have a selected value at a time.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void cboAssetsByType_DropDown(object sender, EventArgs e)
        {
            // Reset the selected index of both combo boxes to ensure only one can be selected at a time.
            cboAssetsByStatus.SelectedIndex = -1;
            cboAssetsByType.SelectedIndex = -1;
        }

        #endregion

        #region Controls: Employees

        /// <summary>
        /// Handles the click event for the Employees (Active Directory) button.
        /// Outputs a list of active employees from Active Directory to an Excel file.
        /// </summary>
        private void btnEmpAD_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputEmployeesFromActiveDirectoryToExcel(status);
        }

        /// <summary>
        /// Handles the click event for the Employees (Database) button.
        /// Outputs a list of employees from the database to an Excel file.
        /// </summary>
        private void btnEmpDatabase_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputEmployeesFromDatabaseToExcel(status);
        }

        /// <summary>
        /// Handles the click event for the Employees (Email) button.
        /// Outputs a list of email accounts to an Excel file.
        /// </summary>
        private void btnEmpEmail_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputEmailListToExcel(status);
        }

        /// <summary>
        /// Handles the click event for the Employees (EZPay) button.
        /// Outputs a list of IGT EZPay users to an Excel file.
        /// </summary>
        private void btnEmpEzpay_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputIgtEzPayUsersToExcel(status);
        }

        /// <summary>
        /// Handles the click event for the Employees (Machine Acct) button.
        /// Outputs a list of IGT Machine Accounting users to an Excel file.
        /// </summary>
        private void btnEmpMachAcct_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputIgtMachineAcctUsersToExcel(status);
        }

        /// <summary>
        /// Handles the click event for the Employees (Patron Mgmt) button.
        /// Outputs a list of IGT Patron Management users to an Excel file.
        /// </summary>
        private void btnEmpPatron_Click(object sender, EventArgs e)
        {
            bool? status = GetEmployeeStatus();
            OutputIgtPatronToExcel(status);
        }

        //Pending
        private void btnEmpPermissions_Click(object sender, EventArgs e)
        {
            // Pending: Handle output for Active Employees (Permissions)
        }
        
        #endregion

        #region Controls: Other

        /// <summary>
        /// Handles the click event for the Storage Authorizations (USB/DVD) button.
        /// Queries the database for storage authorization records and exports them to an Excel file.
        /// </summary>
        private void btnStorageAuthorizations_Click(object sender, EventArgs e)
        {
            string query = @" 
                SELECT CONCAT(e.[LastName], ', ', e.[FirstName], ' ', e.[Initials]) AS 'Name', e.[BadgeNumber] AS 'Badge', s.[SignedDate], s.[USB], s.[DVD], 
                    s.[CompletedDate], (SELECT e2.[SAMAccountName] FROM [Employee] AS e2 WHERE e2.[ID] = s.[CompletedBy]) AS 'CompletedBy', s.[Reason] 
                FROM [Employee] AS e  
                    INNER JOIN [StorageAuth] AS s ON e.[ID] = s.[Employee_ID] 
                ORDER BY [Name], [SignedDate]";

            OutputDataTableToExcel(query, "StorageAuthorizations.xlsx");
        }

        private void btnWebFiltering_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT w.[Date], CONCAT(e.[FirstName], ' ', e.[LastName]) AS 'Employee', w.[Description], w.[Comments]
                FROM Employee AS e INNER JOIN
                     WebFilterChanges AS w ON e.ID = w.Employee_ID 
                ORDER BY [Date]; ";

            OutputDataTableToExcel(query, "WebFiltering.xlsx");
        }

        private void btnYubiKeys_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT y.[SerialNumber], y.[PublicID], t.[Description], d.[Name] AS 'Department' 
                FROM [YubiKey] AS y INNER JOIN
                     [Department] AS d ON y.[Department_ID] = d.[ID] INNER JOIN
                     [AssetType] AS t ON y.[AssetType_ID] = t.[ID]
                ORDER BY [SerialNumber];";
            
            OutputDataTableToExcel(query, "YubiKeys.xlsx");
        }
        
        #endregion

        #region General Methods

        /// <summary>
        /// Retrieves Active Directory user properties based on their active status.
        /// </summary>
        /// <param name="status">True for active users, false for inactive users, null for all users.</param>
        /// <returns>A list of dictionaries containing user properties.</returns>
        private List<Dictionary<string, object>> GetAdUsersProperties(bool? status)
        {
            List<Dictionary<string, object>> adUsers = new List<Dictionary<string, object>>();
            string filter;
            string path = "LDAP://OU=DEJ,DC=nation,DC=ho-chunk,DC=com";

            // Set the LDAP filter based on the active status
            if (status == true)
            {
                filter = "(&(objectCategory=person)(objectClass=user)(!userAccountControl:1.2.840.113556.1.4.803:=2))";  // all active users
            }
            else if (status == false)
            {
                filter = "(&(objectCategory=person)(objectClass=user)(userAccountControl:1.2.840.113556.1.4.803:=2))";  // all inactive users
            }
            else
            {
                filter = "(&(objectCategory=person)(objectClass=user))";
            }

            using (DirectoryEntry root = new DirectoryEntry(path))
            using (DirectorySearcher searcher = new DirectorySearcher(root, filter))
            {
                searcher.PageSize = 1000; // Handle large result sets
                searcher.SearchScope = SearchScope.Subtree; // Search all subdirectories

                // Specify the properties you want to load
                searcher.PropertiesToLoad.Add("cn");
                searcher.PropertiesToLoad.Add("sAMAccountName"); 
                searcher.PropertiesToLoad.Add("mail");
                searcher.PropertiesToLoad.Add("title");
                searcher.PropertiesToLoad.Add("department"); 
                searcher.PropertiesToLoad.Add("physicalDeliverOfficeName");
                searcher.PropertiesToLoad.Add("streetAddtess");                
                searcher.PropertiesToLoad.Add("l");
                searcher.PropertiesToLoad.Add("st");
                searcher.PropertiesToLoad.Add("postalCode");                
                searcher.PropertiesToLoad.Add("whenCreated");
                searcher.PropertiesToLoad.Add("objectSID");

                using (SearchResultCollection results = searcher.FindAll())
                {
                    foreach (SearchResult result in results)
                    {
                        Dictionary<string, object> userProperties = new Dictionary<string, object>();

                        foreach (string property in searcher.PropertiesToLoad)
                        {
                            if (result.Properties.Contains(property))
                            {
                                if (property == "objectSID")
                                {
                                    // Convert the objectSID byte array to a readable SID string
                                    SecurityIdentifier sid = new SecurityIdentifier((byte[])result.Properties[property][0], 0);
                                    userProperties[property] = sid.ToString();
                                }
                                else
                                {
                                    userProperties[property] = result.Properties[property][0];
                                }
                            }
                            else
                            {
                                userProperties[property] = null; // Property exists but is null/empty
                            }
                        }

                        adUsers.Add(userProperties);
                    }
                }
            }

            return adUsers;
        }

        /// <summary>
        /// Determines the selected employee status based on the radio button selection.
        /// </summary>
        /// <returns>True for active employees, false for inactive employees, null for all employees.</returns>
        private bool? GetEmployeeStatus()
        {
            if (rdoEmployeeActive.Checked)
                return true;
            else if (rdoEmployeeInactive.Checked)
                return false;
            else if (rdoEmployeeAll.Checked)
                return null;

            return null;
        }

        /// <summary>
        /// Retrieves a list of EzPay users from the database, filtered by their active status if specified.
        /// </summary>
        /// <param name="status">
        /// A nullable boolean indicating the user status to filter by:
        /// <c>true</c> for active users, <c>false</c> for inactive users, and <c>null</c> for all users.
        /// </param>
        /// <returns>
        /// A <see cref="DataTable"/> containing the EzPay user information, including user name, full name, group code, role code,
        /// last modification date, and active status.
        /// </returns>
        private DataTable GetIgtEzPayUsers(bool? status)
        {
            // Define the connection for getting the Machine Accounting user information
            string connectionString = "Data Source=mad-igtezpay;Initial Catalog=EzPay;Integrated Security=True";
            SqlConnection sqlConnectionAcctSql = new SqlConnection(connectionString);

            // Query to retrieve Machine Accounting users
            var acctSqlQuery = new StringBuilder(@"
                SELECT u.[user_name], u.[full_name], g.[group_code], r.[role_code], u.[last_mod_date], u.[active_flag]
                FROM [app_user] AS u 
                  INNER JOIN [user_group] AS g ON u.[user_seq] = g.[user_seq] 
                  INNER JOIN [user_role]  AS r ON u.[user_seq] = r.[user_seq] ");

            if (status == true)
            {
                acctSqlQuery.Append("WHERE u.[active_flag] = '1' ");
            }
            else if (status == false)
            {
                acctSqlQuery.Append("WHERE u.[active_flag] = '0' ");
            }

            acctSqlQuery.Append("ORDER BY u.[user_name];");

            return DatabaseMethods.QueryDatabaseForDataTable(acctSqlQuery.ToString(), sqlConnectionAcctSql);
        }

        /// <summary>
        /// Retrieves a list of Machine Accounting users from the database, filtered by their status if specified.
        /// </summary>
        /// <param name="status">
        /// A nullable boolean indicating the user status to filter by:
        /// <c>true</c> for active users, <c>false</c> for inactive users, and <c>null</c> for all users.
        /// </param>
        /// <returns>
        /// A <see cref="DataTable"/> containing the Machine Accounting user information, including login name, last name, 
        /// first name, mask, and status.
        /// </returns>
        private DataTable GetIgtMachineAcctUsers(bool? status)
        {
            // Define the connection for getting the Machine Accounting user information
            string connectionString = "Data Source=mad-igtacct;Initial Catalog=Accounting;Integrated Security=True";
            SqlConnection sqlConnectionAcctSql = new SqlConnection(connectionString);

            // Query to retrieve Machine Accounting users
            var acctSqlQuery = new StringBuilder("SELECT [LoginName], [LastName], [FirstName], [Mask], [Status] FROM [Legacy_View_ABSUser] ");

            if (status == true)
            {
                acctSqlQuery.Append("WHERE [Status] = 'A' ");
            }
            else if (status == false)
            {
                acctSqlQuery.Append("WHERE [Status] = 'I' ");
            }

            acctSqlQuery.Append("ORDER BY [LoginName];");

            return DatabaseMethods.QueryDatabaseForDataTable(acctSqlQuery.ToString(), sqlConnectionAcctSql);
        }

        /// <summary>
        /// Retrieves a list of Patron Management users from the database, filtered by their status if specified.
        /// </summary>
        /// <param name="status">
        /// A nullable boolean indicating the user status to filter by:
        /// <c>true</c> for active users, <c>false</c> for inactive users, and <c>null</c> for all users.
        /// </param>
        /// <returns>
        /// A <see cref="DataTable"/> containing the Patron Management user information, including login name, last name, 
        /// first name, middle initial, license, job title, mask, and status.
        /// </returns>
        private DataTable GetIgtPatronMgmtUsers(bool? status)
        {
            // Define the connection for getting the Patron Management user information
            string connectionString = "Data Source=wd-igtpatron;Initial Catalog=PlayerManagement;User ID=abswizard;Password=ae2pi3n;";
            SqlConnection sqlConnectionPatronSql = new SqlConnection(connectionString);

            var patronQuery = new StringBuilder(@"
                SELECT a.[LoginName], a.[LastName], a.[FirstName], a.[MiddleInitial], a.[License], a.[JobTitle], m.[Mask], a.[Status]
                FROM [AbsUser] AS a 
                    INNER JOIN [ABSUserMask] AS u ON a.[UserID] = u.[UserID] 
                    INNER JOIN [Mask] AS m ON u.[MaskNum] = m.[MaskNum]
                WHERE a.[SiteID] = '4'
	              AND m.[Mask] like 'MAD%' ");

            if (status == true)
            {
                patronQuery.Append("AND a.[Status] = 'A' ");
            }
            else if (status == false)
            {
                patronQuery.Append("AND a.[Status] = 'I' ");
            }

            patronQuery.Append("ORDER BY a.[LoginName], m.[Mask]");

            return DatabaseMethods.QueryDatabaseForDataTable(patronQuery.ToString(), sqlConnectionPatronSql);
        }
        
        /// <summary>
        /// Generates the SQL WHERE clause filter based on employee status.
        /// </summary>
        /// <param name="status">True for active, false for inactive, null for all.</param>
        /// <returns>A string containing the SQL WHERE clause for the employee status filter.</returns>
        private string GetSqlFilterForEmployeeStatus(bool? status)
        {
            if (status == true)
                return " WHERE e.[Active] = '1' ";
            else if (status == false)
                return " WHERE e.[Active] = '0' ";
            else
                return String.Empty;
        }

        /// <summary>
        /// Converts a nullable boolean status to a string representation.
        /// </summary>
        /// <param name="status">True for active, false for inactive, null for all.</param>
        /// <returns>A string indicating "Active", "Inactive", or "All".</returns>
        private string GetStatusType(bool? status)
        {
            switch (status)
            {
                case true:
                    return "Active";
                case false:
                    return "Inactive";
                case null:
                default:
                    return "All";
            }
        }

        private void OutputDataTableToExcel(string query, string filename)
        {
            DataTable table = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);

            // Export the DataTable to Excel
            DatabaseMethods.ExportDataTableToExcel(table, filename);
        }
       
        /// <summary>
        /// Outputs the list of email addresses to an Excel file based on the account status.
        /// </summary>
        /// <param name="status">True for enabled accounts, false for disabled accounts, null for all accounts.</param>
        private void OutputEmailListToExcel(bool? status)
        {
            string accountStatus = GetStatusType(status);
            List<string> emailList = ADMethods.GetEmailAddresses(accountStatus);
            DataTable dataTable = DatabaseMethods.ConvertToDataTable(emailList);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"EmailAddresses_{accountStatus}.xlsx");
        }

        /// <summary>
        /// Outputs the list of employees from Active Directory to an Excel file based on their active status.
        /// </summary>
        /// <param name="status">True for active employees, false for inactive employees, null for all employees.</param>
        private void OutputEmployeesFromActiveDirectoryToExcel(bool? status)
        {
            string type = GetStatusType(status);
            List<Dictionary<string, object>> userList = GetAdUsersProperties(status);
            DataTable dataTable = DatabaseMethods.ConvertDictionaryListToDataTable(userList);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"AdEmployees_{type}.xlsx");
        }

        /// <summary>
        /// Outputs the list of employees from the database to an Excel file based on their active status.
        /// </summary>
        /// <param name="status">True for active employees, false for inactive employees, null for all employees.</param>
        private void OutputEmployeesFromDatabaseToExcel(bool? status)
        {
            string type = GetStatusType(status);
            DataTable dataTable = QueryDatabaseForAdUser(status);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"EmployeesInDatabase_{type}.xlsx");
        }

        /// <summary>
        /// Outputs the list of IGT EZPay users to an Excel file based on their active status.
        /// </summary>
        /// <param name="status">True for active users, false for inactive users, null for all users.</param>
        private void OutputIgtEzPayUsersToExcel(bool? status)
        {
            string type = GetStatusType(status);
            DataTable dataTable = GetIgtEzPayUsers(status);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"IgtEzPayUsers_{type}.xlsx");
        }

        /// <summary>
        /// Outputs the list of IGT Machine Accounting users to an Excel file based on their active status.
        /// </summary>
        /// <param name="status">True for active users, false for inactive users, null for all users.</param>
        private void OutputIgtMachineAcctUsersToExcel(bool? status)
        {
            string type = GetStatusType(status);
            DataTable dataTable = GetIgtMachineAcctUsers(status);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"IgtMachineAcctUsers_{type}.xlsx");
        }

        /// <summary>
        /// Outputs the list of IGT Patron Managemengt users to an Excel file based on their active status.
        /// </summary>
        /// <param name="status">True for active users, false for inactive users, null for all users.</param>
        private void OutputIgtPatronToExcel(bool? status)
        {
            string type= GetStatusType(status);
            DataTable dataTable = GetIgtPatronMgmtUsers(status);
            DatabaseMethods.ExportDataTableToExcel(dataTable, $"IgtPatronUsers_{type}.xlsx");
        }

        /// <summary>
        /// Populates the cboAssetsByStatus combo box with predefined asset status options.
        /// </summary>
        private void PopulateCboAssetsByStatus()
        {
            // Add specific asset status options to the combo box.
            cboAssetsByStatus.Items.Add("In Stock"); 
            cboAssetsByStatus.Items.Add("Disposed");            
        }

        /// <summary>
        /// Populates the cboAssetsByType combo box with asset types from the database.
        /// The combo box displays the asset description while storing the asset ID as the value.
        /// </summary>
        private void PopulateCboAssetByType()
        {
            // Define the database fields to use for the combo box items.
            string valueItem = "ID";
            string displayItem = "Description";

            // Define the SQL query to retrieve asset types from the database.
            string query = "SELECT [ID], [Description] FROM [AssetType]";

            // Populate the combo box with the results from the database query.
            DatabaseMethods.PopulateComboBoxUsingObjectFields(cboAssetsByType, query, valueItem, displayItem, SqlConn);
        }

        /// <summary>
        /// Queries the database for Active Directory user information based on their active status.
        /// </summary>
        /// <param name="status">True for active users, false for inactive users, null for all users.</param>
        /// <returns>A DataTable containing user information from the database.</returns>
        private DataTable QueryDatabaseForAdUser(bool? status)
        {
            var query = new StringBuilder(@"
                SELECT e.[LastName] AS 'Last Name', e.[FirstName] AS 'First Name', e.[Initials], e.[BadgeNumber] AS 'Badge Number', e.[SAMAccountName], 
                       d.[Name] AS 'Department 1', j.[Title] AS 'Title 1', z.[Name] AS 'Department 2', x.[Title] AS 'Title 2', e.[StartDate] AS 'Hire Date', 
                       e.[PositionStartDate] AS 'Position Start', e.[EndDate] AS 'End Date', e.[ArchiveDate] AS 'Archive Date', e.[Temporary] AS 'Temp', 
                       e.[PhoneExtension] AS 'Ext',  a.[Description], e.[EmailHidden] AS 'Email Hidden', e.[EmailArchived] AS 'Email Archived?', e.[PhoneRank] AS 'Phone Rank'
                FROM [Employee] AS e
                INNER JOIN [Job] AS j ON e.[Job_ID] = j.[ID]
                INNER JOIN [Department] AS d ON j.[Department_ID] = d.[ID]
                INNER JOIN [Job] AS x ON e.[Job_ID_2] = x.[ID]
                INNER JOIN [Department] AS z ON x.[Department_ID] = z.[ID]
                INNER JOIN [AccountType] AS a ON e.[AccountType_ID] = a.[ID]");

            if (status.HasValue)
            {
                query.Append(" WHERE e.[Active] = ").Append(status.Value ? "1" : "0");
            }

            query.Append(" ORDER BY e.[LastName], e.[FirstName];");

            DataTable table = DatabaseMethods.QueryDatabaseForDataTable(query.ToString(), SqlConn);
            return table;
        }

        /// <summary>
        /// Queries the database for assets with the specified status and exports the results to an Excel file.
        /// </summary>
        /// <param name="selectedIndex">The selected asset status from the combo box.</param>
        private void QueryDatabaseForAssetStatusResults(object selectedIndex)
        {
            // Convert the selected index to a string representing the asset status.
            string disposed = selectedIndex.ToString();
            
            // Construct the SQL query to retrieve assets with the specified status.
            string query = $@"
                SELECT [A].[Number] AS 'Asset', [T].[Description] AS 'Asset Type', [M].[Name] AS 'Manufacturer', [O].[Description] AS 'Model', 
                    [A].[SerialNumber] AS 'Serial', [D].[Name] AS 'Department', [A].[NetworkName] AS 'Network Name', CONCAT(E.LastName, ', ', E.FirstName) AS 'Employee', 
                    [A].[IPv4] AS 'IP', [S].[Name] AS 'Operating System', [A].[MacAddress] AS 'MAC Address', [L].[Name] AS 'Asset Location', 
                    [A].[AcquiredDate] AS 'Acquired Date', [A].[DisposalDate] AS 'Disposal Date', [A].[Disposed], [A].[Comments] 
                FROM Asset AS a 
                    INNER JOIN AssetType AS t ON a.AssetType_ID = t.ID 
                    INNER JOIN AssetLocation AS l ON a.AssetLocation_ID = l.ID 
                    INNER JOIN Department AS d ON l.Department_ID = d.ID 
                    INNER JOIN Employee AS e ON a.Employee_ID = e.ID 
                    INNER JOIN Manufacturer AS m ON a.Manufacturer_ID = m.ID 
                    INNER JOIN Model AS o ON a.Model_ID = o.ID 
                    INNER JOIN OperatingSystem AS s ON a.OperatingSystem_ID = s.ID 
                WHERE [Disposed] = {disposed};";

            // Execute the query and retrieve the results in a DataTable.
            DataTable table = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);

            string status = Convert.ToBoolean(selectedIndex) ? "Disposed" : "InStock";
            // Export the results to an Excel file, named based on the selected status.
            DatabaseMethods.ExportDataTableToExcel(table, $"AssetsByStatus_{status}.xlsx");
        }

        /// <summary>
        /// Queries the database for assets of the specified type and exports the results to an Excel file.
        /// </summary>
        /// <param name="description">The description of the asset type selected from the combo box.</param>
        private void QueryDatabaseForAssetTypeResults(string description)
        {
            // Construct the SQL query to retrieve assets of the specified type.
            string query = $@"
                SELECT [A].[Number] AS 'Asset Number', [T].[Description] AS 'Asset Type', [M].[Name] AS 'Manufacturer', 
                    [O].[Description] AS 'Model', [A].[SerialNumber] AS 'Serial Number', [D].[Name] AS 'Department', 
                    [A].[NetworkName] AS 'Network Name', CONCAT(E.LastName, ', ', E.FirstName) AS 'Employee', 
                    [A].[IPv4] AS 'IP Address', [S].[Name] AS 'Operating System', [A].[MacAddress] AS 'MAC Address', 
                    [L].[Name] AS 'Asset Location', [A].[AcquiredDate] AS 'Acquired Date', [A].[DisposalDate] AS 'Disposal Date', 
                    [A].[Disposed], [A].[Comments] 
                FROM 
                    Asset AS A  
                    INNER JOIN AssetType       AS T ON A.AssetType_ID = T.ID 
                    INNER JOIN AssetLocation   AS L ON A.AssetLocation_ID = L.ID 
                    INNER JOIN Department      AS D ON L.Department_ID = D.ID 
                    INNER JOIN Employee        AS E ON A.Employee_ID = E.ID 
                    INNER JOIN Manufacturer    AS M ON A.Manufacturer_ID = M.ID 
                    INNER JOIN Model           AS O ON A.Model_ID = O.ID 
                    INNER JOIN OperatingSystem AS S ON A.OperatingSystem_ID = S.ID 
                WHERE [T].[Description] = '{description}' 
                ORDER BY [A].[Number]; ";

            // Execute the query and retrieve the results in a DataTable.
            DataTable table = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);

            // Export the results to an Excel file, named based on the selected asset type.
            DatabaseMethods.ExportDataTableToExcel(table, $"AssetsByType_{description}.xlsx");
        }


        #endregion


    }
}

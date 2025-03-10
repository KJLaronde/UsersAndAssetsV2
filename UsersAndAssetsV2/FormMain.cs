﻿using SharedMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormMain : Form
    {
        public int SiteLocationID { get; set; }
        public string SiteName { get; set; }
        public readonly SqlConnection SqlConn;
        private Dictionary<string, Func<Form>> FormCreators;

        /// <summary>
        /// Initializes a new instance of the FormMain class and verifies user access rights.
        /// This constructor checks if the user is part of the IT group before proceeding. If the user does not
        /// have the necessary permissions or if there is an issue with the SQL connection, the application terminates.
        /// </summary>
        /// <param name="siteID">Optional parameter that specifies the site ID. If not provided, the last selected site ID from settings is used.</param>
        /// <exception cref="SqlException">Thrown if the connection to the database fails.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if the user does not have permission to access the application.</exception>
        /// <exception cref="Exception">Thrown for unexpected errors during initialization.</exception>       
        public FormMain(int siteID = -1) // Optional parameter, default to -1 to load from settings
        {
            try
            {
                // Verify that the user is an IT employee
                if (!ADMethods.IsUserInIT())
                {
                    MessageBox.Show("You do not have permission to run this application.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

                // Retrieve the connection string from the configuration file
                string connectionString = ConfigurationManager.ConnectionStrings["UsersAndAssetsDB"].ConnectionString;

                // Open the SQL connection only if user is verified
                SqlConn = new SqlConnection(connectionString);
                SqlConn.Open();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database connection failed: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized access attempt detected.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                // General exception handling for unexpected errors
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // Load the site ID
            SiteLocationID = siteID == -1 ? Properties.Settings.Default.LastSelectedSiteID : siteID;

            // A dictionary that maps string keys (menu options) to functions that create instances of different forms.
            FormCreators = new Dictionary<string, Func<Form>>
            {
                { "About", () => new FormAbout(this) },
                { "Assets", () => new FormAssets(this) },
                { "Employees", () => new FormEmployee(this) },
                { "ExtensionList", () => new FormExtensionList(this) },
                { "Reports", () => new FormReports(this) },
                { "StorageAuth", () => new FormStorageAuth(this) },
                { "YubiKeys", () => new FormYubiKeys(this) },
                { "WebFiltering", () => new FormWebFilterChanges(this) }
            };

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FormMain. 
        /// Sets the form's icon, ensures the SQL connection is active, and initializes the site location details.
        /// Exits the application if the SQL connection fails.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Form.</param>
        /// <param name="e">Event data containing details about the Load event.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.StartPosition = FormStartPosition.CenterParent;

            SiteLocationID = 1;
            SiteName = GetSiteNameById(SiteLocationID);
            grpButtons.Enabled = true;
            grpButtons.Focus();
        }

        #region Control Events

        /// <summary>
        /// Handles the Click event of the btnAssets button. 
        /// Opens the Assets form and hides the main form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnAssets_Click(object sender, EventArgs e) => MenuSelection("Assets");

        /// <summary>
        /// Handles the Click event of the btnEmployees button. 
        /// Opens the Employees form and hides the main form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnEmployees_Click(object sender, EventArgs e) => MenuSelection("Employees");

        /// <summary>
        /// Handles the Click event of the btnExit button.
        /// Attempts to close the SQL connection if it's open, then closes and disposes the form, exiting the application.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
            }
            catch (Exception err)
            {
                CommonMethods.DisplayError("An error has occurred please contact your administrator.\n\n" + err.Message);
            }

            this.Close();
            this.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the btnExtensionLists button. 
        /// Opens the Extension List form and hides the main form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnExtensionLists_Click(object sender, EventArgs e) => MenuSelection("ExtensionList");

        /// <summary>
        ///  Handles the Click event of the btnReports button.
        ///  Opens the Reports form and hides the main form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnReports_Click(object sender, EventArgs e) => MenuSelection("Reports");

        /// <summary>
        /// Handles the Click event of the btnStorageAuth button. 
        /// Opens the Storage Authorization form and hides the main form.
        /// </summary>
        /// <param name="sender">The source of the event, typically the button.</param>
        /// <param name="e">Event data containing details about the click event.</param>
        private void btnStorageAuth_Click(object sender, EventArgs e) => MenuSelection("StorageAuth");

        /// <summary>
        /// Event handler for the Web Filtering button click event.
        /// Triggers the selection of the WebFiltering menu option by calling <see cref="MenuSelection"/> with "WebFiltering".
        /// </summary>
        /// <param name="sender">The source of the event, typically the Web Filtering button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnWebFiltering_Click(object sender, EventArgs e) => MenuSelection("WebFiltering");

        /// <summary>
        /// Event handler for the YubiKeys button click event.
        /// Triggers the selection of the YubiKeys menu option by calling <see cref="MenuSelection"/> with "YubiKeys".
        /// </summary>
        /// <param name="sender">The source of the event, typically the YubiKeys button.</param>
        /// <param name="e">Event arguments associated with the button click event.</param>
        private void btnYubiKeys_Click(object sender, EventArgs e) => MenuSelection("YubiKeys");

        /// <summary>
        /// Handles the DropDown event of the cboToolStripSiteLocation ComboBox. 
        /// Resets the selected index to -1 when the dropdown is opened.
        /// </summary>
        /// <param name="sender">The source of the event, typically the ComboBox.</param>
        /// <param name="e">Event data containing details about the DropDown event.</param>
        private void cboToolStripSiteLocation_DropDown(object sender, EventArgs e)
        {
            cboToolStripSiteLocation.SelectedIndex = -1;
        }

        /// <summary>
        /// Handles the DropDownClosed event of the cboToolStripSiteLocation ComboBox. 
        /// Updates the selected site location and saves it to settings when a valid selection is made, 
        /// or disables site-related controls if no selection is made.
        /// </summary>
        /// <param name="sender">The source of the event, typically the ComboBox.</param>
        /// <param name="e">Event data containing details about the DropDownClosed event.</param>
        private void cboToolStripSiteLocation_DropDownClosed(object sender, EventArgs e)
        {
            //siteToolStripMenuItem.HideDropDown();
            if (cboToolStripSiteLocation.SelectedIndex != -1)
            {
                SiteLocationID = GetToolStripSiteID(cboToolStripSiteLocation.SelectedItem.ToString());
                SiteName = GetSiteNameById(SiteLocationID);
                grpButtons.Enabled = true;

                // Save the selected SiteLocationID to the user settings
                Properties.Settings.Default.LastSelectedSiteID = SiteLocationID;
                Properties.Settings.Default.Save();
            }
            else
            {
                grpButtons.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboToolStripSiteLocation ComboBox. 
        /// Updates the site location ID and name based on the selected site, enabling related UI controls. 
        /// If no site is selected, disables the site-related controls.
        /// </summary>
        /// <param name="sender">The source of the event, typically the ComboBox.</param>
        /// <param name="e">Event data containing details about the SelectedIndexChanged event.</param>
        private void cboToolStripSiteLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboToolStripSiteLocation.SelectedIndex != -1)
            {
                string selectedSiteName = cboToolStripSiteLocation.SelectedItem.ToString();
                SiteLocationID = GetToolStripSiteID(selectedSiteName);

                // Update UI or perform any additional actions needed
                SiteName = selectedSiteName;
                grpButtons.Enabled = true;

                // Optionally save the selected site to settings
                Properties.Settings.Default.LastSelectedSiteID = SiteLocationID;
                Properties.Settings.Default.Save();
            }
            else
            {
                grpButtons.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the click event for the About picture box.
        /// Triggers the selection of the "About" menu item by calling the <see cref="MenuSelection"/> method with the "About" option.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the About picture box).</param>
        /// <param name="e">Event arguments for the click event.</param>
        private void picAbout_Click(object sender, EventArgs e) => MenuSelection("About");

        #endregion

        #region General methods

        /// <summary>
        /// Retrieves the name of the site location by its ID from the database.
        /// </summary>
        /// <param name="siteId">The ID of the site location to look up.</param>
        /// <returns>The name of the site location if found, otherwise null.</returns>
        private string GetSiteNameById(int siteId)
        {
            string query = "SELECT [Name] FROM [SiteLocation] WHERE [ID] = @SiteID";

            try
            {
                DatabaseMethods.CheckSqlConnectionState(SqlConn);
                using (SqlCommand command = new SqlCommand(query, SqlConn))
                {
                    command.Parameters.AddWithValue("@SiteID", siteId);
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        return dataTable.Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
            catch (Exception err) 
            { 
                CommonMethods.DisplayError("An error has occurred.\n\n" + err.Message);
                return null;
            }
            finally
            {
                SqlConn?.Close();
            }
        }

        /// <summary>
        /// Retrieves the site location ID by its name from the database.
        /// </summary>
        /// <param name="siteName">The name of the site location to look up.</param>
        /// <returns>The ID of the site location as an integer.</returns>
        private int GetToolStripSiteID(string siteName)
        {
            string query = $"SELECT [ID] FROM [SiteLocation] WHERE [Name] = '{siteName}'";
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            return Convert.ToInt32(dataTable.Rows[0]["ID"]);
        }

        /// <summary>
        /// Handles the menu selection event and opens the corresponding form based on the provided selection string.
        /// The selected form is shown, and the current form is hidden.
        /// </summary>
        /// <param name="selection">The name of the menu option selected, which corresponds to a form.</param>
        private void MenuSelection(string selection)
        {
            if (FormCreators.TryGetValue(selection, out var createForm))
            {
                Form form = createForm();
                form.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath); 
                form.Owner = this;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No option found.", "MenuSelection", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Populates the cboToolStripSiteLocation ComboBox with site names from the database.
        /// If the current SiteLocationID is greater than 0, sets the selected item to the corresponding site name.
        /// </summary>
        private void PopulateCboToolStripSiteLocation()
        {
            cboToolStripSiteLocation.Items.Clear(); // Clear existing items

            string query = "SELECT DISTINCT [Name] FROM [SiteLocation] ORDER BY [Name]";
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, SqlConn);
            foreach (DataRow row in dataTable.Rows)
            {
                cboToolStripSiteLocation.Items.Add(row["Name"]);
            }

            // Optionally set the initial selected item to match the current SiteLocationID
            if (SiteLocationID > 0)
            {
                string currentSiteName = GetSiteNameById(SiteLocationID);
                cboToolStripSiteLocation.SelectedItem = currentSiteName;
            }
        }

        #endregion
    }
}

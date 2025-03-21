﻿using ExtensionsMethods;
using SharedMethods;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UsersAndAssetsV2
{
    public partial class FormAssets : Form
    {
        private readonly FormMain parentForm;
        private readonly int SiteLocationID;
        private readonly string SiteName;
        private readonly SqlConnection sqlConnection;
        
        private DateTime? acquiredDate;
        private DateTime? disposalDate;
        private bool disposed = false;
        private bool newRecord = false;
        private byte[] warrantyFile = null;
        private int? assetID;
        private int? assetTypeID;
        private int? assetLocationID;
        private int? departmentID;
        private int? employeeID;
        private int? manufacturerID;
        private int? modelID;
        private int? operatingSystemID;
        private string assetNumber;
        private string comments;
        private string ipv4;
        private string macAddress;
        private string networkName;
        private string serialNumber;
        private string warrantyFilePath;

        /// <summary>
        /// Initializes a new instance of the FormAssets class.
        /// Sets the parent form, SQL connection, site location, and site name.
        /// </summary>
        /// <param name="formMain">The main form that serves as the parent of this form.</param>
        public FormAssets(FormMain formMain)
        {
            parentForm = formMain;
            sqlConnection = parentForm.SqlConn;
            SiteLocationID = parentForm.SiteLocationID;
            SiteName = parentForm.SiteName;
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the FormAssets class using specific site information.
        /// Optionally takes an asset number to prepopulate data.
        /// </summary>
        /// <param name="siteName">The name of the site associated with the assets.</param>
        /// <param name="siteLocationID">The ID of the site location.</param>
        /// <param name="sqlConnection">The SQL connection for interacting with the database.</param>
        /// <param name="assetNumber">Optional asset number to load a specific asset.</param>
        public FormAssets(string siteName, int siteLocationID, SqlConnection sqlConnection, string assetNumber = null)
        {
            parentForm = null;
            this.assetNumber = assetNumber;
            this.sqlConnection = sqlConnection;
            SiteLocationID = siteLocationID;
            SiteName = siteName;
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event. Sets up form components and prepopulates fields based on the asset number.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the load event.</param>
        private void FormAssets_Load(object sender, EventArgs e)
        {
            ConfigureDateTimePickerFormat();
            ConfigureTxtModelAutoComplete();
            PopulateFormComboBoxes();
            
            btnSave.Enabled = false;
            chkDispose.Enabled = false;

            if (assetNumber != null)
            {
                cboAssetSearch.SelectedValue = assetNumber;
                cboAssetSearch.SelectedIndex = cboAssetSearch.FindStringExact(assetNumber);  // Force selection by asset number
            }
            else
            {
                cboAssetSearch_SelectedIndexChanged(this, EventArgs.Empty);
                ClearForm();
            }
        }

        /// <summary>
        /// Disables the close 'X' button on the form, preventing the user from closing the form via the window control.
        /// </summary>
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        #region Control Events 

        /// <summary>
        /// Handles the Add New Asset button click event. Clears the form and enables input controls for adding a new asset.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnAddNewAsset_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlProtectedInfo.Enabled = true;
            pnlDynamicInfo.Enabled = true;
            chkDispose.Enabled = true;
            btnSave.Enabled = true;
            txtAssetNumber.Focus();
            newRecord = true;
        }

        /// <summary>
        /// Handles the event when the "Add Attachment" button is clicked. Allows the user to attach a PDF file to the asset record.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnAttachmentAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openAttachment = new OpenFileDialog
            {
                Filter = "Adobe PDF files (*.pdf)|*.pdf",
                Title = "Please select a file to attach."
            };

            DialogResult result = openAttachment.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = openAttachment.FileName;

                // Read the file into a byte[] variable
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        warrantyFile = reader.ReadBytes((int)stream.Length);
                    }
                }

                // Display the file icon
                //picWarranty.Image = Properties.Resources.file;
                warrantyFilePath = SaveAttachmentToShare();
                ToggleAttachmentButtons();
            }
        }

        /// <summary>
        /// Handles the event when the "Remove Attachment" button is clicked. Deletes the attachment from the record and file system.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnAttachmentRemove_Click(object sender, EventArgs e)
        {
            // Clear out the attachment
            picWarranty.Image = null;
            warrantyFile = null;
            File.Delete(warrantyFilePath);
            ToggleAttachmentButtons();
        }

        /// <summary>
        /// Handles the event when the "View Attachment" button is clicked. Opens the attached file if available.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnAttachmentView_Click(object sender, EventArgs e)
        {
            try
            {
                if (warrantyFilePath != null) _ = Process.Start(warrantyFilePath);
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Close button click event. Closes the form and the SQL connection, and returns to the parent form.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            sqlConnection?.Close();
            this.Close();
            parentForm?.Show();
        }

        /// <summary>
        /// Handles the Save button click event. Writes the current asset data to the database.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the button click event.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteToDatabase();
        }

        /// <summary>
        /// Handles the event when the Asset Location combo box dropdown is opened. 
        /// Resets the selected index of the combo box to -1, effectively clearing any previous selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Asset Location combo box.</param>
        /// <param name="e">Event data for the dropdown event.</param>
        private void cboAssetLocation_DropDown(object sender, EventArgs e)
        {
            cboAssetLocation.SelectedIndex = -1;
        }

        /// <summary>
        /// Handles the KeyDown event for the Asset Search combo box. Populates the form with the selected asset's data when Enter is pressed.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the KeyDown event.</param>
        private void cboAssetSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // If the Enter key was pressed...
            if (e.KeyCode == Keys.Enter)
            {
                cboAssetSearch_SelectionChangeCommitted(sender, e);
            }
        }

        /// <summary>
        /// Handles the event when the Asset Search combo box loses focus.
        /// Triggers the same logic as when a selection change is committed to update the form.
        /// </summary>
        /// <param name="sender">The object that triggered the event, typically the combo box.</param>
        /// <param name="e">Event data associated with the leave event.</param>
        private void cboAssetSearch_Leave(object sender, EventArgs e)
        {
            cboAssetSearch_SelectionChangeCommitted(sender, e);
        }

        /// <summary>
        /// Handles the event when a selection is committed in the Asset Search combo box. 
        /// Triggers the same logic as when the dropdown is closed, populating the form based on the selected asset or clearing it.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Asset Search combo box.</param>
        /// <param name="e">Event data for the selection change committed event.</param>
        private void cboAssetSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboAssetSearch.SelectedIndex < 0)
            {
                ClearForm();
            }
            else
            {
                PopulateForm();
            }
        }

        /// <summary>
        /// Handles the event when the selected index in the Asset Search combo box changes.
        /// Triggers the same logic as when a selection change is committed to update the form.
        /// </summary>
        /// <param name="sender">The object that triggered the event, typically the combo box.</param>
        /// <param name="e">Event data associated with the selected index change event.</param>
        private void cboAssetSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAssetSearch_SelectionChangeCommitted(sender, e);
        }

        /// <summary>
        /// Event handler for the asset location combo box dropdown event.
        /// Resets the selected index of the combo box to -1 when the dropdown is opened, 
        /// clearing any existing selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the asset location combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboAssetType_DropDown(object sender, EventArgs e)
        {
            cboAssetType.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the department combo box dropdown event.
        /// Resets the selected index of the department combo box to -1 when the dropdown is opened, 
        /// clearing any existing selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            cboDepartment.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the department combo box dropdown closed event.
        /// Calls <see cref="PopulateCboAssetLocation"/> to repopulate the asset location combo box 
        /// when the department combo box is closed.
        /// </summary>
        /// <param name="sender">The source of the event, typically the department combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown close event.</param>
        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            PopulateCboAssetLocation();
        }

        /// <summary>
        /// Event handler for the department combo box text changed event.
        /// Calls <see cref="PopulateCboAssetLocation"/> to repopulate the asset location combo box 
        /// whenever the text in the department combo box changes.
        /// </summary>
        /// <param name="sender">The source of the event, typically the department combo box.</param>
        /// <param name="e">Event arguments associated with the text changed event.</param>
        private void cboDepartment_TextChanged(object sender, EventArgs e)
        {
            PopulateCboAssetLocation();
        }

        /// <summary>
        /// Event handler for the employee combo box dropdown event.
        /// Resets the selected index of the employee combo box to -1 when the dropdown is opened, 
        /// clearing any existing selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the employee combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboEmployee_DropDown(object sender, EventArgs e)
        {
            cboEmployee.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the manufacturer combo box dropdown event.
        /// Resets the selected index of the manufacturer combo box to -1 when the dropdown is opened, 
        /// clearing any existing selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the manufacturer combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboManufacturer_DropDown(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = -1;
        }

        /// <summary>
        /// Event handler for the operating system combo box dropdown event.
        /// Resets the selected index of the operating system combo box to -1 when the dropdown is opened, 
        /// clearing any existing selection.
        /// </summary>
        /// <param name="sender">The source of the event, typically the operating system combo box.</param>
        /// <param name="e">Event arguments associated with the dropdown event.</param>
        private void cboOperatingSystem_DropDown(object sender, EventArgs e)
        {
            cboOperatingSystem.SelectedIndex = -1;
        }

        /// <summary>
        /// Handles the CheckedChanged event for the Dispose checkbox. Enables or disables the disposal date field based on the checkbox value.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data for the checkbox change event.</param>
        private void chkDispose_CheckedChanged(object sender, EventArgs e)
        {
            dteDisposalDate.Enabled = chkDispose.Checked;
        }

        #endregion

        #region Attachment Methods

        /// <summary>
        /// Deletes the warranty file attachment from the shared file system based on the asset ID.
        /// This method retrieves the file path from the database, checks if the file exists, 
        /// and deletes it if found. If the file doesn't exist or an error occurs, 
        /// an error message is displayed.
        /// </summary>
        private void DeleteAttachmentFromShare()
        {
            try
            {
                // Retrieve the warranty file path from the database
                string query = "SELECT [WarrantyFile] FROM [Asset] WHERE [ID] = @AssetID";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@AssetID", assetID);
                    string filePath = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError($"Error deleting attachment: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves the warranty file attachment from the shared file system based on the asset ID 
        /// and loads it into memory as a byte array. If the file does not exist or an error occurs,
        /// the warranty file is set to null and an error message is displayed.
        /// </summary>
        private void GetAttachmentFromShare()
        {
            try
            {
                string query = "SELECT [WarrantyFile] FROM [Asset] WHERE [ID] = @AssetID";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@AssetID", assetID);
                    string filePath = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        using (var reader = new BinaryReader(stream))
                        {
                            warrantyFile = reader.ReadBytes((int)stream.Length);
                        }
                    }
                    else
                    {
                        warrantyFile = null;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError($"Error retrieving attachment: {ex.Message}", "Getting Attachment");
            }
        }

        /// <summary>
        /// Saves the attached warranty file to the shared file system and returns the saved file path.
        /// This method ensures the target directory exists before saving the file. 
        /// If the save operation fails due to permission issues, I/O errors, or other exceptions, 
        /// an error message is displayed and null is returned.
        /// </summary>
        /// <returns>The full path of the saved file, or null if saving failed.</returns>
        private string SaveAttachmentToShare()
        {
            try
            {
                if (warrantyFile == null || warrantyFile.Length == 0)
                    return null;

                string directoryPath = Path.Combine(@"\\hcgm-it\share\Databases\UsersAndAssets\Assets", assetNumber);
                string fileName = $"{assetNumber} Attachment.pdf";
                string fullPath = Path.Combine(directoryPath, fileName);

                // Ensure the directory exists
                Directory.CreateDirectory(directoryPath);

                // Save the file
                File.WriteAllBytes(fullPath, warrantyFile);

                return fullPath;
            }
            catch (UnauthorizedAccessException ex)
            {
                CommonMethods.DisplayError($"Access denied: {ex.Message}", "Saving Attachment");
                return null;
            }
            catch (IOException ex)
            {
                CommonMethods.DisplayError($"I/O error: {ex.Message}", "Saving Attachment");
                return null;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError($"Unexpected error: {ex.Message}", "Saving Attachment");
                return null;
            }
        }

        /// <summary>
        /// Toggles the state of the attachment-related buttons (Add, Remove, View) based on the presence 
        /// of an attachment. If an attachment exists in the shared file system, the Remove and View buttons 
        /// are enabled, otherwise, the Add button is enabled.
        /// </summary>
        private void ToggleAttachmentButtons()
        {
            bool attachmentExists = !string.IsNullOrEmpty(warrantyFilePath) && File.Exists(warrantyFilePath);
            btnAttachmentAdd.Enabled = !attachmentExists;
            btnAttachmentRemove.Enabled = attachmentExists;
            btnAttachmentView.Enabled = attachmentExists;
        }

        #endregion

        #region General Methods

        /// <summary>
        /// Clears all combo boxes within a given panel.
        /// </summary>
        /// <param name="panel">The panel containing the combo boxes to clear.</param>
        private void ClearComboBoxes(Panel panel)
        {
            foreach (ComboBox comboBox in panel.GetChildControls<ComboBox>())
            {
                comboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Clears the form, resetting all text boxes, combo boxes, and other controls to their default state.
        /// </summary>
        private void ClearForm()
        {
            ClearTextBoxes(pnlDynamicInfo);
            ClearTextBoxes(pnlProtectedInfo);

            ResetDateTimePickers(pnlDynamicInfo);
            ResetDateTimePickers(pnlProtectedInfo);

            ClearComboBoxes(pnlDynamicInfo);
            ClearComboBoxes(pnlProtectedInfo);

            ResetFormControls();
            ClearVariables();
        }

        /// <summary>
        /// Clears all text boxes within a given panel.
        /// </summary>
        /// <param name="panel">The panel containing the text boxes to clear.</param>
        private void ClearTextBoxes(Panel panel)
        {
            foreach (TextBox textBox in panel.GetChildControls<TextBox>())
            {
                textBox.Clear();
            }
        }

        /// <summary>
        /// Clears all internal variables used to store asset information.
        /// </summary>
        private void ClearVariables()
        {
            assetID = 0;
            assetNumber = null;
            assetTypeID = 0;
            manufacturerID = 0;
            modelID = 0;
            serialNumber = null;
            departmentID = -1;
            networkName = null;
            employeeID = 0;
            ipv4 = null;
            operatingSystemID = 0;
            macAddress = null;
            assetLocationID = 0;
            comments = null;
            warrantyFile = null;
            warrantyFilePath = null;
            disposed = false;
            newRecord = false;

            acquiredDate = DateTime.Now;
            disposalDate = DateTime.Now;
        }

        /// <summary>
        /// Configures the format of the date pickers (acquired and disposal dates) on the form.
        /// </summary>
        private void ConfigureDateTimePickerFormat()
        {
            // Set up the DateTimePickers
            string format = "MM/dd/yyyy";
            dteAcquiredDate.Format = DateTimePickerFormat.Custom;
            dteAcquiredDate.CustomFormat = format;
            dteDisposalDate.Format = DateTimePickerFormat.Custom;
            dteDisposalDate.CustomFormat = format;
        }

        /// <summary>
        /// Configures the auto-complete functionality for the model text box, prepopulating it with data from the database.
        /// </summary>
        private void ConfigureTxtModelAutoComplete()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            string query = "SELECT DISTINCT [Description] FROM [Model] ORDER BY [Description]";
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, sqlConnection);

            foreach (DataRow row in dataTable.Rows)
            {
                collection.Add(row["Description"].ToString());
            }

            txtModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtModel.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtModel.AutoCompleteCustomSource = collection;
        }

        /// <summary>
        /// Enables input controls on the form, allowing the user to edit asset information.
        /// </summary>
        private void EnableFormControls()
        {
            chkDispose.Enabled = true; 
            pnlDynamicInfo.Enabled = true;
            pnlProtectedInfo.Enabled = true;
        }

        /// <summary>
        /// Handles the process of loading and displaying asset attachments (e.g., warranty files) based on the asset data row.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void HandleAttachments(DataRow assetRow)
        {
            var tempFile = assetRow["WarrantyFile"];
            if (tempFile != DBNull.Value)
            {
                warrantyFilePath = Convert.ToString(tempFile);
                //picWarranty.Image = Properties.Resources.PDF_32;
            }
            else
            {
                warrantyFile = null;
            }

            ToggleAttachmentButtons();
        }

        /// <summary>
        /// Checks if the asset number provided in the form is valid. Asset numbers must be unique and follow specific formatting rules.
        /// </summary>
        /// <returns>True if the asset number is valid, false otherwise.</returns>
        private bool IsValidAssetNumber()
        {
            // Asset Numbers must be unique in the Asset table
            string query = " SELECT [Number], COUNT(*) FROM [Asset] GROUP BY [Number] HAVING COUNT([Number]) > 1 ";
            DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, sqlConnection);
            return dataTable != null
                ? txtAssetNumber.Text.Length > 0 &&
                  int.TryParse(txtAssetNumber.Text, out _) &&
                  (txtAssetNumber.Text.Length == 5 || txtAssetNumber.Text.Length == 6)
                : false;
        }

        /// <summary>
        /// Populates a combo box with a selected value if the value exists. Otherwise, it resets the combo box.
        /// </summary>
        /// <param name="comboBox">The combo box to populate.</param>
        /// <param name="value">The value to select in the combo box.</param>
        private void PopulateComboBox(ComboBox comboBox, object value)
        {
            if (value != DBNull.Value)
            {
                comboBox.SelectedValue = value.ToString();
            }
            else
            {
                comboBox.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Populates the combo boxes on the form with values based on the asset's data.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void PopulateComboBoxes(DataRow assetRow)
        {
            PopulateComboBox(cboAssetType, assetRow["AssetType_ID"]);
            PopulateComboBox(cboManufacturer, assetRow["Manufacturer_ID"]);
            PopulateComboBox(cboEmployee, assetRow["Employee_ID"]);
            PopulateComboBox(cboOperatingSystem, assetRow["OperatingSystem_ID"]);
            PopulateDepartmentAndLocation(assetRow);
        }

        /// <summary>
        /// Populates the acquired and disposal dates on the form based on the asset's data.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void PopulateDates(DataRow assetRow)
        {
            dteAcquiredDate.Value = assetRow["AcquiredDate"] != DBNull.Value ? Convert.ToDateTime(assetRow["AcquiredDate"]) : DateTime.Now;

            disposed = (bool)assetRow["Disposed"];
            chkDispose.Checked = disposed;
            dteDisposalDate.Value = assetRow["DisposalDate"] != DBNull.Value ? Convert.ToDateTime(assetRow["DisposalDate"]) : DateTime.Now;
        }

        /// <summary>
        /// Populates the department and asset location combo boxes based on the asset's data and department selection.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void PopulateDepartmentAndLocation(DataRow assetRow)
        {
            var tempAssetLocationID = assetRow["AssetLocation_ID"];
            if (tempAssetLocationID != DBNull.Value)
            {
                assetLocationID = Convert.ToInt32(tempAssetLocationID);

                string deptQuery = $@"SELECT [D].[ID] FROM [Department] AS D, [AssetLocation] AS L 
                                      WHERE [L].[ID] = {assetLocationID} AND [L].[Department_ID] = [D].[ID]";

                DataTable deptDataTable = DatabaseMethods.QueryDatabaseForDataTable(deptQuery, sqlConnection);

                if (deptDataTable.Rows.Count > 0 && deptDataTable.Rows[0]["ID"] != DBNull.Value)
                {
                    cboDepartment.SelectedValue = deptDataTable.Rows[0]["ID"].ToString();
                }
                else
                {
                    cboDepartment.SelectedIndex = -1;
                }

                PopulateCboAssetLocation();
                cboAssetLocation.SelectedValue = assetLocationID.ToString();
            }
            else
            {
                cboAssetLocation.SelectedIndex = -1;
                cboDepartment.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Populates the form with asset data from the database, enabling controls and populating fields based on the asset ID.
        /// </summary>
        private void PopulateForm()
        {
            if (cboAssetSearch.SelectedValue == null)
            {
                MessageBox.Show("No asset selected.");
                return;
            }

            string assetNumber = cboAssetSearch.Text;
            string query = $@"
                SELECT A.[ID], A.[Number], A.[AssetType_ID], A.[Manufacturer_ID], M.[Description] AS 'Model', A.[SerialNumber]
                     , A.[NetworkName], A.[Employee_ID], A.[IPv4], A.[OperatingSystem_ID], A.[MacAddress], A.[AcquiredDate]
                     , A.[AssetLocation_ID], A.[DisposalDate], A.[Comments], A.[WarrantyFile], A.[Disposed], A.[SiteLocation_ID]
                FROM [Asset] AS A INNER JOIN
                     [Model] AS M ON A.[Model_ID] = M.[ID]
                WHERE A.[Number] = '{assetNumber}';";

            try
            {
                assetID = Convert.ToInt32(cboAssetSearch.SelectedValue);

                DataTable dataTable = DatabaseMethods.QueryDatabaseForDataTable(query, sqlConnection);
                if (dataTable.Rows.Count == 0) return;

                DataRow assetRow = dataTable.Rows[0];

                EnableFormControls();
                PopulateTextFields(assetRow);
                PopulateMacAddress(assetRow);
                PopulateComboBoxes(assetRow);
                PopulateDates(assetRow);
                HandleAttachments(assetRow);
                SetControlStates(assetRow);

                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
        }

        /// <summary>
        /// Populates the combo boxes on the form with data from the database (asset search, asset type, department, etc.).
        /// </summary>
        private void PopulateFormComboBoxes()
        {
            PopulateCboAssetSearch();
            PopulateCboAssetType();
            //  PopulateCboAssetLocation();
            PopulateCboDepartment();
            PopulateCboEmployee();
            PopulateCboManufacturer();
            PopulateCboOperatingSystem();
        }

        /// <summary>
        /// Populates the MAC address text box with the asset's MAC address, formatting it as necessary.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's MAC address.</param>
        private void PopulateMacAddress(DataRow assetRow)
        {
            var tempMac = assetRow["MacAddress"];
            if (tempMac == DBNull.Value)
            {
                txtMacAddress.Text = String.Empty;
            }
            else
            {
                macAddress = Convert.ToString(tempMac);
                txtMacAddress.Text = Regex.Replace(macAddress, "(.{2})(.{2})(.{2})(.{2})(.{2})(.{2})", "$1:$2:$3:$4:$5:$6");
            }
        }

        /// <summary>
        /// Populates the text fields on the form with the asset's information (e.g., serial number, comments, etc.).
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void PopulateTextFields(DataRow assetRow)
        {
            txtAssetNumber.Text = Convert.ToString(assetRow["Number"]);
            txtComments.Text = Convert.ToString(assetRow["Comments"]);
            txtIPv4Address.Text = Convert.ToString(assetRow["IPv4"]);
            txtModel.Text = Convert.ToString(assetRow["Model"]);
            txtNetworkName.Text = Convert.ToString(assetRow["NetworkName"]);
            txtSerialNumber.Text = Convert.ToString(assetRow["SerialNumber"]);
        }

        /// <summary>
        /// Resets all DateTimePicker controls within a given panel to the current date.
        /// </summary>
        /// <param name="panel">The panel containing the DateTimePickers to reset.</param>
        private void ResetDateTimePickers(Panel panel)
        {
            foreach (DateTimePicker dateTimePicker in panel.GetChildControls<DateTimePicker>())
            {
                dateTimePicker.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Resets specific form controls to their default state (e.g., disables input fields and buttons).
        /// </summary>
        private void ResetFormControls()
        {
            ConfigureTxtModelAutoComplete();
            ToggleAttachmentButtons();
            btnSave.Enabled = false;
            pnlProtectedInfo.Enabled = false;
            pnlDynamicInfo.Enabled = false;
            picWarranty.Image = null;
            chkDispose.Checked = false;
            chkDispose.Enabled = false;
            cboAssetSearch.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
        }

        /// <summary>
        /// Sets the control states based on whether the asset is marked as disposed, adjusting the availability of input fields and buttons.
        /// </summary>
        /// <param name="assetRow">The data row containing the asset's information.</param>
        private void SetControlStates(DataRow assetRow)
        {
            if (disposed)
            {
                chkDispose.Enabled = false;
                dteDisposalDate.Enabled = false;
                btnAttachmentRemove.Enabled = false;
            }
            else
            {
                chkDispose.Enabled = true;
                dteDisposalDate.Enabled = false;
            }
        }

        #endregion

        #region Populating ComboBoxes

        /// <summary>
        /// Populates the asset search combo box with asset data from the database.
        /// Lists all assets filtered by the current site location, specified by <see cref="SiteLocationID"/>.
        /// </summary>
        private void PopulateCboAssetSearch()
        {
            string query = $"SELECT [ID], [Number] FROM [Asset] WHERE [SiteLocation_ID] = {SiteLocationID} ORDER BY [Number]";
            PopulateComboBox(cboAssetSearch, query, "ID", "Number", "cboAssetSearch");
        }

        /// <summary>
        /// Populates the asset type combo box with asset types from the database, 
        /// ordered by description.
        /// </summary>
        private void PopulateCboAssetType()
        {
            string query = "SELECT [ID], [Description] FROM [AssetType] ORDER BY [Description]";
            PopulateComboBox(cboAssetType, query, "ID", "Description", "cboAssetType");
        }

        /// <summary>
        /// Populates the asset location combo box with data filtered by the selected department. 
        /// If no department is selected, the asset location combo box is cleared.
        /// </summary>
        private void PopulateCboAssetLocation()
        {
            if (cboDepartment.SelectedIndex != -1)
            {
                departmentID = Convert.ToInt32(cboDepartment.SelectedValue);
                string query = $"SELECT [ID], [Name] FROM [AssetLocation] WHERE [Department_ID] = {departmentID} ORDER BY [Name]";
                PopulateComboBox(cboAssetLocation, query, "ID", "Name", "cboAssetLocation", true);
            }
            else
            {
                cboAssetLocation.DataSource = null;
            }
        }

        /// <summary>
        /// Populates the department combo box with department data from the database, 
        /// ordered by department name.
        /// </summary>
        private void PopulateCboDepartment()
        {
            string query = "SELECT [ID], [Name] FROM [Department] ORDER BY [Name]";
            PopulateComboBox(cboDepartment, query, "ID", "Name", "cboDepartment");
        }

        /// <summary>
        /// Populates the employee combo box with employee data from the database, 
        /// ordered alphabetically by last name and first name. The employee's name is displayed 
        /// in the format 'LastName, FirstName Initials'.
        /// </summary>
        private void PopulateCboEmployee()
        {
            string query = "SELECT [ID], CONCAT([LastName], ', ', [FirstName], ' ', [Initials]) AS 'Employee' FROM [Employee] ORDER BY [LastName], [FirstName]";
            PopulateComboBox(cboEmployee, query, "ID", "Employee", "cboEmployee");
        }

        /// <summary>
        /// Populates the manufacturer combo box with manufacturer data from the database, 
        /// ordered by manufacturer name.
        /// </summary>
        private void PopulateCboManufacturer()
        {
            string query = "SELECT [ID], [Name] FROM [Manufacturer] ORDER BY [Name]";
            PopulateComboBox(cboManufacturer, query, "ID", "Name", "cboManufacturer");
        }

        /// <summary>
        /// Populates the operating system combo box with operating system data from the database, 
        /// ordered by operating system name.
        /// </summary>
        private void PopulateCboOperatingSystem()
        {
            string query = "SELECT [ID], [Name] FROM [OperatingSystem] ORDER BY [Name]";
            PopulateComboBox(cboOperatingSystem, query, "ID", "Name", "cboOperatingSystem");
        }

        /// <summary>
        /// Populates the specified combo box with data from the database, based on the provided SQL query.
        /// Handles exceptions by displaying an error message and, optionally, resets the combo box index.
        /// </summary>
        /// <param name="comboBox">The combo box to populate with data.</param>
        /// <param name="query">The SQL query to retrieve data from the database.</param>
        /// <param name="valueItem">The column to use as the value field in the combo box.</param>
        /// <param name="displayItem">The column to use as the display field in the combo box.</param>
        /// <param name="errorMessage">The error message to display if an exception occurs.</param>
        /// <param name="resetIndex">Optional: If true, resets the selected index of the combo box to -1 after populating.</param>
        private void PopulateComboBox(ComboBox comboBox, string query, string valueItem, string displayItem, string errorMessage, bool resetIndex = false)
        {
            try
            {
                DatabaseMethods.PopulateComboBoxUsingObjectFields(comboBox, query, valueItem, displayItem, sqlConnection);
                if (resetIndex)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, errorMessage);
            }
        }

        #endregion

        #region Writing to the Database 

        /// <summary>
        /// Inserts a new record for an asset model into the database.
        /// </summary>
        /// <param name="modelText">The model description to insert.</param>
        private void InsertModelRecord(string modelText)
        {
            string query = "INSERT INTO [Model] ([Description]) VALUES (@ModelDescription)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ModelDescription", modelText);

                    DatabaseMethods.CheckSqlConnectionState(sqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "InsertModelRecord");
            }
            finally
            {
                sqlConnection?.Close();
            }
        }

        /// <summary>
        /// Inserts a new asset record into the database using the current form data.
        /// </summary>
        private void InsertNewRecord()
        {
            warrantyFilePath = warrantyFile == null ? null : SaveAttachmentToShare();

            string query = @"
                INSERT INTO [Asset] (
                  [AssetNumber], [AssetTypeID], [ManufacturerID], [ModelID], [SerialNumber], [NetworkName], 
                  [EmployeeID], [IPv4], [OperatingSystemID], [MACAddress], [AssetLocationID], [AcquiredDate], 
                  [DisposalDate], [Comments], [WarrantyFilePath], [Disposed], [SiteLocationID]
                ) VALUES ( 
                  @AssetNumber, @AssetTypeID, @ManufacturerID, @ModelID, @SerialNumber, @NetworkName, 
                  @EmployeeID, @IPv4, @OperatingSystemID, @MACAddress, @AssetLocationID, @AcquiredDate, 
                  @DisposalDate, @Comments, @WarrantyFilePath, @Disposed, @SiteLocationID)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@AssetNumber", assetNumber);
                    cmd.Parameters.AddWithValue("@AssetTypeID", assetTypeID);
                    cmd.Parameters.AddWithValue("@ManufacturerID", (object)manufacturerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModelID", (object)modelID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SerialNumber", (object)serialNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NetworkName", (object)networkName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeID", (object)employeeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPv4", (object)ipv4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OperatingSystemID", operatingSystemID);
                    cmd.Parameters.AddWithValue("@MACAddress", (object)macAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssetLocationID", assetLocationID);
                    cmd.Parameters.AddWithValue("@AcquiredDate", acquiredDate);
                    cmd.Parameters.AddWithValue("@DisposalDate", (object)disposalDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Comments", (object)comments ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WarrantyFilePath", (object)warrantyFilePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Disposed", disposed);
                    cmd.Parameters.AddWithValue("@SiteLocationID", SiteLocationID);

                    DatabaseMethods.CheckSqlConnectionState(sqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message);
            }
            finally 
            {
                sqlConnection?.Close();    
            }

            PopulateCboAssetSearch();
        }

        /// <summary>
        /// Retrieves the ID of a specific model from the database based on the model description.
        /// </summary>
        /// <param name="modelText">The model description to search for.</param>
        /// <returns>The ID of the model if found, otherwise throws an exception.</returns>
        private int GetModelID(string modelText)
        {
            string query = "SELECT [ID] FROM [Model] WHERE [DESCRIPTION] = @ModelDescription";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@ModelDescription", modelText);
                    DatabaseMethods.CheckSqlConnectionState(sqlConnection);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally { 
                sqlConnection?.Close(); 
            }
        }

        /// <summary>
        /// Gets the selected value of a combo box, returning a default value if no valid selection is made.
        /// </summary>
        /// <param name="comboBox">The combo box to get the selected value from.</param>
        /// <param name="defaultValue">The default value to return if no selection is made.</param>
        /// <returns>The selected value or the default value if none is selected.</returns>
        private int GetSelectedValue(ComboBox comboBox, int defaultValue)
        {
            int selectedValue = Convert.ToInt32(comboBox.SelectedValue);
            return selectedValue > 0 ? selectedValue : defaultValue;
        }

        /// <summary>
        /// Gets the selected value of a combo box, throwing an error if the selection is invalid.
        /// </summary>
        /// <param name="comboBox">The combo box to get the selected value from.</param>
        /// <param name="errorMessage">The error message to display if the selection is invalid.</param>
        /// <returns>The selected value if valid, otherwise throws an InvalidOperationException.</returns>
        private int GetSelectedValue(ComboBox comboBox, string errorMessage)
        {
            int selectedValue = Convert.ToInt32(comboBox.SelectedValue);

            if (selectedValue <= 0)
            {
                CommonMethods.DisplayError(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            return selectedValue;
        }

        /// <summary>
        /// Gets the nullable selected value of a combo box, returning null if no valid selection is made.
        /// </summary>
        /// <param name="comboBox">The combo box to get the selected value from.</param>
        /// <returns>The selected value or null if none is selected.</returns>
        private int? GetNullableSelectedValue(ComboBox comboBox)
        {
            int selectedValue = Convert.ToInt32(comboBox.SelectedValue);
            return selectedValue > 0 ? selectedValue : (int?)null;
        }

        /// <summary>
        /// Processes the asset number entered in the form, ensuring it is valid and unique.
        /// </summary>
        /// <returns>True if the asset number is valid, false otherwise.</returns>
        private bool ProcessAssetNumber()
        {
            if (IsValidAssetNumber())
            {
                assetNumber = txtAssetNumber.Text;
                return true;
            }
            else
            {
                btnSave.Enabled = false;
                MessageBox.Show("The Asset Number is invalid.", "Input Error");
                txtAssetNumber.Focus();
                txtAssetNumber.SelectAll();
                return false;
            }
        }

        /// <summary>
        /// Processes the selected value of a combo box, returning null if no valid selection is made.
        /// </summary>
        /// <param name="comboBox">The combo box to process.</param>
        /// <param name="defaultValue">The default value to return if no selection is made.</param>
        /// <returns>The selected value or null if none is selected.</returns>
        private int? ProcessComboBox(ComboBox comboBox, int defaultValue = 0)
        {
            int selectedValue = Convert.ToInt32(comboBox.SelectedValue);
            return selectedValue > defaultValue ? selectedValue : (int?)null;
        }

        /// <summary>
        /// Processes the comments field, returning the entered comments or null if the field is empty.
        /// </summary>
        /// <returns>The comments entered in the form, or null if empty.</returns>
        private string ProcessComments()
        {
            return ProcessTextField(txtComments);
        }

        /// <summary>
        /// Processes foreign key selections for asset-related fields such as asset type, department, and location.
        /// </summary>
        private void ProcessForeignKeys()
        {
            assetTypeID = ProcessComboBox(cboAssetType, 0) ?? throw new InvalidOperationException("You must select an asset type.");
            assetLocationID = ProcessComboBox(cboAssetLocation, 1) ?? 1; // Default to "None" if invalid
            departmentID = ProcessComboBox(cboDepartment, 1) ?? 1; // Default to "None" if invalid
            employeeID = ProcessComboBox(cboEmployee);
            manufacturerID = ProcessComboBox(cboManufacturer);
            operatingSystemID = ProcessComboBox(cboOperatingSystem, 23) ?? 23; // Default to "None" if invalid
        }

        /// <summary>
        /// Processes and validates the entered IPv4 address, returning it if valid, or throws an error if invalid.
        /// </summary>
        /// <returns>The valid IPv4 address or throws an InvalidOperationException if invalid.</returns>
        private string ProcessIPv4Address()
        {
            string ipAddress = ProcessTextField(txtIPv4Address);
            if (ipAddress != null && !CommonMethods.IsValidIP(ipAddress))
            {
                CommonMethods.DisplayError("The static IP is invalid.");
                throw new InvalidOperationException("Invalid IP Address.");
            }
            return ipAddress;
        }

        /// <summary>
        /// Processes and validates the entered MAC address, ensuring it follows the correct format.
        /// </summary>
        private void ProcessMacAddress()
        {
            macAddress = txtMacAddress.Text;

            if (!string.IsNullOrEmpty(macAddress))
            {
                macAddress = Regex.Replace(macAddress, @"[^0-9A-Fa-f]", "");

                if (macAddress.Length != 12)
                {
                    macAddress = null;
                    MessageBox.Show("Invalid MAC address.", "Input Error");
                    txtMacAddress.Focus();
                    txtMacAddress.SelectAll();
                }
            }
            else
            {
                macAddress = null;
            }
        }

        /// <summary>
        /// Processes the model field, inserting a new model record if it doesn't already exist, and retrieves the model ID.
        /// </summary>
        private void ProcessModel()
        {
            string modelText = txtModel.Text;

            if (!string.IsNullOrEmpty(modelText))
            {
                bool isExistingModel = txtModel.AutoCompleteCustomSource.Contains(modelText);

                if (!isExistingModel)
                {
                    InsertModelRecord(modelText);
                }

                modelID = GetModelID(modelText);
            }
            else
            {
                modelID = null;
            }
        }

        /// <summary>
        /// Processes the network name field, returning the entered name or null if the field is empty.
        /// </summary>
        /// <returns>The entered network name, or null if empty.</returns>
        private string ProcessNetworkName()
        {
            return ProcessTextField(txtNetworkName);
        }

        /// <summary>
        /// Processes other asset-related fields such as comments, IPv4, network name, and serial number.
        /// </summary>
        private void ProcessOtherFields()
        {
            comments = ProcessComments();
            ipv4 = ProcessIPv4Address();
            networkName = ProcessNetworkName();
            serialNumber = ProcessSerialNumber();
            acquiredDate = dteAcquiredDate.Value;
            disposed = chkDispose.Checked;
            disposalDate = disposed ? (DateTime?)dteDisposalDate.Value : null;
        }

        /// <summary>
        /// Processes the serial number field, returning the entered serial number or null if empty. Converts the value to uppercase.
        /// </summary>
        /// <returns>The entered serial number in uppercase, or null if empty.</returns>
        private string ProcessSerialNumber()
        {
            return ProcessTextField(txtSerialNumber, s => s.ToUpper());
        }

        /// <summary>
        /// Processes a text field, trimming the value and applying an optional processor function to the result.
        /// </summary>
        /// <param name="textBox">The TextBox control to process.</param>
        /// <param name="processor">An optional function to further process the text.</param>
        /// <returns>The processed text or null if the field is empty.</returns>
        private string ProcessTextField(TextBox textBox, Func<string, string> processor = null)
        {
            string text = textBox.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            return processor != null ? processor(text) : text;
        }

        /// <summary>
        /// Updates an existing asset record in the database using the current form data.
        /// </summary>
        private void UpdateExistingRecord()
        {
            warrantyFilePath = warrantyFile == null ? null : SaveAttachmentToShare();

            string query = @"
                UPDATE [Asset] 
                SET 
                    [Number] = @AssetNumber, 
                    [AssetType_ID] = @AssetTypeID, 
                    [Manufacturer_ID] = @ManufacturerID, 
                    [Model_ID] = @ModelID, 
                    [SerialNumber] = @SerialNumber, 
                    [NetworkName] = @NetworkName, 
                    [Employee_ID] = @EmployeeID, 
                    [IPv4] = @IPv4, 
                    [OperatingSystem_ID] = @OperatingSystemID, 
                    [MACAddress] = @MACAddress, 
                    [AssetLocation_ID] = @AssetLocationID, 
                    [AcquiredDate] = @AcquiredDate, 
                    [DisposalDate] = @DisposalDate, 
                    [Comments] = @Comments, 
                    [WarrantyFile] = @WarrantyFilePath, 
                    [Disposed] = @Disposed, 
                    [SiteLocation_ID] = @SiteLocationID
                WHERE 
                    [ID] = @AssetID;";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@AssetID", assetID);
                    cmd.Parameters.AddWithValue("@AssetNumber", assetNumber);
                    cmd.Parameters.AddWithValue("@AssetTypeID", assetTypeID);
                    cmd.Parameters.AddWithValue("@ManufacturerID", (object)manufacturerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModelID", (object)modelID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SerialNumber", (object)serialNumber ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NetworkName", (object)networkName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmployeeID", (object)employeeID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPv4", (object)ipv4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OperatingSystemID", operatingSystemID);
                    cmd.Parameters.AddWithValue("@MACAddress", (object)macAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssetLocationID", assetLocationID);
                    cmd.Parameters.AddWithValue("@AcquiredDate", acquiredDate);
                    cmd.Parameters.AddWithValue("@DisposalDate", (object)disposalDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Comments", (object)comments ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@WarrantyFilePath", (object)warrantyFilePath ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Disposed", disposed);
                    cmd.Parameters.AddWithValue("@SiteLocationID", SiteLocationID);

                    DatabaseMethods.CheckSqlConnectionState(sqlConnection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "UpdateExistingRecord");
            }
            finally
            {
                sqlConnection?.Close();
            }
        }

        /// <summary>
        /// Validates and processes all form data, checking for errors or invalid entries.
        /// </summary>
        /// <returns>True if the form data is valid, false otherwise.</returns>
        private bool ValidateAndProcessFormData()
        {
            if (!ProcessAssetNumber())
            {
                return false;
            }

            ProcessMacAddress();
            ProcessModel();
            ProcessForeignKeys();
            ProcessOtherFields();

            return true;
        }

        /// <summary>
        /// Writes the asset data to the database, either inserting a new record or updating an existing one.
        /// </summary>
        private void WriteToDatabase()
        {
            try
            {
                if (!ValidateAndProcessFormData())
                {
                    return;
                }

                if (newRecord)
                {
                    InsertNewRecord();
                }
                else
                {
                    UpdateExistingRecord();
                }

                ClearForm();
                GC.Collect();
            }
            catch (Exception ex)
            {
                CommonMethods.DisplayError(ex.Message, "Write to Database");
            }
        }

        #endregion
    }
}

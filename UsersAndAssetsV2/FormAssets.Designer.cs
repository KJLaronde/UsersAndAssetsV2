namespace UsersAndAssetsV2
{
    partial class FormAssets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewAsset = new System.Windows.Forms.Button();
            this.pnlDynamicInfo = new System.Windows.Forms.Panel();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.dteDisposalDate = new System.Windows.Forms.DateTimePicker();
            this.dteAcquiredDate = new System.Windows.Forms.DateTimePicker();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.picWarranty = new System.Windows.Forms.PictureBox();
            this.btnAttachmentView = new System.Windows.Forms.Button();
            this.btnAttachmentRemove = new System.Windows.Forms.Button();
            this.btnAttachmentAdd = new System.Windows.Forms.Button();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.cboOperatingSystem = new System.Windows.Forms.ComboBox();
            this.txtIPv4Address = new System.Windows.Forms.TextBox();
            this.cboAssetLocation = new System.Windows.Forms.ComboBox();
            this.txtNetworkName = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlProtectedInfo = new System.Windows.Forms.Panel();
            this.cboAssetType = new System.Windows.Forms.ComboBox();
            this.cboManufacturer = new System.Windows.Forms.ComboBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtAssetNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAssetSearch = new System.Windows.Forms.ComboBox();
            this.chkDispose = new System.Windows.Forms.CheckBox();
            this.pnlDynamicInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarranty)).BeginInit();
            this.pnlProtectedInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Location = new System.Drawing.Point(1221, 21);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 35);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Find by Asset Number:";
            // 
            // btnAddNewAsset
            // 
            this.btnAddNewAsset.AutoSize = true;
            this.btnAddNewAsset.Location = new System.Drawing.Point(736, 21);
            this.btnAddNewAsset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewAsset.Name = "btnAddNewAsset";
            this.btnAddNewAsset.Size = new System.Drawing.Size(165, 35);
            this.btnAddNewAsset.TabIndex = 1;
            this.btnAddNewAsset.Text = "Add New Asset";
            this.btnAddNewAsset.UseVisualStyleBackColor = true;
            this.btnAddNewAsset.Click += new System.EventHandler(this.btnAddNewAsset_Click);
            // 
            // pnlDynamicInfo
            // 
            this.pnlDynamicInfo.Controls.Add(this.cboDepartment);
            this.pnlDynamicInfo.Controls.Add(this.dteDisposalDate);
            this.pnlDynamicInfo.Controls.Add(this.dteAcquiredDate);
            this.pnlDynamicInfo.Controls.Add(this.cboEmployee);
            this.pnlDynamicInfo.Controls.Add(this.picWarranty);
            this.pnlDynamicInfo.Controls.Add(this.btnAttachmentView);
            this.pnlDynamicInfo.Controls.Add(this.btnAttachmentRemove);
            this.pnlDynamicInfo.Controls.Add(this.btnAttachmentAdd);
            this.pnlDynamicInfo.Controls.Add(this.txtMacAddress);
            this.pnlDynamicInfo.Controls.Add(this.cboOperatingSystem);
            this.pnlDynamicInfo.Controls.Add(this.txtIPv4Address);
            this.pnlDynamicInfo.Controls.Add(this.cboAssetLocation);
            this.pnlDynamicInfo.Controls.Add(this.txtNetworkName);
            this.pnlDynamicInfo.Controls.Add(this.txtComments);
            this.pnlDynamicInfo.Controls.Add(this.label20);
            this.pnlDynamicInfo.Controls.Add(this.label19);
            this.pnlDynamicInfo.Controls.Add(this.label18);
            this.pnlDynamicInfo.Controls.Add(this.label17);
            this.pnlDynamicInfo.Controls.Add(this.label16);
            this.pnlDynamicInfo.Controls.Add(this.label15);
            this.pnlDynamicInfo.Controls.Add(this.label14);
            this.pnlDynamicInfo.Controls.Add(this.label12);
            this.pnlDynamicInfo.Controls.Add(this.label11);
            this.pnlDynamicInfo.Controls.Add(this.label10);
            this.pnlDynamicInfo.Controls.Add(this.label9);
            this.pnlDynamicInfo.Location = new System.Drawing.Point(12, 174);
            this.pnlDynamicInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlDynamicInfo.Name = "pnlDynamicInfo";
            this.pnlDynamicInfo.Size = new System.Drawing.Size(1335, 353);
            this.pnlDynamicInfo.TabIndex = 19;
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartment.DisplayMember = "ID";
            this.cboDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.ItemHeight = 25;
            this.cboDepartment.Location = new System.Drawing.Point(6, 45);
            this.cboDepartment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(300, 33);
            this.cboDepartment.TabIndex = 20;
            this.cboDepartment.ValueMember = "ID";
            this.cboDepartment.DropDown += new System.EventHandler(this.cboDepartment_DropDown);
            this.cboDepartment.DropDownClosed += new System.EventHandler(this.cboDepartment_DropDownClosed);
            this.cboDepartment.TextChanged += new System.EventHandler(this.cboDepartment_TextChanged);
            // 
            // dteDisposalDate
            // 
            this.dteDisposalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDisposalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteDisposalDate.Location = new System.Drawing.Point(1170, 134);
            this.dteDisposalDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dteDisposalDate.Name = "dteDisposalDate";
            this.dteDisposalDate.Size = new System.Drawing.Size(154, 30);
            this.dteDisposalDate.TabIndex = 34;
            // 
            // dteAcquiredDate
            // 
            this.dteAcquiredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteAcquiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteAcquiredDate.Location = new System.Drawing.Point(1004, 134);
            this.dteAcquiredDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dteAcquiredDate.Name = "dteAcquiredDate";
            this.dteAcquiredDate.Size = new System.Drawing.Size(154, 30);
            this.dteAcquiredDate.TabIndex = 33;
            // 
            // cboEmployee
            // 
            this.cboEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEmployee.DisplayMember = "ID";
            this.cboEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(778, 46);
            this.cboEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(342, 33);
            this.cboEmployee.TabIndex = 22;
            this.cboEmployee.ValueMember = "ID";
            this.cboEmployee.DropDown += new System.EventHandler(this.cboEmployee_DropDown);
            // 
            // picWarranty
            // 
            this.picWarranty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWarranty.Location = new System.Drawing.Point(1110, 219);
            this.picWarranty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picWarranty.Name = "picWarranty";
            this.picWarranty.Size = new System.Drawing.Size(107, 120);
            this.picWarranty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWarranty.TabIndex = 48;
            this.picWarranty.TabStop = false;
            // 
            // btnAttachmentView
            // 
            this.btnAttachmentView.Location = new System.Drawing.Point(1236, 309);
            this.btnAttachmentView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentView.Name = "btnAttachmentView";
            this.btnAttachmentView.Size = new System.Drawing.Size(84, 29);
            this.btnAttachmentView.TabIndex = 43;
            this.btnAttachmentView.Text = "View";
            this.btnAttachmentView.UseVisualStyleBackColor = true;
            this.btnAttachmentView.Click += new System.EventHandler(this.btnAttachmentView_Click);
            // 
            // btnAttachmentRemove
            // 
            this.btnAttachmentRemove.Location = new System.Drawing.Point(1236, 262);
            this.btnAttachmentRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentRemove.Name = "btnAttachmentRemove";
            this.btnAttachmentRemove.Size = new System.Drawing.Size(84, 29);
            this.btnAttachmentRemove.TabIndex = 42;
            this.btnAttachmentRemove.Text = "Remove";
            this.btnAttachmentRemove.UseVisualStyleBackColor = true;
            this.btnAttachmentRemove.Click += new System.EventHandler(this.btnAttachmentRemove_Click);
            // 
            // btnAttachmentAdd
            // 
            this.btnAttachmentAdd.Location = new System.Drawing.Point(1236, 219);
            this.btnAttachmentAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttachmentAdd.Name = "btnAttachmentAdd";
            this.btnAttachmentAdd.Size = new System.Drawing.Size(84, 29);
            this.btnAttachmentAdd.TabIndex = 41;
            this.btnAttachmentAdd.Text = "Add";
            this.btnAttachmentAdd.UseVisualStyleBackColor = true;
            this.btnAttachmentAdd.Click += new System.EventHandler(this.btnAttachmentAdd_Click);
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMacAddress.Location = new System.Drawing.Point(514, 134);
            this.txtMacAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(223, 31);
            this.txtMacAddress.TabIndex = 31;
            // 
            // cboOperatingSystem
            // 
            this.cboOperatingSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOperatingSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOperatingSystem.DisplayMember = "ID";
            this.cboOperatingSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOperatingSystem.FormattingEnabled = true;
            this.cboOperatingSystem.Location = new System.Drawing.Point(3, 132);
            this.cboOperatingSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboOperatingSystem.Name = "cboOperatingSystem";
            this.cboOperatingSystem.Size = new System.Drawing.Size(504, 33);
            this.cboOperatingSystem.TabIndex = 30;
            this.cboOperatingSystem.ValueMember = "ID";
            this.cboOperatingSystem.DropDown += new System.EventHandler(this.cboOperatingSystem_DropDown);
            // 
            // txtIPv4Address
            // 
            this.txtIPv4Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPv4Address.Location = new System.Drawing.Point(1155, 48);
            this.txtIPv4Address.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIPv4Address.Name = "txtIPv4Address";
            this.txtIPv4Address.Size = new System.Drawing.Size(169, 31);
            this.txtIPv4Address.TabIndex = 23;
            this.txtIPv4Address.Text = "999.999.999.999";
            // 
            // cboAssetLocation
            // 
            this.cboAssetLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAssetLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssetLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssetLocation.FormattingEnabled = true;
            this.cboAssetLocation.Location = new System.Drawing.Point(746, 132);
            this.cboAssetLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboAssetLocation.Name = "cboAssetLocation";
            this.cboAssetLocation.Size = new System.Drawing.Size(250, 33);
            this.cboAssetLocation.TabIndex = 32;
            this.cboAssetLocation.DropDown += new System.EventHandler(this.cboAssetLocation_DropDown);
            // 
            // txtNetworkName
            // 
            this.txtNetworkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetworkName.Location = new System.Drawing.Point(336, 48);
            this.txtNetworkName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNetworkName.Name = "txtNetworkName";
            this.txtNetworkName.Size = new System.Drawing.Size(408, 31);
            this.txtNetworkName.TabIndex = 21;
            this.txtNetworkName.WordWrap = false;
            // 
            // txtComments
            // 
            this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(3, 219);
            this.txtComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(1085, 118);
            this.txtComments.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(1115, 191);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 25);
            this.label20.TabIndex = 29;
            this.label20.Text = "Warranty";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(-3, 189);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(114, 25);
            this.label19.TabIndex = 28;
            this.label19.Text = "Comments";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(2, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(183, 25);
            this.label18.TabIndex = 27;
            this.label18.Text = "Operating System";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1166, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(146, 25);
            this.label17.TabIndex = 26;
            this.label17.Text = "Disposal Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1000, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 25);
            this.label16.TabIndex = 25;
            this.label16.Text = "Acquired Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(508, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 25);
            this.label15.TabIndex = 24;
            this.label15.Text = "MAC Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1151, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 25);
            this.label14.TabIndex = 23;
            this.label14.Text = "Static IP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(774, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Employee*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(739, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 25);
            this.label11.TabIndex = 20;
            this.label11.Text = "Location*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Department*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(332, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Network Name";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(1098, 21);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlProtectedInfo
            // 
            this.pnlProtectedInfo.Controls.Add(this.cboAssetType);
            this.pnlProtectedInfo.Controls.Add(this.cboManufacturer);
            this.pnlProtectedInfo.Controls.Add(this.txtSerialNumber);
            this.pnlProtectedInfo.Controls.Add(this.txtModel);
            this.pnlProtectedInfo.Controls.Add(this.txtAssetNumber);
            this.pnlProtectedInfo.Controls.Add(this.label7);
            this.pnlProtectedInfo.Controls.Add(this.label6);
            this.pnlProtectedInfo.Controls.Add(this.label5);
            this.pnlProtectedInfo.Controls.Add(this.label4);
            this.pnlProtectedInfo.Controls.Add(this.label3);
            this.pnlProtectedInfo.Location = new System.Drawing.Point(12, 65);
            this.pnlProtectedInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlProtectedInfo.Name = "pnlProtectedInfo";
            this.pnlProtectedInfo.Size = new System.Drawing.Size(1335, 105);
            this.pnlProtectedInfo.TabIndex = 9;
            // 
            // cboAssetType
            // 
            this.cboAssetType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAssetType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssetType.DisplayMember = "ID";
            this.cboAssetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssetType.FormattingEnabled = true;
            this.cboAssetType.Location = new System.Drawing.Point(99, 48);
            this.cboAssetType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboAssetType.Name = "cboAssetType";
            this.cboAssetType.Size = new System.Drawing.Size(300, 33);
            this.cboAssetType.TabIndex = 11;
            this.cboAssetType.ValueMember = "ID";
            this.cboAssetType.DropDown += new System.EventHandler(this.cboAssetType_DropDown);
            // 
            // cboManufacturer
            // 
            this.cboManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboManufacturer.DisplayMember = "ID";
            this.cboManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboManufacturer.FormattingEnabled = true;
            this.cboManufacturer.Location = new System.Drawing.Point(406, 48);
            this.cboManufacturer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboManufacturer.Name = "cboManufacturer";
            this.cboManufacturer.Size = new System.Drawing.Size(300, 33);
            this.cboManufacturer.TabIndex = 12;
            this.cboManufacturer.ValueMember = "ID";
            this.cboManufacturer.DropDown += new System.EventHandler(this.cboManufacturer_DropDown);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNumber.Location = new System.Drawing.Point(1020, 49);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(304, 31);
            this.txtSerialNumber.TabIndex = 14;
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(714, 49);
            this.txtModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(300, 31);
            this.txtModel.TabIndex = 13;
            // 
            // txtAssetNumber
            // 
            this.txtAssetNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssetNumber.Location = new System.Drawing.Point(1, 49);
            this.txtAssetNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAssetNumber.Name = "txtAssetNumber";
            this.txtAssetNumber.Size = new System.Drawing.Size(90, 31);
            this.txtAssetNumber.TabIndex = 10;
            this.txtAssetNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1016, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 25);
            this.label7.TabIndex = 64;
            this.label7.Text = "Serial*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(708, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 63;
            this.label6.Text = "Model*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 62;
            this.label5.Text = "Manufacturer*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 61;
            this.label4.Text = "Asset Type*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 60;
            this.label3.Text = "Asset*";
            // 
            // cboAssetSearch
            // 
            this.cboAssetSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAssetSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssetSearch.DisplayMember = "ID";
            this.cboAssetSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssetSearch.FormattingEnabled = true;
            this.cboAssetSearch.Location = new System.Drawing.Point(537, 20);
            this.cboAssetSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboAssetSearch.Name = "cboAssetSearch";
            this.cboAssetSearch.Size = new System.Drawing.Size(180, 34);
            this.cboAssetSearch.TabIndex = 0;
            this.cboAssetSearch.ValueMember = "ID";
            this.cboAssetSearch.SelectedIndexChanged += new System.EventHandler(this.cboAssetSearch_DropDownClosed);
            this.cboAssetSearch.SelectionChangeCommitted += new System.EventHandler(this.cboAssetSearch_SelectionChangeCommitted);
            this.cboAssetSearch.DropDownClosed += new System.EventHandler(this.cboAssetSearch_DropDownClosed);
            this.cboAssetSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboAssetSearch_KeyDown);
            this.cboAssetSearch.Leave += new System.EventHandler(this.cboAssetSearch_DropDownClosed);
            // 
            // chkDispose
            // 
            this.chkDispose.AutoSize = true;
            this.chkDispose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDispose.Location = new System.Drawing.Point(948, 25);
            this.chkDispose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDispose.Name = "chkDispose";
            this.chkDispose.Size = new System.Drawing.Size(101, 26);
            this.chkDispose.TabIndex = 50;
            this.chkDispose.Text = "Dispose";
            this.chkDispose.UseVisualStyleBackColor = true;
            this.chkDispose.CheckedChanged += new System.EventHandler(this.chkDispose_CheckedChanged);
            // 
            // FormAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 539);
            this.Controls.Add(this.chkDispose);
            this.Controls.Add(this.cboAssetSearch);
            this.Controls.Add(this.pnlProtectedInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlDynamicInfo);
            this.Controls.Add(this.btnAddNewAsset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormAssets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User and Asset Management";
            this.Load += new System.EventHandler(this.FormAssets_Load);
            this.pnlDynamicInfo.ResumeLayout(false);
            this.pnlDynamicInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWarranty)).EndInit();
            this.pnlProtectedInfo.ResumeLayout(false);
            this.pnlProtectedInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewAsset;
        private System.Windows.Forms.Panel pnlDynamicInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtNetworkName;
        private System.Windows.Forms.ComboBox cboAssetLocation;
        private System.Windows.Forms.TextBox txtIPv4Address;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.ComboBox cboOperatingSystem;
        private System.Windows.Forms.PictureBox picWarranty;
        private System.Windows.Forms.Button btnAttachmentView;
        private System.Windows.Forms.Button btnAttachmentRemove;
        private System.Windows.Forms.Button btnAttachmentAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlProtectedInfo;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtAssetNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboManufacturer;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.ComboBox cboAssetType;
        private System.Windows.Forms.ComboBox cboAssetSearch;
        private System.Windows.Forms.DateTimePicker dteDisposalDate;
        private System.Windows.Forms.DateTimePicker dteAcquiredDate;
        private System.Windows.Forms.CheckBox chkDispose;
        private System.Windows.Forms.ComboBox cboDepartment;
    }
}
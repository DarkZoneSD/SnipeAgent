namespace SystemTrayApp
{
    partial class Home_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Form));
            pictureBox1 = new PictureBox();
            lblMACAddress = new Label();
            btnRefresh = new Button();
            lblMAC = new Label();
            lblAssetName = new Label();
            lblHostmachineNameValue = new Label();
            lblSerialNumber = new Label();
            lblSerialNumberValue = new Label();
            lblSnipeITServer = new Label();
            pictureBox2 = new PictureBox();
            lblApiKey = new Label();
            lblApiUrl = new Label();
            btnUAC = new Button();
            txtApiKey = new TextBox();
            btnSaveServerConfig = new Button();
            txtApiUrlValue = new TextBox();
            pbServerConnectionStatus = new PictureBox();
            lblServerConnectionStatus = new Label();
            lblLocalMachine = new Label();
            btnUpdateAssetData = new Button();
            lblInterfaceName = new Label();
            btnLastInterface = new Button();
            btnNextInterface = new Button();
            lblSystemUUID = new Label();
            lblSystemUUIDValue = new Label();
            lblSystemModelValue = new Label();
            lblSystemModel = new Label();
            lblManufacturerValue = new Label();
            lblManufacturer = new Label();
            txtAssetTag = new TextBox();
            txtAssetCategory = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtAssetName = new TextBox();
            txtAssetSerial = new TextBox();
            txtAssetModel = new TextBox();
            txtAssetMAC = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtAssetModelNumber = new TextBox();
            txtAssetUUID = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnCopyHostMachine = new Button();
            lblSystemUUIDValue2 = new Label();
            lblManufacturerValue2 = new Label();
            btnCopySerial = new Button();
            btnCopyUuid = new Button();
            btnCopyModel = new Button();
            btnCopyManufacturer = new Button();
            btnCopyMac = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbServerConnectionStatus).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.local_machine_icon_64_64;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblMACAddress
            // 
            lblMACAddress.AutoSize = true;
            lblMACAddress.BackColor = Color.Transparent;
            lblMACAddress.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMACAddress.ForeColor = SystemColors.ControlLight;
            lblMACAddress.Location = new Point(11, 79);
            lblMACAddress.Name = "lblMACAddress";
            lblMACAddress.Size = new Size(108, 20);
            lblMACAddress.TabIndex = 1;
            lblMACAddress.Text = "MAC Address:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.BackgroundImage = Properties.Resources.refresh_button_untriggered;
            btnRefresh.Location = new Point(82, 44);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(128, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblMAC
            // 
            lblMAC.AutoSize = true;
            lblMAC.BackColor = Color.Transparent;
            lblMAC.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMAC.ForeColor = SystemColors.ControlLight;
            lblMAC.Location = new Point(119, 81);
            lblMAC.Name = "lblMAC";
            lblMAC.Size = new Size(108, 17);
            lblMAC.TabIndex = 3;
            lblMAC.Text = "Placeholder MAC";
            // 
            // lblAssetName
            // 
            lblAssetName.AutoSize = true;
            lblAssetName.BackColor = Color.Transparent;
            lblAssetName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAssetName.ForeColor = SystemColors.ControlLight;
            lblAssetName.Location = new Point(12, 138);
            lblAssetName.Name = "lblAssetName";
            lblAssetName.Size = new Size(147, 20);
            lblAssetName.TabIndex = 7;
            lblAssetName.Text = "Hostmachine Name";
            lblAssetName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHostmachineNameValue
            // 
            lblHostmachineNameValue.AutoSize = true;
            lblHostmachineNameValue.BackColor = Color.Transparent;
            lblHostmachineNameValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHostmachineNameValue.ForeColor = SystemColors.ControlLight;
            lblHostmachineNameValue.Location = new Point(12, 161);
            lblHostmachineNameValue.Name = "lblHostmachineNameValue";
            lblHostmachineNameValue.Size = new Size(150, 17);
            lblHostmachineNameValue.TabIndex = 9;
            lblHostmachineNameValue.Text = "Placeholder Asset Name";
            // 
            // lblSerialNumber
            // 
            lblSerialNumber.AutoSize = true;
            lblSerialNumber.BackColor = Color.Transparent;
            lblSerialNumber.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSerialNumber.ForeColor = SystemColors.ControlLight;
            lblSerialNumber.Location = new Point(12, 190);
            lblSerialNumber.Name = "lblSerialNumber";
            lblSerialNumber.Size = new Size(109, 20);
            lblSerialNumber.TabIndex = 10;
            lblSerialNumber.Text = "Serial Number";
            lblSerialNumber.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSerialNumberValue
            // 
            lblSerialNumberValue.AutoSize = true;
            lblSerialNumberValue.BackColor = Color.Transparent;
            lblSerialNumberValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSerialNumberValue.ForeColor = SystemColors.ControlLight;
            lblSerialNumberValue.Location = new Point(12, 213);
            lblSerialNumberValue.Name = "lblSerialNumberValue";
            lblSerialNumberValue.Size = new Size(164, 17);
            lblSerialNumberValue.TabIndex = 11;
            lblSerialNumberValue.Text = "Placeholder Serial Number";
            // 
            // lblSnipeITServer
            // 
            lblSnipeITServer.AutoSize = true;
            lblSnipeITServer.BackColor = Color.Transparent;
            lblSnipeITServer.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSnipeITServer.ForeColor = SystemColors.ControlLight;
            lblSnipeITServer.Location = new Point(365, 21);
            lblSnipeITServer.Name = "lblSnipeITServer";
            lblSnipeITServer.Size = new Size(116, 20);
            lblSnipeITServer.TabIndex = 13;
            lblSnipeITServer.Text = "Snipe-IT Server";
            lblSnipeITServer.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.snipe_icon_64_64;
            pictureBox2.InitialImage = null;
            pictureBox2.Location = new Point(295, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // lblApiKey
            // 
            lblApiKey.AutoSize = true;
            lblApiKey.BackColor = Color.Transparent;
            lblApiKey.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApiKey.ForeColor = SystemColors.ControlLight;
            lblApiKey.Location = new Point(295, 125);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(64, 20);
            lblApiKey.TabIndex = 15;
            lblApiKey.Text = "API Key";
            lblApiKey.TextAlign = ContentAlignment.TopCenter;
            lblApiKey.Click += lblApiKey_Click;
            // 
            // lblApiUrl
            // 
            lblApiUrl.AutoSize = true;
            lblApiUrl.BackColor = Color.Transparent;
            lblApiUrl.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblApiUrl.ForeColor = SystemColors.ControlLight;
            lblApiUrl.Location = new Point(295, 79);
            lblApiUrl.Name = "lblApiUrl";
            lblApiUrl.Size = new Size(67, 20);
            lblApiUrl.TabIndex = 14;
            lblApiUrl.Text = "API URL";
            lblApiUrl.TextAlign = ContentAlignment.TopCenter;
            lblApiUrl.Click += lblApiUrl_Click;
            // 
            // btnUAC
            // 
            btnUAC.BackColor = Color.Transparent;
            btnUAC.BackgroundImage = Properties.Resources.uac_button_untriggered;
            btnUAC.BackgroundImageLayout = ImageLayout.Center;
            btnUAC.ForeColor = Color.Transparent;
            btnUAC.Location = new Point(266, 148);
            btnUAC.Name = "btnUAC";
            btnUAC.Size = new Size(23, 23);
            btnUAC.TabIndex = 5;
            btnUAC.UseVisualStyleBackColor = false;
            btnUAC.Click += btnUAC_Click;
            // 
            // txtApiKey
            // 
            txtApiKey.BackColor = Color.Gray;
            txtApiKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtApiKey.ForeColor = SystemColors.HighlightText;
            txtApiKey.Location = new Point(295, 148);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.PasswordChar = '•';
            txtApiKey.ReadOnly = true;
            txtApiKey.Size = new Size(361, 23);
            txtApiKey.TabIndex = 20;
            txtApiKey.TextChanged += txtApiKey_TextChanged;
            // 
            // btnSaveServerConfig
            // 
            btnSaveServerConfig.BackColor = Color.Transparent;
            btnSaveServerConfig.BackgroundImage = Properties.Resources.save_button_untriggered;
            btnSaveServerConfig.Location = new Point(560, 177);
            btnSaveServerConfig.Name = "btnSaveServerConfig";
            btnSaveServerConfig.Size = new Size(96, 32);
            btnSaveServerConfig.TabIndex = 21;
            btnSaveServerConfig.UseVisualStyleBackColor = false;
            btnSaveServerConfig.Click += btnSaveServerConfig_Click;
            // 
            // txtApiUrlValue
            // 
            txtApiUrlValue.BackColor = Color.Gray;
            txtApiUrlValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtApiUrlValue.ForeColor = SystemColors.HighlightText;
            txtApiUrlValue.Location = new Point(295, 102);
            txtApiUrlValue.Name = "txtApiUrlValue";
            txtApiUrlValue.ReadOnly = true;
            txtApiUrlValue.Size = new Size(361, 23);
            txtApiUrlValue.TabIndex = 22;
            // 
            // pbServerConnectionStatus
            // 
            pbServerConnectionStatus.BackColor = Color.Transparent;
            pbServerConnectionStatus.BackgroundImage = Properties.Resources.server_connection_status_icon_pending;
            pbServerConnectionStatus.BackgroundImageLayout = ImageLayout.Center;
            pbServerConnectionStatus.Location = new Point(482, 21);
            pbServerConnectionStatus.Name = "pbServerConnectionStatus";
            pbServerConnectionStatus.Size = new Size(16, 16);
            pbServerConnectionStatus.TabIndex = 23;
            pbServerConnectionStatus.TabStop = false;
            // 
            // lblServerConnectionStatus
            // 
            lblServerConnectionStatus.AutoSize = true;
            lblServerConnectionStatus.BackColor = Color.Transparent;
            lblServerConnectionStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblServerConnectionStatus.ForeColor = Color.White;
            lblServerConnectionStatus.Location = new Point(365, 41);
            lblServerConnectionStatus.Name = "lblServerConnectionStatus";
            lblServerConnectionStatus.Size = new Size(61, 17);
            lblServerConnectionStatus.TabIndex = 24;
            lblServerConnectionStatus.Text = "Pending..";
            // 
            // lblLocalMachine
            // 
            lblLocalMachine.AutoSize = true;
            lblLocalMachine.BackColor = Color.Transparent;
            lblLocalMachine.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocalMachine.ForeColor = SystemColors.ControlLight;
            lblLocalMachine.Location = new Point(82, 21);
            lblLocalMachine.Name = "lblLocalMachine";
            lblLocalMachine.Size = new Size(108, 20);
            lblLocalMachine.TabIndex = 26;
            lblLocalMachine.Text = "Local Machine";
            lblLocalMachine.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnUpdateAssetData
            // 
            btnUpdateAssetData.BackColor = Color.Transparent;
            btnUpdateAssetData.BackgroundImage = Properties.Resources.save_button_untriggered;
            btnUpdateAssetData.Location = new Point(560, 461);
            btnUpdateAssetData.Name = "btnUpdateAssetData";
            btnUpdateAssetData.Size = new Size(96, 32);
            btnUpdateAssetData.TabIndex = 29;
            btnUpdateAssetData.UseVisualStyleBackColor = false;
            btnUpdateAssetData.Click += btnUpdateAssetData_Click;
            // 
            // lblInterfaceName
            // 
            lblInterfaceName.AutoSize = true;
            lblInterfaceName.BackColor = Color.Transparent;
            lblInterfaceName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInterfaceName.ForeColor = SystemColors.ControlLight;
            lblInterfaceName.Location = new Point(40, 102);
            lblInterfaceName.Name = "lblInterfaceName";
            lblInterfaceName.Size = new Size(161, 17);
            lblInterfaceName.TabIndex = 30;
            lblInterfaceName.Text = "InterfaceNamePlaceholder";
            // 
            // btnLastInterface
            // 
            btnLastInterface.BackColor = Color.Transparent;
            btnLastInterface.BackgroundImage = Properties.Resources.direction_button_untriggered;
            btnLastInterface.BackgroundImageLayout = ImageLayout.Center;
            btnLastInterface.ForeColor = Color.Transparent;
            btnLastInterface.Location = new Point(12, 100);
            btnLastInterface.Name = "btnLastInterface";
            btnLastInterface.Size = new Size(23, 23);
            btnLastInterface.TabIndex = 31;
            btnLastInterface.UseVisualStyleBackColor = false;
            btnLastInterface.Click += btnLastInterface_Click;
            // 
            // btnNextInterface
            // 
            btnNextInterface.BackColor = Color.Transparent;
            btnNextInterface.BackgroundImage = Properties.Resources.direction_button_untriggered;
            btnNextInterface.BackgroundImageLayout = ImageLayout.Center;
            btnNextInterface.ForeColor = Color.Transparent;
            btnNextInterface.Location = new Point(206, 101);
            btnNextInterface.Name = "btnNextInterface";
            btnNextInterface.Size = new Size(23, 23);
            btnNextInterface.TabIndex = 32;
            btnNextInterface.UseVisualStyleBackColor = false;
            btnNextInterface.Click += btnNextInterface_Click;
            // 
            // lblSystemUUID
            // 
            lblSystemUUID.AutoSize = true;
            lblSystemUUID.BackColor = Color.Transparent;
            lblSystemUUID.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemUUID.ForeColor = SystemColors.ControlLight;
            lblSystemUUID.Location = new Point(12, 236);
            lblSystemUUID.Name = "lblSystemUUID";
            lblSystemUUID.Size = new Size(102, 20);
            lblSystemUUID.TabIndex = 33;
            lblSystemUUID.Text = "System UUID";
            lblSystemUUID.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSystemUUIDValue
            // 
            lblSystemUUIDValue.AutoSize = true;
            lblSystemUUIDValue.BackColor = Color.Transparent;
            lblSystemUUIDValue.Font = new Font("Segoe UI", 8.75F);
            lblSystemUUIDValue.ForeColor = SystemColors.ControlLight;
            lblSystemUUIDValue.Location = new Point(12, 259);
            lblSystemUUIDValue.Name = "lblSystemUUIDValue";
            lblSystemUUIDValue.Size = new Size(140, 15);
            lblSystemUUIDValue.TabIndex = 34;
            lblSystemUUIDValue.Text = "Placeholder System UUID";
            // 
            // lblSystemModelValue
            // 
            lblSystemModelValue.AutoSize = true;
            lblSystemModelValue.BackColor = Color.Transparent;
            lblSystemModelValue.Font = new Font("Segoe UI", 8.75F);
            lblSystemModelValue.ForeColor = SystemColors.ControlLight;
            lblSystemModelValue.Location = new Point(12, 322);
            lblSystemModelValue.Name = "lblSystemModelValue";
            lblSystemModelValue.Size = new Size(147, 15);
            lblSystemModelValue.TabIndex = 36;
            lblSystemModelValue.Text = "Placeholder System Model";
            // 
            // lblSystemModel
            // 
            lblSystemModel.AutoSize = true;
            lblSystemModel.BackColor = Color.Transparent;
            lblSystemModel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemModel.ForeColor = SystemColors.ControlLight;
            lblSystemModel.Location = new Point(12, 299);
            lblSystemModel.Name = "lblSystemModel";
            lblSystemModel.Size = new Size(108, 20);
            lblSystemModel.TabIndex = 35;
            lblSystemModel.Text = "System Model";
            lblSystemModel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblManufacturerValue
            // 
            lblManufacturerValue.AutoSize = true;
            lblManufacturerValue.BackColor = Color.Transparent;
            lblManufacturerValue.Font = new Font("Segoe UI", 8.75F);
            lblManufacturerValue.ForeColor = SystemColors.ControlLight;
            lblManufacturerValue.Location = new Point(12, 368);
            lblManufacturerValue.Name = "lblManufacturerValue";
            lblManufacturerValue.Size = new Size(144, 15);
            lblManufacturerValue.TabIndex = 38;
            lblManufacturerValue.Text = "Placeholder Manufacturer";
            // 
            // lblManufacturer
            // 
            lblManufacturer.AutoSize = true;
            lblManufacturer.BackColor = Color.Transparent;
            lblManufacturer.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManufacturer.ForeColor = SystemColors.ControlLight;
            lblManufacturer.Location = new Point(12, 345);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new Size(105, 20);
            lblManufacturer.TabIndex = 37;
            lblManufacturer.Text = "Manufacturer";
            lblManufacturer.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtAssetTag
            // 
            txtAssetTag.BackColor = Color.Gray;
            txtAssetTag.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetTag.ForeColor = SystemColors.HighlightText;
            txtAssetTag.Location = new Point(295, 281);
            txtAssetTag.Name = "txtAssetTag";
            txtAssetTag.ReadOnly = true;
            txtAssetTag.Size = new Size(174, 23);
            txtAssetTag.TabIndex = 42;
            txtAssetTag.UseSystemPasswordChar = true;
            // 
            // txtAssetCategory
            // 
            txtAssetCategory.BackColor = Color.Gray;
            txtAssetCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetCategory.ForeColor = SystemColors.HighlightText;
            txtAssetCategory.Location = new Point(295, 327);
            txtAssetCategory.Name = "txtAssetCategory";
            txtAssetCategory.Size = new Size(174, 23);
            txtAssetCategory.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(295, 304);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 40;
            label1.Text = "Category";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(295, 258);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 39;
            label2.Text = "Asset Tag";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtAssetName
            // 
            txtAssetName.BackColor = Color.Gray;
            txtAssetName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetName.ForeColor = SystemColors.HighlightText;
            txtAssetName.Location = new Point(478, 281);
            txtAssetName.Name = "txtAssetName";
            txtAssetName.Size = new Size(174, 23);
            txtAssetName.TabIndex = 43;
            // 
            // txtAssetSerial
            // 
            txtAssetSerial.BackColor = Color.Gray;
            txtAssetSerial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetSerial.ForeColor = SystemColors.HighlightText;
            txtAssetSerial.Location = new Point(482, 327);
            txtAssetSerial.Name = "txtAssetSerial";
            txtAssetSerial.Size = new Size(174, 23);
            txtAssetSerial.TabIndex = 44;
            // 
            // txtAssetModel
            // 
            txtAssetModel.BackColor = Color.Gray;
            txtAssetModel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetModel.ForeColor = SystemColors.HighlightText;
            txtAssetModel.Location = new Point(295, 373);
            txtAssetModel.Name = "txtAssetModel";
            txtAssetModel.Size = new Size(174, 23);
            txtAssetModel.TabIndex = 48;
            // 
            // txtAssetMAC
            // 
            txtAssetMAC.BackColor = Color.Gray;
            txtAssetMAC.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetMAC.ForeColor = SystemColors.HighlightText;
            txtAssetMAC.Location = new Point(295, 419);
            txtAssetMAC.Name = "txtAssetMAC";
            txtAssetMAC.Size = new Size(174, 23);
            txtAssetMAC.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(295, 396);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 46;
            label3.Text = "MAC Address";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLight;
            label4.Location = new Point(295, 350);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 45;
            label4.Text = "Model";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtAssetModelNumber
            // 
            txtAssetModelNumber.BackColor = Color.Gray;
            txtAssetModelNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetModelNumber.ForeColor = SystemColors.HighlightText;
            txtAssetModelNumber.Location = new Point(482, 373);
            txtAssetModelNumber.Name = "txtAssetModelNumber";
            txtAssetModelNumber.Size = new Size(174, 23);
            txtAssetModelNumber.TabIndex = 54;
            // 
            // txtAssetUUID
            // 
            txtAssetUUID.BackColor = Color.Gray;
            txtAssetUUID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAssetUUID.ForeColor = SystemColors.HighlightText;
            txtAssetUUID.Location = new Point(482, 419);
            txtAssetUUID.Name = "txtAssetUUID";
            txtAssetUUID.Size = new Size(174, 23);
            txtAssetUUID.TabIndex = 53;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLight;
            label5.Location = new Point(482, 396);
            label5.Name = "label5";
            label5.Size = new Size(102, 20);
            label5.TabIndex = 52;
            label5.Text = "System UUID";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLight;
            label6.Location = new Point(482, 350);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 51;
            label6.Text = "Model No.";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLight;
            label7.Location = new Point(482, 304);
            label7.Name = "label7";
            label7.Size = new Size(47, 20);
            label7.TabIndex = 50;
            label7.Text = "Serial";
            label7.TextAlign = ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ControlLight;
            label8.Location = new Point(482, 258);
            label8.Name = "label8";
            label8.Size = new Size(94, 20);
            label8.TabIndex = 49;
            label8.Text = "Asset Name";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnCopyHostMachine
            // 
            btnCopyHostMachine.BackColor = Color.Transparent;
            btnCopyHostMachine.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopyHostMachine.BackgroundImageLayout = ImageLayout.Center;
            btnCopyHostMachine.ForeColor = Color.Transparent;
            btnCopyHostMachine.Location = new Point(204, 161);
            btnCopyHostMachine.Name = "btnCopyHostMachine";
            btnCopyHostMachine.Size = new Size(23, 23);
            btnCopyHostMachine.TabIndex = 55;
            btnCopyHostMachine.UseVisualStyleBackColor = false;
            btnCopyHostMachine.Click += btnCopyHostMachien_Click;
            // 
            // lblSystemUUIDValue2
            // 
            lblSystemUUIDValue2.AutoSize = true;
            lblSystemUUIDValue2.BackColor = Color.Transparent;
            lblSystemUUIDValue2.Font = new Font("Segoe UI", 8.75F);
            lblSystemUUIDValue2.ForeColor = SystemColors.ControlLight;
            lblSystemUUIDValue2.Location = new Point(12, 276);
            lblSystemUUIDValue2.Name = "lblSystemUUIDValue2";
            lblSystemUUIDValue2.Size = new Size(140, 15);
            lblSystemUUIDValue2.TabIndex = 56;
            lblSystemUUIDValue2.Text = "Placeholder System UUID";
            // 
            // lblManufacturerValue2
            // 
            lblManufacturerValue2.AutoSize = true;
            lblManufacturerValue2.BackColor = Color.Transparent;
            lblManufacturerValue2.Font = new Font("Segoe UI", 8.75F);
            lblManufacturerValue2.ForeColor = SystemColors.ControlLight;
            lblManufacturerValue2.Location = new Point(12, 385);
            lblManufacturerValue2.Name = "lblManufacturerValue2";
            lblManufacturerValue2.Size = new Size(0, 15);
            lblManufacturerValue2.TabIndex = 57;
            // 
            // btnCopySerial
            // 
            btnCopySerial.BackColor = Color.Transparent;
            btnCopySerial.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopySerial.BackgroundImageLayout = ImageLayout.Center;
            btnCopySerial.ForeColor = Color.Transparent;
            btnCopySerial.Location = new Point(204, 213);
            btnCopySerial.Name = "btnCopySerial";
            btnCopySerial.Size = new Size(23, 23);
            btnCopySerial.TabIndex = 58;
            btnCopySerial.UseVisualStyleBackColor = false;
            btnCopySerial.Click += btnCopySerial_Click;
            // 
            // btnCopyUuid
            // 
            btnCopyUuid.BackColor = Color.Transparent;
            btnCopyUuid.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopyUuid.BackgroundImageLayout = ImageLayout.Center;
            btnCopyUuid.ForeColor = Color.Transparent;
            btnCopyUuid.Location = new Point(204, 259);
            btnCopyUuid.Name = "btnCopyUuid";
            btnCopyUuid.Size = new Size(23, 23);
            btnCopyUuid.TabIndex = 59;
            btnCopyUuid.UseVisualStyleBackColor = false;
            btnCopyUuid.Click += btnCopyUuid_Click;
            // 
            // btnCopyModel
            // 
            btnCopyModel.BackColor = Color.Transparent;
            btnCopyModel.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopyModel.BackgroundImageLayout = ImageLayout.Center;
            btnCopyModel.ForeColor = Color.Transparent;
            btnCopyModel.Location = new Point(204, 322);
            btnCopyModel.Name = "btnCopyModel";
            btnCopyModel.Size = new Size(23, 23);
            btnCopyModel.TabIndex = 60;
            btnCopyModel.UseVisualStyleBackColor = false;
            btnCopyModel.Click += btnCopyModel_Click;
            // 
            // btnCopyManufacturer
            // 
            btnCopyManufacturer.BackColor = Color.Transparent;
            btnCopyManufacturer.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopyManufacturer.BackgroundImageLayout = ImageLayout.Center;
            btnCopyManufacturer.ForeColor = Color.Transparent;
            btnCopyManufacturer.Location = new Point(204, 368);
            btnCopyManufacturer.Name = "btnCopyManufacturer";
            btnCopyManufacturer.Size = new Size(23, 23);
            btnCopyManufacturer.TabIndex = 61;
            btnCopyManufacturer.UseVisualStyleBackColor = false;
            btnCopyManufacturer.Click += btnCopyManufacturer_Click;
            // 
            // btnCopyMac
            // 
            btnCopyMac.BackColor = Color.Transparent;
            btnCopyMac.BackgroundImage = Properties.Resources.copy_button_untriggered;
            btnCopyMac.BackgroundImageLayout = ImageLayout.Center;
            btnCopyMac.ForeColor = Color.Transparent;
            btnCopyMac.Location = new Point(216, 49);
            btnCopyMac.Name = "btnCopyMac";
            btnCopyMac.Size = new Size(23, 23);
            btnCopyMac.TabIndex = 62;
            btnCopyMac.UseVisualStyleBackColor = false;
            btnCopyMac.Click += btnCopyMac_Click;
            // 
            // Home_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.home_menu_ui;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(664, 505);
            Controls.Add(btnCopyMac);
            Controls.Add(btnCopyManufacturer);
            Controls.Add(btnCopyModel);
            Controls.Add(btnCopyUuid);
            Controls.Add(btnCopySerial);
            Controls.Add(lblManufacturerValue2);
            Controls.Add(lblSystemUUIDValue2);
            Controls.Add(btnCopyHostMachine);
            Controls.Add(txtAssetModelNumber);
            Controls.Add(txtAssetUUID);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(txtAssetModel);
            Controls.Add(txtAssetMAC);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtAssetSerial);
            Controls.Add(txtAssetName);
            Controls.Add(txtAssetTag);
            Controls.Add(txtAssetCategory);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblManufacturerValue);
            Controls.Add(lblManufacturer);
            Controls.Add(lblSystemModelValue);
            Controls.Add(lblSystemModel);
            Controls.Add(lblSystemUUIDValue);
            Controls.Add(lblSystemUUID);
            Controls.Add(btnNextInterface);
            Controls.Add(btnLastInterface);
            Controls.Add(lblInterfaceName);
            Controls.Add(btnUpdateAssetData);
            Controls.Add(lblLocalMachine);
            Controls.Add(lblServerConnectionStatus);
            Controls.Add(pbServerConnectionStatus);
            Controls.Add(txtApiUrlValue);
            Controls.Add(btnSaveServerConfig);
            Controls.Add(txtApiKey);
            Controls.Add(btnUAC);
            Controls.Add(lblApiKey);
            Controls.Add(lblApiUrl);
            Controls.Add(lblSnipeITServer);
            Controls.Add(pictureBox2);
            Controls.Add(lblSerialNumberValue);
            Controls.Add(lblSerialNumber);
            Controls.Add(lblHostmachineNameValue);
            Controls.Add(lblAssetName);
            Controls.Add(lblMAC);
            Controls.Add(btnRefresh);
            Controls.Add(lblMACAddress);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home_Form";
            Text = "Home_Form";
            Load += Home_Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbServerConnectionStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblMACAddress;
        private Button btnRefresh;
        private Label lblMAC;
        private Label lblAssetID;
        private Label lblAssetName;
        private Label lblAssetIDValue;
        private Label lblHostmachineNameValue;
        private Label lblSerialNumber;
        private Label lblSerialNumberValue;
        private Label lblSnipeITServer;
        private PictureBox pictureBox2;
        private Label lblApiKey;
        private Label lblApiUrl;
        private Button btnUAC;
        private TextBox txtApiKey;
        private Button btnSaveServerConfig;
        private TextBox txtApiUrlValue;
        private PictureBox pbServerConnectionStatus;
        private Label lblServerConnectionStatus;
        private Label lblLocalMachine;
        private Button btnUpdateAssetData;
        private Label lblInterfaceName;
        private Button btnLastInterface;
        private Button btnNextInterface;
        private Label lblSystemUUID;
        private Label lblSystemUUIDValue;
        private Label lblSystemModelValue;
        private Label lblSystemModel;
        private Label lblManufacturerValue;
        private Label lblManufacturer;
        private TextBox txtAssetTag;
        private TextBox txtAssetCategory;
        private Label label1;
        private Label label2;
        private TextBox txtAssetName;
        private TextBox txtAssetSerial;
        private TextBox txtAssetModel;
        private TextBox txtAssetMAC;
        private Label label3;
        private Label label4;
        private TextBox txtAssetModelNumber;
        private TextBox txtAssetUUID;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnCopyHostMachine;
        private Label lblSystemUUIDValue2;
        private Label lblManufacturerValue2;
        private Button btnCopySerial;
        private Button btnCopyUuid;
        private Button btnCopyModel;
        private Button btnCopyManufacturer;
        private Button btnCopyMac;
    }
}
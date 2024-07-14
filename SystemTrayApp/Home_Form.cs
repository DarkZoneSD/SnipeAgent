using DotNetEnv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using SystemTrayApp.Properties;
using SystemTrayApp.src;
using System.Net.Http.Headers;
using System.Management;

namespace SystemTrayApp
{
    public partial class Home_Form : Form
    {

        private System.Timers.Timer apiCheckTimer;
        public bool unlocked = false;

        public static List<NetworkInterface> AllNetworkInterfaces = getAllNetworkInterfaces();
        public int selectedInterfaceIndex = 0;
        public Home_Form()
        {
            InitializeComponent();
            InitializeApiCheckTimer();

            txtApiKey.Text = Global.ApiToken;
            txtApiUrlValue.Text = Global.ApiUrl;
            UseAssetProperties();

            btnRefresh.MouseEnter += OnMouseEnterBtnRefresh;
            btnRefresh.MouseLeave += OnMouseLeaveBtnRefresh;
            btnSaveServerConfig.MouseEnter += OnMouseEnterBtnSaveServerConfig;
            btnSaveServerConfig.MouseLeave += OnMouseLeaveBtnSaveServerConfig;
            btnUAC.MouseEnter += OnMouseEnterBtnUAC;
            btnUAC.MouseLeave += OnMouseLeaveBtnUAC;
            btnLastInterface.MouseEnter += OnMouseEnterBtnLastInterface;
            btnLastInterface.MouseLeave += OnMouseLeaveBtnLastInterface;
            btnNextInterface.MouseEnter += OnMouseEnterBtnNextInterface;
            btnNextInterface.MouseLeave += OnMouseLeaveBtnNextInterface;
            btnCopyHostMachine.MouseEnter += OnMouseEnterBtnCopyHostMachine;
            btnCopyHostMachine.MouseLeave += OnMouseLeaveBtnCopyHostMachine;
            btnCopySerial.MouseEnter += OnMouseEnterBtnCopySerial;
            btnCopySerial.MouseLeave += OnMouseLeaveBtnCopySerial;
            btnCopyUuid.MouseEnter += OnMouseEnterBtnCopyUuid;
            btnCopyUuid.MouseLeave += OnMouseLeaveBtnCopyUuid;
            btnCopyModel.MouseEnter += OnMouseEnterBtnCopyModel;
            btnCopyModel.MouseLeave += OnMouseLeaveBtnCopyModel;
            btnCopyManufacturer.MouseEnter += OnMouseEnterBtnCopyManufacturer;
            btnCopyManufacturer.MouseLeave += OnMouseLeaveBtnCopyManufacturer;
            btnCopyMac.MouseEnter += OnMouseEnterBtnCopyMac;
            btnCopyMac.MouseLeave += OnMouseLeaveBtnCopyMac;
            btnUpdateAssetData.MouseEnter += OnMouseEnterBtnUpdateAssetData;
            btnUpdateAssetData.MouseLeave += OnMouseLeaveBtnUpdateAssetData;

            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;

            if (IsUserAdministrator())
            {
                RevealText();
                txtApiKey.ReadOnly = false;
                txtApiUrlValue.ReadOnly = false;
                unlocked = true;
                btnUAC.BackgroundImage = Resources.uac_button_triggered;
            }
            lblHostmachineNameValue.Text = Global.HostName;
            lblSerialNumberValue.Text = Global.SerialNumber;

            string uuid = Global.Uuid;
            int indexOfThirdDash = uuid.IndexOf('-', uuid.IndexOf('-') + 1);
            string part1 = uuid.Substring(0, indexOfThirdDash + 1);
            string part2 = uuid.Substring(indexOfThirdDash + 1);

            lblSystemUUIDValue.Text = part1;
            lblSystemUUIDValue2.Text = part2;

            if (Global.Manufacturer.Length > 30)
            {
                string manufacterer_part_one = Global.Manufacturer.Substring(0, 30);
                string manufacterer_part_two = Global.Manufacturer.Substring(30);
                lblManufacturerValue.Text = manufacterer_part_one;
                lblManufacturerValue2.Text = manufacterer_part_two;
            }
            else lblManufacturerValue.Text = Global.Manufacturer;

            lblSystemModelValue.Text = Global.SystemModel;

            lblServerConnectionStatus.MaximumSize = new Size(300, 0);
            lblServerConnectionStatus.AutoSize = true;
            lblInterfaceName.MaximumSize = new Size(160, 0);
            lblInterfaceName.AutoSize = true;
            lblInterfaceName.Text = AllNetworkInterfaces[selectedInterfaceIndex].Name;
            UpdateInterfaceSelectionPosition();

            rotateImage(btnNextInterface);
        }
        private void UpdateInterfaceSelectionPosition()
        {
            //120 is half of the left control panels width
            lblInterfaceName.Location = new Point(120 - lblInterfaceName.Size.Width / 2, 102);
            btnLastInterface.Location = new Point(lblInterfaceName.Location.X - 28, lblInterfaceName.Location.Y);
            btnNextInterface.Location = new Point(lblInterfaceName.Location.X + lblInterfaceName.Size.Width + 5, lblInterfaceName.Location.Y);
        }

        private void InitializeApiCheckTimer()
        {
            apiCheckTimer = new System.Timers.Timer();
            apiCheckTimer.Interval = 5000; // 5 seconds
            apiCheckTimer.Elapsed += CheckApiStatus;
            apiCheckTimer.AutoReset = true;
            apiCheckTimer.Enabled = true;
        }
        private void Home_Form_Load(object sender, EventArgs e)
        {
            lblMAC.Text = getMacAddress(selectedInterfaceIndex);
            lblServerConnectionStatus.ForeColor = Color.FromArgb(255, 165, 0);

            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.BackColor = Color.FromArgb(27, 27, 27);
            }
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //Transparent
            }

        }
        private void OnMouseEnterBtnRefresh(object sender, EventArgs e)
        {
            btnRefresh.BackgroundImage = Resources.refresh_button_triggered;
        }
        private void OnMouseLeaveBtnRefresh(object sender, EventArgs e)
        {
            btnRefresh.BackgroundImage = Resources.refresh_button_untriggered;
        }
        private void OnMouseEnterBtnSaveServerConfig(object sender, EventArgs e)
        {
            btnSaveServerConfig.BackgroundImage = Resources.save_button_triggered;
        }
        private void OnMouseLeaveBtnSaveServerConfig(object sender, EventArgs e)
        {
            btnSaveServerConfig.BackgroundImage = Resources.save_button_untriggered;
        }
        private void OnMouseEnterBtnUAC(object sender, EventArgs e)
        {
            btnUAC.BackgroundImage = Resources.uac_button_triggered;
        }
        private void OnMouseLeaveBtnUAC(object sender, EventArgs e)
        {
            btnUAC.BackgroundImage = Resources.uac_button_untriggered;
        }
        private void OnMouseEnterBtnLastInterface(object sender, EventArgs e)
        {
            btnLastInterface.BackgroundImage = Resources.direction_button_triggered;
        }
        private void OnMouseLeaveBtnLastInterface(object sender, EventArgs e)
        {
            btnLastInterface.BackgroundImage = Resources.direction_button_untriggered;
        }
        private void OnMouseEnterBtnCopyHostMachine(object sender, EventArgs e)
        {
            btnCopyHostMachine.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopyHostMachine(object sender, EventArgs e)
        {
            btnCopyHostMachine.BackgroundImage = Resources.copy_button_untriggered;
        }

        private void OnMouseEnterBtnCopySerial(object sender, EventArgs e)
        {
            btnCopySerial.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopySerial(object sender, EventArgs e)
        {
            btnCopySerial.BackgroundImage = Resources.copy_button_untriggered;
        }

        private void OnMouseEnterBtnCopyUuid(object sender, EventArgs e)
        {
            btnCopyUuid.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopyUuid(object sender, EventArgs e)
        {
            btnCopyUuid.BackgroundImage = Resources.copy_button_untriggered;
        }

        private void OnMouseEnterBtnCopyModel(object sender, EventArgs e)
        {
            btnCopyModel.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopyModel(object sender, EventArgs e)
        {
            btnCopyModel.BackgroundImage = Resources.copy_button_untriggered;
        }

        private void OnMouseEnterBtnCopyManufacturer(object sender, EventArgs e)
        {
            btnCopyManufacturer.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopyManufacturer(object sender, EventArgs e)
        {
            btnCopyManufacturer.BackgroundImage = Resources.copy_button_untriggered;
        }
        private void OnMouseEnterBtnCopyMac(object sender, EventArgs e)
        {
            btnCopyMac.BackgroundImage = Resources.copy_button_triggered;
        }
        private void OnMouseLeaveBtnCopyMac(object sender, EventArgs e)
        {
            btnCopyMac.BackgroundImage = Resources.copy_button_untriggered;
        }
        private void OnMouseEnterBtnUpdateAssetData(object sender, EventArgs e)
        {
            btnUpdateAssetData.BackgroundImage = Resources.save_button_triggered;
        }
        private void OnMouseLeaveBtnUpdateAssetData(object sender, EventArgs e)
        {
            btnUpdateAssetData.BackgroundImage = Resources.save_button_untriggered;
        }
        private void OnMouseEnterBtnNextInterface(object sender, EventArgs e)
        {
            btnNextInterface.BackgroundImage = Resources.direction_button_triggered;
            rotateImage(btnNextInterface);
        }
        private void OnMouseLeaveBtnNextInterface(object sender, EventArgs e)
        {
            btnNextInterface.BackgroundImage = Resources.direction_button_untriggered;
            rotateImage(btnNextInterface);
        }
        private void rotateImage(Button btn)
        {
            Image img = btn.BackgroundImage;
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            btn.BackgroundImage = img;
        }
        private string getMacAddress(int index)
        {
            string mac = AllNetworkInterfaces[index].GetPhysicalAddress().ToString();
            var s = mac;
            var list = Enumerable
                .Range(0, s.Length / 2)
                .Select(i => s.Substring(i * 2, 2));
            var res = string.Join("-", list);
            return res;
        }
        private static List<NetworkInterface> getAllNetworkInterfaces()
        {
            List<NetworkInterface> list = new List<NetworkInterface>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in interfaces)
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    list.Add(nic);
                }
            }
            return list;
        }
        private string getInterfaceName()
        {
            string interfaceName = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.Name)
                .FirstOrDefault();
            return interfaceName;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblInterfaceName.Text = getInterfaceName();
            lblMAC.Text = getMacAddress(selectedInterfaceIndex);
            Cursor.Current = Cursors.Default;
        }

        private void lblApiUrl_Click(object sender, EventArgs e) { }
        private void txtApiKey_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblApiKey_Click(object sender, EventArgs e) { }
        private void btnUAC_Click(object sender, EventArgs e)
        {
            if (!unlocked)
            {
                if (IsUserAdministrator())
                {
                    RevealText();
                    txtApiUrlValue.ReadOnly = false;
                    unlocked = true;
                }
                else
                {
                    RestartElevated();
                }
            }
            else if (unlocked)
            {
                HideText();
                txtApiUrlValue.ReadOnly = true;
                unlocked = false;
            }

        }
        private bool IsUserAdministrator()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Authorization error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        private void RevealText()
        {
            txtApiKey.PasswordChar = '\0'; //no masking
        }
        private void HideText()
        {
            txtApiKey.PasswordChar = '•';
        }

        private void RestartElevated()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Application.ExecutablePath,
                    Verb = "runas" // Request UAC elevation
                };

                Process.Start(startInfo);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Elevation error: " + ex.Message);
            }
        }

        private void UpdateStatus(string statusMessage, bool isConnected)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string, bool>(UpdateStatus), new object[] { statusMessage, isConnected });
                return;
            }
            if (isConnected)
            {
                pbServerConnectionStatus.Image = Properties.Resources.server_connection_status_icon_connected;
                pbServerConnectionStatus.Size = new Size(16, 16);
                pbServerConnectionStatus.Location = new Point(482, 21);
                lblServerConnectionStatus.Text = statusMessage;
                lblServerConnectionStatus.ForeColor = Color.FromArgb(58, 255, 88);
                if (txtAssetTagValue.Text.Length == 0)
                {
                    UseAssetProperties();
                }
            }
            else
            {
                pbServerConnectionStatus.Image = Properties.Resources.server_connection_status_icon_disconnected;
                lblServerConnectionStatus.Text = statusMessage;
                lblServerConnectionStatus.ForeColor = Color.FromArgb(255, 71, 68);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            apiCheckTimer.Stop();
            apiCheckTimer.Dispose();
            base.OnFormClosing(e);
        }
        private async void btnTestAPI_Click(object sender, EventArgs e)
        {
        }
        private async void CheckApiStatus(object sender, ElapsedEventArgs e)
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            string apiToken = DotNetEnv.Env.GetString("API_TOKEN");
            string apiUrl = DotNetEnv.Env.GetString("API_URL");
            string successOrFail = "";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            using (client)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{apiUrl}/hardware");

                    if (response.IsSuccessStatusCode)
                    {
                        successOrFail = $"Request was successful, StatusCode: {response.StatusCode}";
                        UpdateStatus("Request was successful.", true);
                    }
                    else
                    {
                        successOrFail = $"Request failed, StatusCode: {response.StatusCode}";
                        UpdateStatus($"Request failed. HTTP Status: {response.StatusCode}", false);
                    }
                }
                catch (HttpRequestException ex)
                {
                    successOrFail = $"Request error: {ex.Message}";
                    UpdateStatus($"Request error: {ex.Message}", false);
                }
            }
            if (successOrFail.Contains("OK"))
            {
                Console.WriteLine("---------------------------------------------------------------\n" +
                                  "\u001b[33mChecking API Status:\u001b[0m\n" +
                                  "\u001b[32m" + successOrFail + "\n" + "\u001b[0m" +
                                  "---------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------\n" +
                  "\u001b[33mChecking API Status:\u001b[0m\n" +
                  "\u001b[31m" + successOrFail + "\n" + "\u001b[0m" +
                  "---------------------------------------------------------------");
            }
            
        }

        private void kcbNICs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveServerConfig_Click(object sender, EventArgs e)
        {
            EnvFile.Update("API_URL", txtApiUrlValue.Text);
            EnvFile.Update("API_TOKEN", txtApiKey.Text);
        }

        private void btnLastInterface_Click(object sender, EventArgs e)
        {
            selectedInterfaceIndex -= 1;
            if (selectedInterfaceIndex < 0) selectedInterfaceIndex = AllNetworkInterfaces.Count - 1;
            lblInterfaceName.Text = AllNetworkInterfaces[selectedInterfaceIndex].Name;
            lblMAC.Text = getMacAddress(selectedInterfaceIndex);

            UpdateInterfaceSelectionPosition();

            if (lblInterfaceName.Size.Height > 17) MoveTextDown();
            else MoveTextUp();
        }

        private void btnNextInterface_Click(object sender, EventArgs e)
        {
            selectedInterfaceIndex += 1;
            if (selectedInterfaceIndex >= AllNetworkInterfaces.Count) selectedInterfaceIndex = 0;
            lblInterfaceName.Text = AllNetworkInterfaces[selectedInterfaceIndex].Name;
            lblMAC.Text = getMacAddress(selectedInterfaceIndex);
            UpdateInterfaceSelectionPosition();

            if (lblInterfaceName.Size.Height > 17) MoveTextDown();
            else MoveTextUp();
        }

        private async void btnUpdateAssetData_Click(object sender, EventArgs e)
        {
            //Context_Menu_Form ctmForm = new Context_Menu_Form();
            //ctmForm.Show();

            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            string macCustomField = DotNetEnv.Env.GetString("MAC_CUSTOM_FIELD");
            string uuidCustomField = DotNetEnv.Env.GetString("UUID_CUSTOM_FIELD");

            Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { macCustomField, txtAssetMAC.Text.Replace('-',':') },
                { "name",txtAssetName.Text},
                { uuidCustomField, txtAssetUUID.Text},
                { "model_id", txtAssetModelNumber.Text },
                {"serial", txtAssetSerial.Text }
            };
            UpdateAsset(updates);

            //await SnipeIT.AssignAssetToUser();
        }

        private void btnCopyHostMachien_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Global.HostName);
        }

        private void btnCopySerial_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Global.SerialNumber);
        }

        private void btnCopyUuid_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Global.Uuid);
        }

        private void btnCopyModel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Global.SystemModel);
        }

        private void btnCopyManufacturer_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Global.Manufacturer);
        }

        private void btnCopyMac_Click(object sender, EventArgs e)
        {
            if (lblMAC.Text.Length > 0) Clipboard.SetText(lblMAC.Text);
            else Clipboard.Clear();
        }

        public void MoveTextDown()
        {
            if (!(lblHostMachineName.Location == new Point(12, 155)))
            {
                this.Hide();
                this.BackgroundImage = Resources.home_menu_ui_lower_line;
                this.lblHostMachineName.Location = new Point(12, 138 + 17);
                this.lblHostmachineNameValue.Location = new Point(12, 161 + 17);
                this.btnCopyHostMachine.Location = new Point(204, 161 + 17);

                this.lblSerialNumber.Location = new Point(12, 190 + 17);
                this.lblSerialNumberValue.Location = new Point(12, 213 + 17);
                this.btnCopySerial.Location = new Point(204, 213 + 17);

                this.lblSystemUUID.Location = new Point(12, 236 + 17);
                this.lblSystemUUIDValue.Location = new Point(12, 259 + 17);
                this.lblSystemUUIDValue2.Location = new Point(12, 276 + 17);
                this.btnCopyUuid.Location = new Point(204, 259 + 17);

                this.lblSystemModel.Location = new Point(12, 299 + 17);
                this.lblSystemModelValue.Location = new Point(12, 322 + 17);
                this.btnCopyModel.Location = new Point(204, 322 + 17);

                this.lblManufacturer.Location = new Point(12, 345 + 17);
                this.lblManufacturerValue.Location = new Point(12, 368 + 17);
                this.lblManufacturerValue2.Location = new Point(12, 385 + 17);
                this.btnCopyManufacturer.Location = new Point(204, 368 + 17);
                this.Show();
            }

        }
        public void MoveTextUp()
        {
            if (!(lblHostMachineName.Location == new Point(12, 138)))
            {
                this.Hide();
                this.BackgroundImage = Resources.home_menu_ui;
                this.lblHostMachineName.Location = new Point(12, 138);
                this.lblHostmachineNameValue.Location = new Point(12, 161);
                this.btnCopyHostMachine.Location = new Point(204, 161);

                this.lblSerialNumber.Location = new Point(12, 190);
                this.lblSerialNumberValue.Location = new Point(12, 213);
                this.btnCopySerial.Location = new Point(204, 213);

                this.lblSystemUUID.Location = new Point(12, 236);
                this.lblSystemUUIDValue.Location = new Point(12, 259);
                this.lblSystemUUIDValue2.Location = new Point(12, 276);
                this.btnCopyUuid.Location = new Point(204, 259);

                this.lblSystemModel.Location = new Point(12, 299);
                this.lblSystemModelValue.Location = new Point(12, 322);
                this.btnCopyModel.Location = new Point(204, 322);

                this.lblManufacturer.Location = new Point(12, 345);
                this.lblManufacturerValue.Location = new Point(12, 368);
                this.lblManufacturerValue2.Location = new Point(12, 385);
                this.btnCopyManufacturer.Location = new Point(204, 368);
                this.Show();
            }
        }
        public async Task UpdateAsset(Dictionary<string, object> propertiesToUpdate)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            int numericId = int.Parse(txtAssetTagValue.Text);
            string trimmedId = numericId.ToString();
            await SnipeIT.UpdateHardwareAssetProperty(trimmedId, propertiesToUpdate); //updates  the asset
            this.Hide();
            await UseAssetProperties(); //displays it in the form

            this.Show();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
        public async Task UseAssetProperties()
        {
            txtAssetTagValue.Text = await Global.GetAssetTag();
            txtAssetName.Text = await Global.GetAssetName();
            txtAssetCategory.Text = await Global.GetAssetCategory();
            txtAssetSerial.Text = await Global.GetAssetSerial();
            txtAssetModel.Text = await Global.GetAssetModel();
            txtAssetModelNumber.Text = await Global.GetAssetModelNo();
            txtAssetUUID.Text = await Global.GetAssetUUID();
            txtAssetMAC.Text = await Global.GetAssetMAC();
        }

        private void txtAssetTag_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAssetModel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

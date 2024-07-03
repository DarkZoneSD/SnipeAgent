using System;
using SystemTrayApp.Properties;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace SystemTrayApp
{
    public partial class Form1 : Form
    {
        bool settingsIsShowing, homeIsShowing;

        Home_Form home_form = new Home_Form();
        public bool homeIsClicked = false;
        public bool settingsIsClicked = false;
        public Form1()
        {
            settingsIsShowing = true;
            InitializeComponent();
            //TODO https://www.youtube.com/watch?v=2h69Ce4MZiQ Costum ContextMenuStrip for COOOOOLER Design (maybe)
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            
            this.openToolStripMenuItem.Click += showToolStripMenuItem_Click;
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;

            this.WindowState = FormWindowState.Minimized;
            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;
            this.SizeChanged += Form1_Resize;
            //Drag and Drop Form
            this.pnlDragAndDrop.MouseDown += new MouseEventHandler(DragAndDropMouseDown);
            this.lblAppName.MouseDown += new MouseEventHandler(DragAndDropMouseDown);
            this.pbAppIcon.MouseDown += new MouseEventHandler(DragAndDropMouseDown);

            //Menu Buttons
            btnCloseApp.MouseEnter += OnMouseEnterBtnCloseApp;
            btnCloseApp.MouseLeave += OnMouseLeaveBtnCloseApp;
            btnCloseApp.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btnCloseApp.BackColorChanged += (s, e) =>
            {
                btnCloseApp.FlatAppearance.MouseOverBackColor = Color.DimGray;
            };

            btnMinimizeApp.MouseEnter += OnMouseEnterBtnMinimizeApp;
            btnMinimizeApp.MouseLeave += OnMouseLeaveBtnMinimizeApp;
            btnMinimizeApp.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btnMinimizeApp.BackColorChanged += (s, e) =>
            {
                btnMinimizeApp.FlatAppearance.MouseOverBackColor = Color.DimGray;
            };

            btnSettings.MouseEnter += OnMouseEnterBtnSettings;
            btnSettings.MouseLeave += OnMouseLeaveBtnSettings;

            btnHome.MouseEnter += OnMouseEnterBtnHome;
            btnHome.MouseLeave += OnMouseLeaveBtnHome;

            //Select Home Menu on Startup
            home_form.TopLevel = false;
            flpCurrentMenu.Controls.Clear();
            flpCurrentMenu.Controls.Add(home_form);
            home_form.Show();
            btnHome_Click(new object(), new EventArgs());
        }
        
        private bool allowVisible;     // ContextMenu's Show command used
        private bool allowClose;       // ContextMenu's Exit command used

        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowVisible = true;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowClose = true;
            this.Close();
            Application.Exit();
        }

        //Drag and Drop Form
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void DragAndDropMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
            }
        }

        //End Drag and Drop Form

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void OnMouseEnterBtnCloseApp(object sender, EventArgs e)
        {
            btnCloseApp.BackgroundImage = Resources.exit_button_triggered;
        }
        private void OnMouseLeaveBtnCloseApp(object sender, EventArgs e)
        {
            btnCloseApp.BackgroundImage = Resources.exit_button_untriggered;
        }
        private void OnMouseEnterBtnMinimizeApp(object sender, EventArgs e)
        {
            btnMinimizeApp.BackgroundImage = Resources.minimize_button_triggered;
        }
        private void OnMouseLeaveBtnMinimizeApp(object sender, EventArgs e)
        {
            btnMinimizeApp.BackgroundImage = Resources.minimize_button_untriggered;
        }
        //Settings Button
        private void OnMouseEnterBtnSettings(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Resources.settings_button_triggered;
        }
        private void OnMouseLeaveBtnSettings(object sender, EventArgs e)
        {
            if (!settingsIsClicked) btnSettings.BackgroundImage = Resources.settings_button_untriggered;
        }
        private void OnMouseEnterBtnHome(object sender, EventArgs e)
        {
            btnHome.BackgroundImage = Resources.home_button_triggered;
        }
        private void OnMouseLeaveBtnHome(object sender, EventArgs e)
        {
            if (!homeIsClicked) btnHome.BackgroundImage = Resources.home_button_untriggered;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;

            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //Transparent
            }
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMinimizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!homeIsShowing)
            {
                settingsIsClicked = false;
                btnSettings.BackgroundImage = Resources.settings_button_untriggered;
                btnHome.BackgroundImage = Resources.home_button_triggered;
                Settings_Form settings_form = new Settings_Form();

                settings_form.Hide();
                home_form.TopLevel = false;
                flpCurrentMenu.Controls.Clear();
                flpCurrentMenu.Controls.Add(home_form);
                home_form.Show();

                homeIsClicked = true;
                settingsIsShowing = false;
                homeIsShowing = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (!settingsIsShowing)
            {
                homeIsClicked = false;
                btnHome.BackgroundImage = Resources.home_button_untriggered;
                btnSettings.BackgroundImage = Resources.settings_button_triggered;

                //Select Settings Menu
                Settings_Form settings_form = new Settings_Form();
                settings_form.TopLevel = false;

                flpCurrentMenu.Controls.Add(settings_form);
                settings_form.Show();
                home_form.Hide();

                settingsIsClicked = true;
                homeIsShowing = false;
                settingsIsShowing = true;
            }

        }

        private void pnlDragAndDrop_Paint(object sender, PaintEventArgs e) { }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
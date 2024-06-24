using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayApp.Properties;

namespace SystemTrayApp
{
    public partial class Settings_Form : Form
    {
        public Settings_Form()
        {
            InitializeComponent();
            btnOpenGithub.MouseEnter += OnMouseEnterBtnOpenGitHub;
            btnOpenGithub.MouseLeave += OnMouseLeaveBtnOpenGitHub;

            btnOpenAppdataFolder.MouseEnter += OnMouseEnterBtnOpenAppdataFolder;
            btnOpenAppdataFolder.MouseLeave += OnMouseLeaveBtnOpenAppdataFolder;

            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //Transparent
            }
        }

        private void OnMouseEnterBtnOpenGitHub(object sender, EventArgs e)
        {
            btnOpenGithub.BackgroundImage = Resources.github_button_triggered;
        }
        private void OnMouseLeaveBtnOpenGitHub(object sender, EventArgs e)
        {
            btnOpenGithub.BackgroundImage = Resources.github_button_untriggered;
        }
        private void OnMouseEnterBtnOpenAppdataFolder(object sender, EventArgs e)
        {
            btnOpenAppdataFolder.BackgroundImage = Resources.folder_button_triggered;
        }
        private void OnMouseLeaveBtnOpenAppdataFolder(object sender, EventArgs e)
        {
            btnOpenAppdataFolder.BackgroundImage = Resources.folder_button_untriggered;
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenGithub_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/DarkZoneSD/SnipeAgent";
            myProcess.Start();
        }

        private void btnOpenAppdataFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent");
        }
    }
}

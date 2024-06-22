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

            btnOpenGithub.FlatStyle = FlatStyle.Flat;
            btnOpenGithub.FlatAppearance.BorderSize = 0;
            btnOpenGithub.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

        }

        private void OnMouseEnterBtnOpenGitHub(object sender, EventArgs e)
        {
            btnOpenGithub.BackgroundImage = Resources.github_button_triggered;
        }
        private void OnMouseLeaveBtnOpenGitHub(object sender, EventArgs e)
        {
            btnOpenGithub.BackgroundImage = Resources.github_button_untriggered;
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
    }
}

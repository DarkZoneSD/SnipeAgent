namespace SystemTrayApp
{
    partial class Settings_Form
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
            btnOpenGithub = new Button();
            btnOpenAppdataFolder = new Button();
            sButton1 = new Styling_Toggle_Button.SButton();
            SuspendLayout();
            // 
            // btnOpenGithub
            // 
            btnOpenGithub.BackColor = Color.Transparent;
            btnOpenGithub.BackgroundImage = Properties.Resources.github_button_untriggered;
            btnOpenGithub.BackgroundImageLayout = ImageLayout.Center;
            btnOpenGithub.ForeColor = Color.Transparent;
            btnOpenGithub.Location = new Point(620, 461);
            btnOpenGithub.Name = "btnOpenGithub";
            btnOpenGithub.Size = new Size(32, 32);
            btnOpenGithub.TabIndex = 63;
            btnOpenGithub.UseVisualStyleBackColor = false;
            btnOpenGithub.Click += btnOpenGithub_Click;
            // 
            // btnOpenAppdataFolder
            // 
            btnOpenAppdataFolder.BackColor = Color.Transparent;
            btnOpenAppdataFolder.BackgroundImage = Properties.Resources.folder_button_untriggered;
            btnOpenAppdataFolder.BackgroundImageLayout = ImageLayout.Center;
            btnOpenAppdataFolder.ForeColor = Color.Transparent;
            btnOpenAppdataFolder.Location = new Point(582, 461);
            btnOpenAppdataFolder.Name = "btnOpenAppdataFolder";
            btnOpenAppdataFolder.Size = new Size(32, 32);
            btnOpenAppdataFolder.TabIndex = 64;
            btnOpenAppdataFolder.UseVisualStyleBackColor = false;
            btnOpenAppdataFolder.Click += btnOpenAppdataFolder_Click;
            // 
            // sButton1
            // 
            sButton1.Appearance = Appearance.Button;
            sButton1.AutoSize = true;
            sButton1.BackColor = Color.Purple;
            sButton1.BackgroundImage = Properties.Resources.context_menu;
            sButton1.Checked = true;
            sButton1.CheckState = CheckState.Checked;
            sButton1.ForeColor = Color.DimGray;
            sButton1.Location = new Point(12, 12);
            sButton1.MinimumSize = new Size(45, 22);
            sButton1.Name = "sButton1";
            sButton1.OffBackColor = Color.Gray;
            sButton1.OffToggleColor = Color.Gainsboro;
            sButton1.OnBackColor = Color.MediumSlateBlue;
            sButton1.OnToggleColor = Color.WhiteSmoke;
            sButton1.Size = new Size(45, 22);
            sButton1.TabIndex = 65;
            sButton1.UseVisualStyleBackColor = false;
            // 
            // Settings_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.settings_menu_ui;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(664, 505);
            Controls.Add(sButton1);
            Controls.Add(btnOpenAppdataFolder);
            Controls.Add(btnOpenGithub);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings_Form";
            Text = "Settings_Form";
            Load += Settings_Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenGithub;
        private Button btnOpenAppdataFolder;
        private Styling_Toggle_Button.SButton sButton1;
    }
}
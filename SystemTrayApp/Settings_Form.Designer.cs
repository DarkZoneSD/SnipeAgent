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
            // Settings_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.settings_menu_ui;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(664, 505);
            Controls.Add(btnOpenAppdataFolder);
            Controls.Add(btnOpenGithub);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings_Form";
            Text = "Settings_Form";
            Load += Settings_Form_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenGithub;
        private Button btnOpenAppdataFolder;
    }
}
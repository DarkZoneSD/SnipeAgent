namespace SystemTrayApp
{
    partial class Context_Menu_Form
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
            btnOpen = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.BackColor = Color.Transparent;
            btnOpen.BackgroundImage = Properties.Resources.context_menu_open_button_untriggered;
            btnOpen.BackgroundImageLayout = ImageLayout.Center;
            btnOpen.Location = new Point(0, 0);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(70, 24);
            btnOpen.TabIndex = 0;
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundImage = Properties.Resources.context_menu_close_button_untriggered;
            btnClose.BackgroundImageLayout = ImageLayout.Center;
            btnClose.Location = new Point(0, 24);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(70, 24);
            btnClose.TabIndex = 1;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // Context_Menu_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.context_menu;
            ClientSize = new Size(70, 48);
            Controls.Add(btnClose);
            Controls.Add(btnOpen);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Context_Menu_Form";
            Text = "Context_Menu_Form";
            Load += Context_Menu_Form_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpen;
        private Button btnClose;
    }
}
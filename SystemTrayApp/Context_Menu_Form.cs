using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayApp.Properties;

namespace SystemTrayApp
{
    public partial class Context_Menu_Form : Form
    {
        public Context_Menu_Form()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            btnClose.MouseEnter += OnMouseEnterBtnClose;
            btnClose.MouseLeave += OnMouseLeaveBtnClosep;

            btnOpen.MouseEnter += OnMouseEnterBtnOpen;
            btnOpen.MouseLeave += OnMouseLeaveBtnOpen;

        }
        private void OnMouseEnterBtnClose(object? sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.context_menu_close_button_triggered;
        }
        private void OnMouseLeaveBtnClosep(object? sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.context_menu_close_button_untriggered;
        }
        private void OnMouseEnterBtnOpen(object? sender, EventArgs e)
        {
            btnOpen.BackgroundImage = Resources.context_menu_open_button_triggered;
        }
        private void OnMouseLeaveBtnOpen(object? sender, EventArgs e)
        {
            btnOpen.BackgroundImage = Resources.context_menu_open_button_untriggered;
        }

        private void Context_Menu_Form_Load(object? sender, EventArgs e)
        {

            this.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y - 48);
            this.Size = new Size(70, 48);
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //Transparent
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

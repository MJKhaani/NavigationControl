using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NavigationControl
{
    public partial class NavigationItemControl : UserControl
    {
        public delegate void NavigationItemClicked(object sender, NavigationItem args);
        public event NavigationItemClicked NavigationItemClickedEvent;

        public NavigationItem NavigationItem { get; set; }
        public NavigationItemControl(NavigationItem item, bool rtl = false)
        {
            NavigationItem = item;

            InitializeComponent();

            button.Text = NavigationItem.Text;
            button.UseVisualStyleBackColor = false;
            if (NavigationItem.Icon != null)
                pictureBox.Image = NavigationItem.Icon;

            if (rtl)
            {
                pictureBox.Dock = DockStyle.Right;
                button.RightToLeft = RightToLeft.Yes;
                button.Location = new Point(0, 0);
            }

            if(item.Childs!=null)
                button.Font = new Font(button.Font.FontFamily, button.Font.Size, FontStyle.Bold);

            button.MouseEnter += NavigationItemControl_MouseEnter;
            button.MouseLeave += NavigationItemControl_MouseLeave;
            pictureBox.MouseEnter += NavigationItemControl_MouseEnter;
            pictureBox.MouseLeave += NavigationItemControl_MouseLeave;
            this.button.Click += NavigationItemControl_Click;
            this.pictureBox.Click += NavigationItemControl_Click;
        }

        private void NavigationItemControl_Click(object sender, EventArgs e)
        {
            NavigationItemClickedEvent?.Invoke(this, NavigationItem);
        }

        private void NavigationItemControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.BlueViolet;
        }

        private void NavigationItemControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Indigo;
        }

    }
}

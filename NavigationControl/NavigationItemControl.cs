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

        private bool _selected = false;

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

        public void Deselect(NavigationItem selectedItem)
        {
            if (NavigationItem.Id != selectedItem.Id)
            {
                this.BackColor = System.Drawing.Color.Indigo;
                _selected = false;
            }
        }

        private void NavigationItemControl_Click(object sender, EventArgs e)
        {
            _selected = true;
            this.BackColor = System.Drawing.Color.BlueViolet;
            NavigationItemClickedEvent?.Invoke(this, NavigationItem);
        }

        private void NavigationItemControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.BlueViolet;
        }

        private void NavigationItemControl_MouseLeave(object sender, EventArgs e)
        {
            if(!_selected)
                this.BackColor = System.Drawing.Color.Indigo;
        }

    }
}
